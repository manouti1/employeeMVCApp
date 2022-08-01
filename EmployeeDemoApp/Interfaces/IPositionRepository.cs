using EmployeeDemoApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeDemoApp.Interfaces
{
    public interface IPositionRepository : IGenericRepository<Position>
    {
        Task<ServiceResponse<IEnumerable<Position>>> GetPositions();
    }
}
