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
                    Gender = (Gender) Enum.Parse(typeof(Gender), model.Gender)
                };

                emp.Role = new Role()
                {
                    RoleType = (RoleType)Enum.Parse(typeof(RoleType), model.RoleType)
                };

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
        [Route("getAll")]
        public HttpResponseMessage Get()
        {
            try
            {
                var list = new List<EmployeeViewModelRequest>();

                foreach (var emp in _empRepository.GetAll())
                {
                    var model = new EmployeeViewModelRequest()
                    {
                        Id = emp.Id,
                        Name = emp.Name,
                        Email = emp.Email,
                        BirthDate = emp.BirthDate,
                        RoleType = emp.Role.RoleType.ToString(),
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
    }
}
