using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using _25.Data.Context;
using _25.Data.Entities;
using _25.Services.Resources.Application;
using _25.Services.Services.Implementations;
using _25.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace INF_370.Group._25.ASP.NET.Core.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IApplicationService _applicationService;

        public ApplicationController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IApplicationService applicationService
        )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _applicationService = applicationService;
        }

        //[HttpGet("Roles")]
        //public ActionResult<IEnumerable<RolePrivilegesResource>> GetRoles()
        //{

        //    var roles = _roleManager.Roles
        //        .Include(item => item.SubSystemPermissions)
        //        .ThenInclude(subsystem => subsystem.Operations)
        //        .Select(item => new RolePrivilegesResource
        //        {
        //            Id = item.Id,
        //            RoleName = item.Name,
        //            RoleDescription = item.Description,
        //            Subsystems = item.SubSystemPermissions.Select(sub => new SubsystemResource
        //            {
        //                Id = sub.SubSystemId,
        //                Name = sub.Name,
        //                Privileges = sub.Operations.Select(operation => new OperationResource
        //                {
        //                    Id = operation.OperationId,
        //                    Name = operation.Name,
        //                    HasPermission = operation.HasPermission

        //                }).ToList()

        //            }).ToList()

        //        })
        //        .ToList();

        //    return roles;

        //}

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
        public ActionResult<IEnumerable<GetSubSystemResource>> GetSubSystems()
        {
            return _applicationService.GetAllSubSystems();
        }


    }
}
