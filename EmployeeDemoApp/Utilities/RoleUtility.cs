using EmployeeDemoApp.Data;
using EmployeeDemoApp.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeDemoApp.Utilities
{
    public class RoleUtility : IRoleUtility
    {
        private readonly RoleManager<Role> _roleManager;

        public RoleUtility(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public IEnumerable<Role> PopulateRolesList()
        {
           return _roleManager.Roles?.ToList();
        }
    }
}
