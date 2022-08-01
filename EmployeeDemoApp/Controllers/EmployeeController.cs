using EmployeeDemoApp.Data;
using EmployeeDemoApp.Interfaces;
using EmployeeDemoApp.Models;
using EmployeeDemoApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDemoApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IWebHostEnvironment _env;
        private readonly IRoleUtility _roleUtility;

        public EmployeeController(ILogger<EmployeeController> logger,
                                  IUnitOfWork unitOfWork,
                                  UserManager<User> userManager,
                                  RoleManager<Role> roleManager,
                                  IRoleUtility roleUtility,
                                  IWebHostEnvironment env)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _roleManager = roleManager;
            _env = env;
            _roleUtility = roleUtility;
        }

        [Authorize(Roles = "Admin,HR")]
        public async Task<IActionResult> Index()
        {
            var employees = await _unitOfWork.Employees.GetEmployees();
            var list = employees.Data.Select(x => new EmployeeViewModel
            {
                Id = x.EmployeeInfo.Id,
                Name = x.EmployeeInfo.Name,
                Address = x.EmployeeInfo.Address,
                Email = x.Email,
                DateOfBirth = x.EmployeeInfo.DateOfBirth,
                JoiningDate = x.EmployeeInfo.JoiningDate,
                ProfilePic = FileLocation.RetriveFileFromFolder + x.EmployeeInfo.ProfilePic,
                SelectedDepartment = x.EmployeeInfo.DepartmentName

            });
            return View(list);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,HR")]
        public ActionResult SetViewData(string value)
        {
            ViewData["GridInfo"] = value;
            return new EmptyResult();
        }

        [Authorize(Roles = "Admin,HR,Basic")]
        public async Task<IActionResult> Details(Guid id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var user = await _unitOfWork.Employees.FindById(id);
            var employeeDetails = user.Data.EmployeeInfo;
            var employeeViewModel = new EditEmployeeViewModel()
            {
                ExistingName = employeeDetails.Name,
                ExistingPositions = employeeDetails.PositionIds.ToArray(),
                ExisitingAddress = employeeDetails.Address,
                ExisitingJoiningDate = employeeDetails.JoiningDate,
                ExisitingDepartment = employeeDetails.DepartmentId.ToString(),
                ExisitingEmail = user.Data.Email,
                ExisitingUserName = user.Data.Email,
                ExisitingDateOfBirth = employeeDetails.DateOfBirth,
                ExistingImage = Path.Combine(Path.Combine(_env.WebRootPath, FileLocation.FileUploadFolder), employeeDetails.ProfilePic),
            };

            await FillFormData(null, employeeViewModel);

            if (user == null)
            {
                return NotFound();
            }
            if (employeeViewModel != null)
                return View(employeeViewModel);
            else
                return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,HR,Basic")]
        public async Task<IActionResult> Details(Guid id, EditEmployeeViewModel model)
        {
            await FillFormData(null, model);


            if (ModelState.IsValid)
            {
                if (model.EmployeePicture != null)
                {
                    if (model.ExistingImage != null)
                    {
                        string filePath = Path.Combine(_env.WebRootPath, FileLocation.FileUploadFolder, model.ExistingImage);
                        System.IO.File.Delete(filePath);
                    }
                }

                var employee = await _unitOfWork.Employees.UpdateEmployeeInformation(id, new DTO.UserDataDTO
                {
                    Email = model.ExisitingEmail,
                    //    Role = model.Role,
                    UserName = model.ExisitingEmail,
                    EmployeeInfo = new DTO.EmployeeDTO
                    {
                        Id = id,
                        Address = model.ExisitingAddress,
                        DateOfBirth = model.ExisitingDateOfBirth,
                        // DepartmentCode = model.DepartmentCode,
                        // DepartmentId = Guid.Parse(model.DepartmentId),
                        DepartmentId = Guid.Parse(model.ExisitingDepartment),
                        JoiningDate = model.ExisitingJoiningDate,
                        Name = model.ExistingName,
                        ProfilePic = model.ExistingImage,
                        Positions = model.ExistingPositions
                    }
                });



                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        //[Authorize(Roles = "Admin,HR")]
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var employee = await _unitOfWork.Employees.FindById(id);
        //    var employeeData = employee.Data.EmployeeInfo;
        //    var employeeViewModel = new EmployeeViewModel()
        //    {
        //        Id = employeeData.Id,
        //        Address = employeeData.Address,
        //        Name = employeeData.Name,
        //        //        DepartmentId = employeeData.DepartmentId.ToString(),
        //        ExistingImage = employeeData.ProfilePic
        //    };
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(employeeViewModel);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,HR")]
        public async Task<IActionResult> Delete([FromQuery]string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _unitOfWork.Employees.DeleteEmployee(Guid.Parse(id), _userManager);

            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin,HR")]
        public async Task<IActionResult> Create()
        {

            EmployeeViewModel empModel = new EmployeeViewModel();
            await FillFormData(empModel);
            empModel.JoiningDate = DateTime.Now;
            empModel.DateOfBirth = DateTime.Now;
            return View(empModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel model)
        {
            await FillFormData(model);

            ViewBag.Message = "";
            if (ModelState.IsValid)
            {
                var empID = Guid.NewGuid();
                var fileName = ProcessUploadedFile(model.EmployeePicture.FileName).Item3;
                var role = model.Role.ItemList.Find(x => x.Value == model.SelectedRole).Text;
                var result = await _unitOfWork.Employees.CreateEmployee(_userManager, _roleManager, new DTO.UserDataDTO
                {
                    Email = model.Email,
                    Password = model.Password,
                    Role = role,
                    UserName = model.UserName,
                    EmployeeInfo = new DTO.EmployeeDTO
                    {
                        Id = empID,
                        Address = model.Address,
                        DateOfBirth = model.DateOfBirth,
                        DepartmentId = Guid.Parse(model.SelectedDepartment),
                        JoiningDate = model.JoiningDate,
                        Name = model.Name,
                        ProfilePic = fileName,
                        Positions = model.SelectedPositions
                    }
                });



                if (result.Success == false)
                {
                    ViewBag.Message = result.Message;
                    return View(model);
                }
                else
                {
                    CopyFileToPhyscialDrive(fileName, model);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private Tuple<string, string, string> ProcessUploadedFile(string fileName)
        {
            string uniqueFileName = null;
            string filePath = null;
            string uploadsFolder = null;
            if (fileName != null)
            {
                uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                uploadsFolder = Path.Combine(_env.WebRootPath, FileLocation.FileUploadFolder);

                filePath = Path.Combine(uploadsFolder, uniqueFileName);
            }

            return Tuple.Create(uploadsFolder, filePath, uniqueFileName);
        }

        private void CopyFileToPhyscialDrive(string filePath, EmployeeViewModel model)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                model.EmployeePicture.CopyTo(fileStream);
            }
        }
        private async Task FillFormData(EmployeeViewModel empModel = null, EditEmployeeViewModel editModel = null)
        {
            var positions = await _unitOfWork.Positions.GetPositions();
            var p = positions.Data.Select(x => new DropDownViewModel
            {
                Id = x.Id.ToString(),
                Name = x.Name
            });

            DropDownViewModel positionModel = new DropDownViewModel();
            positionModel.ItemList = p.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();

            var roles = _roleUtility.PopulateRolesList().Select(x => new DropDownViewModel
            {
                Id = x.Id.ToString(),
                Name = x.Name
            });

            DropDownViewModel roleModel = new DropDownViewModel();
            roleModel.ItemList = roles.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();

            var departments = await _unitOfWork.Departments.GetDepartments();
            var d = departments.Data.Select(x => new DropDownViewModel
            {
                Id = x.Id.ToString(),
                Name = x.Name
            });

            DropDownViewModel departmentModel = new DropDownViewModel();
            departmentModel.ItemList = d.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            if (empModel != null)
            {
                empModel.Position = positionModel;
                empModel.Role = roleModel;
                empModel.Department = departmentModel;
            }
            else
            {

                editModel.Position = positions.Data.Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.Id.ToString(),
                                      Text = a.Name
                                  }).ToList();
                editModel.Department = departments.Data.Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.Id.ToString(),
                                      Text = a.Name
                                  }).ToList();
            }

        }
    }
}
