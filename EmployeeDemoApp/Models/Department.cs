using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeDemoApp.Models
{
    public class Department
    {
        [Key]
        public Guid Id { get; set; } = new Guid();
        public string Name { get; set; }
        public string Code { get; set; }
        public virtual Employee Employee { get; set; }

    }
}