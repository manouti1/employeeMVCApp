using Microsoft.AspNetCore.Identity;
using System;

namespace EmployeeDemoApp.Data
{
    public class Role : IdentityRole<Guid>
    {
        public Role(string Name) : base(Name)
        {
        }
    }

}