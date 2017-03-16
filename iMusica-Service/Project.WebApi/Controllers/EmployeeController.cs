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
                    BirthDate = Convert.ToDateTime(model.BirthDate),
                    Gender = (Gender) Enum.Parse(typeof(Gender), model.Gender),
                    Role = new Role()
                };

                emp.Role = _roleRepository.GetById(model.IdRole);

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

        [HttpGet]
        [Route("getById/{id}")]
        public HttpResponseMessage GetById(Guid id)
        {
            try
            {
                var emp = _empRepository.GetById(id);

                var role = _roleRepository.GetById(emp.Role.Id);
                emp.Role = role;
                emp.IdRole = emp.Role.Id;

                var model = new EmployeeViewModelEdition()
                {
                    Id = emp.Id,
                    Name = emp.Name,
                    Email = emp.Email,
                    Gender = emp.Gender.ToString(),
                    BirthDate = emp.BirthDate.ToString(),
                    IdRole = emp.IdRole
                };



                emp.Dependents = _depRepository.GetAll().Where(x => x.Employee.Id == emp.Id).ToList();

                if (emp.Dependents.Any())
                {
                    model.Dependents = new List<string>();

                    foreach (var dep in emp.Dependents)
                    {
                        model.Dependents.Add(dep.Name);
                    }
                }

                return Request.CreateResponse(HttpStatusCode.OK, model);
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
                emp.Role = _roleRepository.GetById(model.IdRole);

                emp.Name = model.Name;
                emp.Email = model.Email;
                emp.BirthDate = Convert.ToDateTime(model.BirthDate);
                emp.Gender = (Gender) Enum.Parse(typeof(Gender), model.Gender);

                //foreach (var dep in emp.Dependents) //ToDo: refazer esta logica para considerar o length dos dependentes antigos e novose
                //{
                //    foreach (var name in model.Dependents)
                //    {
                //        dep.Name = name;
                //    }
                //}

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
                        BirthDate = emp.BirthDate.ToString(),
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
