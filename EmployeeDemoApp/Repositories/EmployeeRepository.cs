using EmployeeDemoApp.Data;
using EmployeeDemoApp.DTO;
using EmployeeDemoApp.Enums;
using EmployeeDemoApp.Interfaces;
using EmployeeDemoApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDemoApp.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
        }


        public async Task<ServiceResponse<IEnumerable<UserDataDTO>>> GetEmployees()
        {
            ServiceResponse<IEnumerable<UserDataDTO>> response = new ServiceResponse<IEnumerable<UserDataDTO>>();

            try
            {
                var employeeData = await Task.Run(() => _context.Employee.Include(e => e.Department)
                                           .Include(e => e.User)
                                           .Include(e => e.UserPositions)
                                           .OrderByDescending(d => d.Id)
                                           .ToListAsync());
                List<UserDataDTO> dto = new List<UserDataDTO>();
                foreach (var x in employeeData)
                {
                    var positions = _context.Position.Where(a => x.UserPositions.Select(p => p.PositionId).Contains(a.Id))
                                                    .Select(p => p.Name)
                                                    .ToList();
                    dto.Add(new UserDataDTO
                    {
                        EmployeeInfo = new EmployeeDTO
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Address = x.Address,
                            DateOfBirth = x.DateOfBirth,
                            DepartmentCode = x.Department.Code,
                            DepartmentId = x.DepartmentId,
                            ProfilePic = x.ImageUrl,
                            JoiningDate = x.JoiningDate,
                            DepartmentName = x.Department.Name,
                            Positions = positions
                        },
                        Email = x.User.Email,
                        UserName = x.User.UserName,
                    });
                }

                response.Data = dto;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
        public async Task<ServiceResponse<UserDataDTO>> FindById(Guid id)
        {
            ServiceResponse<UserDataDTO> response = new ServiceResponse<UserDataDTO>();

            try
            {
                if (id == null)
                {
                    response.Success = false;
                    response.Message = "Not Found";
                    return response;
                }

                var employee = await Task.Run(() => _context.Employee
                    .Include(e => e.Department)
                    .Include(e => e.User)
                    .Include(e => e.UserPositions)
                    .FirstOrDefault(m => m.Id == id));


                if (employee == null)
                {
                    response.Success = false;
                    response.Message = "Not Found";
                    return response;
                }


                //var positions = _context.Position.Select(x =>
                //{
                //    var userPositions = employee.UserPositions.Where(a => a.PositionId == x.Id);
                //});

                response.Data = new UserDataDTO
                {
                    EmployeeInfo = new EmployeeDTO
                    {
                        Id = employee.Id,
                        Name = employee.Name,
                        Address = employee.Address,
                        DateOfBirth = employee.DateOfBirth,
                        DepartmentId = employee.DepartmentId,
                        DepartmentCode = employee.Department.Code,
                        ProfilePic = employee.ImageUrl,
                        JoiningDate = employee.JoiningDate,
                        DepartmentName = employee.Department.Name,
                        PositionIds = employee.UserPositions.Select(x => x.PositionId.ToString()),
                        Positions = employee.UserPositions.Select(x => x.Position.Name)
                    },
                    Email = employee.User.Email,
                    UserName = employee.User.UserName,
                };

                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;

        }

        public async Task<ServiceResponse<UserDataDTO>> DeleteEmployee(Guid id, UserManager<User> userManager)
        {
            ServiceResponse<UserDataDTO> response = new ServiceResponse<UserDataDTO>();
            var currentImage = "";
            try
            {
                if (id == null)
                {
                    response.Success = false;
                    response.Message = "Not Found";
                    return response;
                }

                var employee = _context.Employee.Include(e => e.User).Include(e => e.UserPositions)
                                                 .Where(m => m.Id == id).FirstOrDefault();

                if (employee == null)
                {
                    response.Success = false;
                    response.Message = "Not Found";
                    return response;
                }
                currentImage = Path.Combine(Directory.GetCurrentDirectory(), FileLocation.DeleteFileFromFolder, employee.ImageUrl);

                await RemoveUser(employee.User.Email, userManager);
                _context.UserPosition.RemoveRange(employee.UserPositions);
                _context.UserPosition.UpdateRange(employee.UserPositions);

                _context.Employee.Remove(employee);


                if (await _context.SaveChangesAsync() > 0)
                {
                    if (File.Exists(currentImage))
                    {
                        File.Delete(currentImage);
                    }
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                foreach (var entry in ex.Entries)
                {
                    if (entry.Entity is UserPosition)
                    {
                        var proposedValues = entry.CurrentValues;
                        var databaseValues = entry.GetDatabaseValues();
                        if (databaseValues != null)
                        {
                            foreach (var property in proposedValues.Properties)
                            {
                                var proposedValue = proposedValues[property];
                                var databaseValue = databaseValues[property];

                                // TODO: decide which value should be written to database
                                proposedValues[property] = databaseValue;
                            }
                            // Refresh original values to bypass next concurrency check
                            entry.OriginalValues.SetValues(databaseValues);
                        }
                        else
                        {
                            if (File.Exists(currentImage))
                            {
                                File.Delete(currentImage);
                            }

                            response.Success = true;
                            return response;
                        }
                      
                    }
                    else
                    {
                        throw new NotSupportedException(
                            "Don't know how to handle concurrency conflicts for "
                            + entry.Metadata.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<UserDataDTO>> UpdateEmployeeInformation(Guid id, UserDataDTO employee)
        {
            ServiceResponse<UserDataDTO> response = new ServiceResponse<UserDataDTO>();

            try
            {

                if (id != employee.EmployeeInfo.Id)
                {
                    response.Success = false;
                    response.Message = "Not Found";
                    return response;
                }


                try
                {
                    var emp = await _context.Employee.FindAsync(id);

                    emp.JoiningDate = employee.EmployeeInfo.JoiningDate;
                    emp.DateOfBirth = employee.EmployeeInfo.DateOfBirth;
                    emp.Name = employee.EmployeeInfo.Name;
                    emp.Address = employee.EmployeeInfo.Address;
                    emp.DepartmentId = employee.EmployeeInfo.DepartmentId;
                    emp.ImageUrl = employee.EmployeeInfo.ProfilePic;

                    foreach (var item in employee.EmployeeInfo.Positions)
                    {
                        emp.UserPositions = new List<UserPosition>()
                        {
                            new UserPosition(emp.Id,Guid.Parse(item))
                        };
                    }

                    _context.UserPosition.UpdateRange(emp.UserPositions);

                    _context.Update(emp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!EmployeeExists(employee.EmployeeInfo.Id))
                    {
                        response.Success = false;
                        response.Message = "Not Found";
                        return response;
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = ex.Message;
                    }
                }

                response.Data = new UserDataDTO
                {
                    EmployeeInfo = new EmployeeDTO
                    {
                        DepartmentId = employee.EmployeeInfo.DepartmentId,
                        Id = employee.EmployeeInfo.Id,
                        Address = employee.EmployeeInfo.Address,
                        DateOfBirth = employee.EmployeeInfo.DateOfBirth,
                        DepartmentCode = employee.EmployeeInfo.DepartmentCode,
                        DepartmentName = employee.EmployeeInfo.DepartmentName,
                        Name = employee.EmployeeInfo.Name,
                        JoiningDate = employee.EmployeeInfo.JoiningDate,
                        Positions = employee.EmployeeInfo.Positions,
                        ProfilePic = employee.EmployeeInfo.ProfilePic,
                    },
                    Email = employee.Email,
                    UserName = employee.UserName
                };
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
        public async Task<ServiceResponse<UserDataDTO>> CreateEmployee(UserManager<User> userManager, RoleManager<Role> roleManager, UserDataDTO userData)
        {
            ServiceResponse<UserDataDTO> response = new ServiceResponse<UserDataDTO>();

            try
            {
                var user = userManager.FindByEmailAsync(userData.Email);
                if (user.Result == null)
                {
                    var defaultUser = new User
                    {
                        UserName = userData.Email,
                        Email = userData.Email,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true
                    };

                    await userManager.CreateAsync(defaultUser);


                    await userManager.CreateAsync(defaultUser, userData.Password);
                    await userManager.AddToRoleAsync(defaultUser, userData.Role);
                    var employeeId = userData.EmployeeInfo.Id;
                    var userPositions = new List<UserPosition>();
                    foreach (var item in userData.EmployeeInfo.Positions)
                    {
                        userPositions.Add(new UserPosition(employeeId, Guid.Parse(item)));
                    }

                    _context.UserPosition.AddRange(userPositions);

                    var employee = new Employee
                    {
                        Id = employeeId,
                        Address = userData.EmployeeInfo.Address,
                        DateOfBirth = userData.EmployeeInfo.DateOfBirth,
                        DepartmentId = userData.EmployeeInfo.DepartmentId,
                        ImageUrl = userData.EmployeeInfo.ProfilePic,
                        JoiningDate = userData.EmployeeInfo.JoiningDate,
                        Name = userData.EmployeeInfo.Name,
                        UserPositions = userPositions,
                        UserId = defaultUser.Id
                    };
                    _context.Add(employee);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    response.Success = false;
                    response.Message = "User Already exists";
                }

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Something went wrong while creating employee!";
            }

            return response;
        }

        private async Task RemoveUser(string email, UserManager<User> userManager)
        {
            var user = await userManager.FindByEmailAsync(email);
            var roles = await userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                await userManager.RemoveFromRoleAsync(user, role);

            }
            await userManager.DeleteAsync(user);
        }
        private bool EmployeeExists(Guid id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }

    }
}
