using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using _25.Data.Context;
using _25.Data.Entities;
using _25.Services.Resources.Application;
using _25.Services.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace INF_370.Group._25.ASP.NET.Core.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IApplicationService _applicationService;
        private readonly ApplicationDbContext _context;

        public ApplicationController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IApplicationService applicationService,
            ApplicationDbContext context
        )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _applicationService = applicationService;
            _context = context;
        }

        [HttpGet("Roles/GetAll")]
        public async Task<ActionResult<IEnumerable<RolePrivilegesResource>>> GetRoles()
        {

            var rolesFromDb = _roleManager.Roles.ToList();
            var subSystemsFromDb = _context.SubSystems.ToList();

            var rolesAndPrivileges = new List<RolePrivilegesResource>();
            var roleAndPrivileges = new RolePrivilegesResource();

            foreach (var role in rolesFromDb)
            {
                var roleClaims = await _roleManager.GetClaimsAsync(role);

                roleAndPrivileges.RoleName = role.Name;

                foreach (var currentSubSystem in subSystemsFromDb)
                {
                    var subSystem = new SubSystemResource
                    {
                        Id = currentSubSystem.SubSystemId,
                        Name = currentSubSystem.Name
                    };


                    foreach (var claim in roleClaims) //All Role Claims
                    {
                        
                        if (!currentSubSystem.Name.ToLower().Equals(claim.Type.ToLower())) continue;

                        var privilege = new PrivilegeResource {Name = claim.Value};
                        subSystem.Privileges.Add(privilege);
                    }

                    roleAndPrivileges.Subsystems.Add(subSystem);
                }


                rolesAndPrivileges.Add(roleAndPrivileges);

            }


            return rolesAndPrivileges;


        }

        [HttpPost("Roles/Create")]
        public async Task<IActionResult> AddRole(AddRoleAndPrivilegesResource model)
        {

            if (ModelState.IsValid)
            {
                var newRole = new IdentityRole
                {
                    Name = model.RoleName
                };

                await _roleManager.CreateAsync(newRole);
                var role = await _roleManager.FindByNameAsync(newRole.Name);

                foreach (var privilege in model.Privileges)
                {
                    // Bad memory management, please change when possible
                    var claim = new Claim(privilege.SubSystem, privilege.Operation + "-" + privilege.Value);
                    await _roleManager.AddClaimAsync(role, claim);
                }

                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("SubSystems/GetAll")]
        public ActionResult<IEnumerable<GetGenericNameAndIdResource>> GetSubSystems()
        {
            return _applicationService.GetAllSubSystems();
        }

        [HttpGet("Operations/GetAll")]
        public ActionResult<IEnumerable<GetGenericNameAndIdResource>> GetOperations()
        {
            return _applicationService.GetAllOperations();
        }


    }
}
