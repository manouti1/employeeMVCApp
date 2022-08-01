using EmployeeDemoApp.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace EmployeeDemoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RolesController : ControllerBase
    {
        private readonly IRoleUtility _roleUtility;
        private readonly ILogger<RolesController> _logger;
            
        public RolesController(
        ILogger<RolesController> logger,
        IRoleUtility roleUtility
       )
        {
            _logger = logger;
            _roleUtility = roleUtility;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var roles = _roleUtility.PopulateRolesList();
            return Ok(roles);
        }
    }
}
