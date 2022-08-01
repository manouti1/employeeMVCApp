using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeDemoApp.ViewModels
{
    public class EditEmployeeViewModel 
    {
        [Display(Name = "Picture")]
        public string ExistingImage { get; set; }
        [Required]
        [Display(Name = "Positions")]
        public string[] ExistingPositions { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string ExistingName { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string ExisitingAddress { get; set; }
        [Required]
        [Display(Name = "Joining Date")]
        public DateTime ExisitingJoiningDate { get; set; }
        [Required]
        [Display(Name = "Department")]
        public string ExisitingDepartment { get; set; }
        [Required]
        [Display(Name = "Date Of Birth")]
        public DateTime ExisitingDateOfBirth { get; set; }
        public string ExisitingUserName { get; set; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string ExisitingEmail { get; set; }
        public List<SelectListItem> Position { get; set; }
        public List<SelectListItem> Department { get; set; }
        [Required]
        [Display(Name = "Profile Picture")]
        public IFormFile EmployeePicture { get; set; }
       
    }
}
