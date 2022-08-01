using EmployeeDemoApp.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeDemoApp.ViewModels
{
    public class AddEmployeeViewModel
    {
        [Required]
        [Display(Name = "Profile Picture")]
        public IFormFile EmployeePicture { get; set; }
       

    }
}
