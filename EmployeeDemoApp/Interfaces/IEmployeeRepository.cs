using EmployeeDemoApp.Data;
using EmployeeDemoApp.DTO;
using EmployeeDemoApp.Enums;
using EmployeeDemoApp.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeDemoApp.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<ServiceResponse<IEnumerable<UserDataDTO>>> GetEmployees();
        Task<ServiceResponse<UserDataDTO>> FindById(Guid id);
        Task<ServiceResponse<UserDataDTO>> DeleteEmployee(Guid id, UserManager<User> userManager);

        Task<ServiceResponse<UserDataDTO>> UpdateEmployeeInformation(Guid id, UserDataDTO employee);
        Task<ServiceResponse<UserDataDTO>> CreateEmployee(UserManager<User> userManager, RoleManager<Role> roleManager, UserDataDTO userData);
    }
}
