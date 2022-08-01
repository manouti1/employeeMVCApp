using EmployeeDemoApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeDemoApp.Interfaces
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        Task<ServiceResponse<IEnumerable<Department>>> GetDepartments();
    }
}
