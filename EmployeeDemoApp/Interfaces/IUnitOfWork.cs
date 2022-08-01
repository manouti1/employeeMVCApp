using System;

namespace EmployeeDemoApp.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employees { get; }
        IDepartmentRepository Departments { get; }
        IPositionRepository Positions { get; }
        int Complete();
    }
}
