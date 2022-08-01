using EmployeeDemoApp.Models;
using System;
using System.Collections.Generic;

namespace EmployeeDemoApp.DTO
{
    public class EmployeeDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid DepartmentId { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Address { get; set; }
        public string ProfilePic { get; set; }
        public IEnumerable<string> Positions { get; set; }
        public IEnumerable<string> PositionIds { get; set; }
    }
}