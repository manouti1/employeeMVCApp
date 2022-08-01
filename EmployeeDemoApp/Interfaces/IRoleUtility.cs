using EmployeeDemoApp.Data;
using System.Collections.Generic;

namespace EmployeeDemoApp.Interfaces
{
    public interface IRoleUtility
    {
        IEnumerable<Role> PopulateRolesList();
    }
}
