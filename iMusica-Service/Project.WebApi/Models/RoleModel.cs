using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WebApi.Models
{
    public class RoleViewModelRequest
    {
        public Guid Id { get; set; }
        public string RoleType { get; set; }
    }
}