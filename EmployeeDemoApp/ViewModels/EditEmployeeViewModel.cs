using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeDemoApp.ViewModels
{
    public class EditEmployeeViewModel
    {
        public string DisplayFileName { get; set; }
        [Display(Name ="Profile Picture")]
        public string ExistingImage { get; set; }
        [Required(ErrorMessage = "Please fill positions")]
        [Display(Name = "Positions")]
        public string[] ExistingPositions { get; set; }
        [Required(ErrorMessage ="Please fill name.")]
        [Display(Name = "Name")]
        public string ExistingName { get; set; }
        [Required(ErrorMessage ="Please fill address.")]
        [Display(Name = "Address")]
        public string ExisitingAddress { get; set; }
        [Required(ErrorMessage ="Please fill joining date")]
        [Display(Name = "Joining Date")]
        public DateTime ExisitingJoiningDate { get; set; }
        [Required(ErrorMessage ="Department is required")]
        [Display(Name = "Department")]
        public string ExisitingDepartment { get; set; }
        [Required(ErrorMessage ="Please fill date of birth")]
        [Display(Name = "Date Of Birth")]
        public DateTime ExisitingDateOfBirth { get; set; }
        public string ExisitingUserName { get; set; }
        [Required(ErrorMessage ="Email is required")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string ExisitingEmail { get; set; }
        public List<SelectListItem> Position { get; set; }
        public List<SelectListItem> Department { get; set; }
        public IFormFile EmployeePicture { get; set; }

    }
}
