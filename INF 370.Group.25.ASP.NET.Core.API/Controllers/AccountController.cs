using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using _25.Data.Context;
using _25.Data.Entities;
using _25.Services.Resources.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace INF_370.Group._25.ASP.NET.Core.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(
            ApplicationDbContext dbContext,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost("Patient/SignUp")]
        [AllowAnonymous]
        public async Task<ActionResult> RegisterPatient([FromBody] RegisterUserResource model)
        {
            var message = "";
            if (ModelState.IsValid)
            {

                var emailExists = await _userManager.FindByEmailAsync(model.Email);
                if (emailExists != null)
                {
                    message = "Account with provided email address  already exist.";
                    return BadRequest(new { message });
                }

                var patientWithContactNumberExists = _dbContext.Patients.Any(item => item.ContactNumber.Equals(model.ContactNumber));

                if (patientWithContactNumberExists)
                {
                    message = "An account with  the provided cell phone number already exist.";
                    return BadRequest(new { message });
                }

                var employeeWithContactNumberExists = _dbContext.Employees.Any(item => item.ContactNumber.Equals(model.ContactNumber));

                if (employeeWithContactNumberExists)
                {
                    message = "An account with  the provided cell phone number already exist.";
                    return BadRequest(new { message });
                }

                var newUser = new ApplicationUser()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.ContactNumber,
                };

                var result = await _userManager.CreateAsync(newUser, model.Password);
                if (result.Succeeded)
                {
                    //await _userManager.AddToRoleAsync(newUser, "User");
                    //var created = _userService.RegisterUser(model, assignedNumber);

                    //var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
                    //var code = HttpUtility.UrlEncode(emailToken);
                    //var confirmLink = "https://api.studycenter.co.za/api/v2/account/confirmemail?userId=" + newUser.Id + "&token=" + code;
                    //Email.SendAccountConfirmationEmail(newUser.Email, newUser.UserName, confirmLink);
                    //NotificationExtenstion.NewUserAlert();

                    //var token = GenerateJwtToken(newUser);
                    //return Ok(new { token });

                }
                message = "Something went wrong. Please try again.";
                return BadRequest(new { message });

            }
            message = "Something went wrong. Please try again.";
            return BadRequest(new { message });

        }

       
    }
}
