using EmployeeDemoApp.Data;
using EmployeeDemoApp.Interfaces;
using EmployeeDemoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDemoApp.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<ServiceResponse<IEnumerable<Department>>> GetDepartments()
        {
            ServiceResponse<IEnumerable<Department>> response = new ServiceResponse<IEnumerable<Department>>();

            try
            {
                response.Data = _context.Department.OrderByDescending(d => d.Id).ToList();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
