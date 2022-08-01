using EmployeeDemoApp.Data;
using EmployeeDemoApp.Interfaces;
using EmployeeDemoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDemoApp.Repositories
{
    public class PositionRepository : GenericRepository<Position>, IPositionRepository
    {
        public PositionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<ServiceResponse<IEnumerable<Position>>> GetPositions()
        {
            ServiceResponse<IEnumerable<Position>> response = new ServiceResponse<IEnumerable<Position>>();

            try
            {
                response.Data = _context.Position.OrderByDescending(d => d.Name).ToList();

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
