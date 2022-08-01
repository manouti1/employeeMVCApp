using EmployeeDemoApp.Data;
using EmployeeDemoApp.Interfaces;
using EmployeeDemoApp.Repositories;

namespace EmployeeDemoApp.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Employees = new EmployeeRepository(_context);
            Departments = new DepartmentRepository(_context);
            Positions = new PositionRepository(_context);
        }
        public IEmployeeRepository Employees { get; private set; }
        public IDepartmentRepository Departments { get; private set; }
        public IPositionRepository Positions { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
