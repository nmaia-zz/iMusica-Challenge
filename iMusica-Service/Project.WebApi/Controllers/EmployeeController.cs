using Newtonsoft.Json;
using Project.Entities;
using Project.Entities.Enum;
using Project.Infra.Repository;
using Project.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project.WebApi.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        private readonly EmployeeRepository _empRepository = new EmployeeRepository();
        private readonly RoleRepository _roleRepository = new RoleRepository();
        private readonly DependentRepository _depRepository = new DependentRepository();

        [HttpPost]
        [Route("register")]
        public HttpResponseMessage Post(EmployeeViewModelRegister model)
        {
            try
            {
                Employee emp = new Employee()
                {
                    Name = model.Name,
                    Email = model.Email,
                    BirthDate = model.BirthDate,
                    Gender = (Gender) Enum.Parse(typeof(Gender), model.Gender),
                    Role = new Role()
                };

                var IdRole = _roleRepository.GetRoleIdByType(model.RoleType);
                emp.Role = _roleRepository.GetById(IdRole);

                if (model.Dependents.Any())
                {
                    emp.Dependents = new List<Dependent>();

                    foreach (var name in model.Dependents)
                    {
                        var dep = new Dependent()
                        {
                            Name = name
                        };

                        emp.Dependents.Add(dep);
                    }
                }

                _empRepository.Insert(emp);

                return Request.CreateResponse(HttpStatusCode.OK, "Employee has been registered successfully.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPut]
        [Route("edit")]
        public HttpResponseMessage Put(EmployeeViewModelEdition model)
        {
            try
            {
                Employee emp = _empRepository.GetById(model.Id);

                emp.Name = model.Name;
                emp.Email = model.Email;
                emp.BirthDate = model.BirthDate;
                emp.Gender = (Gender) Enum.Parse(typeof(Gender), model.Gender);
                emp.Role.RoleType = model.RoleType;

                foreach (var dep in emp.Dependents)
                {
                    foreach (var name in model.Dependents)
                    {
                        dep.Name = name;
                    }
                }

                _empRepository.Update(emp);

                return Request.CreateResponse(HttpStatusCode.OK, "Employee data has been updated successfully.");

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(Guid id)
        {
            try
            {
                Employee emp = _empRepository.GetById(id);

                if (emp != null)
                {
                    _empRepository.Delete(emp);

                    return Request.CreateResponse(HttpStatusCode.OK, "Employee has been removed successfully.");
                }
                else
                {
                    throw new Exception("Employee not found.");
                }                
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("getAll")]
        public HttpResponseMessage Get()
        {
            try
            {
                var list = new List<EmployeeViewModelRequest>();

                foreach (var emp in _empRepository.GetAll())
                {
                    var role = _roleRepository.GetById(emp.Role.Id);

                    var model = new EmployeeViewModelRequest()
                    {
                        Id = emp.Id,
                        Name = emp.Name,
                        Email = emp.Email,
                        BirthDate = emp.BirthDate,
                        RoleType = role.RoleType,
                        Gender = emp.Gender.ToString(),
                        DependentsQuantity = _depRepository.QttyOfDependentsForEachEmployee(emp.Id)
                    };

                    list.Add(model);
                }

                return Request.CreateResponse(HttpStatusCode.OK, list);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("searchEmployeesByName/{name}")]
        public HttpResponseMessage SearchEmployeesByName(string name)
        {
            try
            {
                var list = _empRepository.GetEmployeesByName(name);

                if (list.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, list);
                }
                else
                {
                    throw new Exception("No one employee has been found.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
