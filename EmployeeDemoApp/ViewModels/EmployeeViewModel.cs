using EmployeeDemoApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeDemoApp.ViewModels
{
    public class EmployeeViewModel : AddEmployeeViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required(ErrorMessage = "Date Of Birth is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage ="Joining Date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Joining Date")]
        public DateTime JoiningDate { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage ="Invalid email.")]
        public string Email { get; set; }
        public string UserName { get; set; }
        public new DropDownViewModel Position { get; set; }
        [Required(ErrorMessage = "Positions is required.")]
        public string[] SelectedPositions { get; set; }
        public new DropDownViewModel Department { get; set; }
        [Required(ErrorMessage = "Department is required.")]
        public string SelectedDepartment { get; set; }
        public DropDownViewModel? Role { get; set; }
        [Required(ErrorMessage = "Role is required.")]
        public string SelectedRole { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Minimum of 5 characters")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public string ProfilePic { get; set; }
    }

    public class DropDownViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<SelectListItem> ItemList { get; set; }
    }

    public class SelectedItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
