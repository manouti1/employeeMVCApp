using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeDemoApp.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; } = new Guid();
        [StringLength(150)]
        public string Name { get; set; }
        public Guid DepartmentId { get; set; }
        [Required(ErrorMessage ="Date Of Birth is required.")]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get;set; }
        [Required(ErrorMessage ="Joining Date is required.")]
        [Display(Name = "Joining Date")]
        public DateTime JoiningDate { get;set; }
        [Column("Address", TypeName = "ntext")]
        public string Address { get; set; }
        [StringLength(100)]
        [Display(Name = "Profile Picture")]
        public string ImageUrl { get; set; } = FileLocation.RetriveFileFromFolder + "blank.png";
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public virtual Department Department { get; set; }
        public ICollection<UserPosition> UserPositions { get; set; }


    }
}
