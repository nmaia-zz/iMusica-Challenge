using Project.Entities;
using System;
using System.Collections.Generic;

namespace Project.WebApi.Models
{
    public class EmployeeViewModelRegister
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public string RoleType { get; set; }
        public Guid IdRole { get; set; }
        public IList<string> Dependents { get; set; }
    }

    public class EmployeeViewModelEdition
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public string RoleType { get; set; }
        public Guid IdRole { get; set; }
        public IList<string> Dependents { get; set; }
    }

    public class EmployeeViewModelRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string BirthDate { get; set; }
        public string RoleType { get; set; }        
        public int DependentsQuantity { get; set; }
    }
}