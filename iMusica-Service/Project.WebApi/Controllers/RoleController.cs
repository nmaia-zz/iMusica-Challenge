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
    [RoutePrefix("api/role")]
    public class RoleController : ApiController
    {
        private readonly RoleRepository _roleRepository = new RoleRepository();

        [HttpGet]
        [Route("getAll")]
        public HttpResponseMessage SearchEmployeesByName()
        {
            try
            {
                var list = new List<RoleViewModelRequest>();

                foreach (var r in _roleRepository.GetAll())
                {
                    var model = new RoleViewModelRequest()
                    {
                        Id = r.Id,
                        RoleType = r.RoleType
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
