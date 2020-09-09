using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using _25.Data.Context;
using _25.Data.Entities;
using _25.Services.Extensions.System;
using _25.Services.Resources.User;
using _25.Services.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace INF_370.Group._25.ASP.NET.Core.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AccountController(
            ApplicationDbContext dbContext,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IUserService userService,
            IConfiguration configuration 
            )
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("Patient/Register")]
        [AllowAnonymous]
        public async Task<ActionResult> RegisterPatient([FromBody] RegisterPatientResource model)
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

                var newUser = new ApplicationUser()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.ContactNumber,
                };

                var result = await _userManager.CreateAsync(newUser, model.Password);
                if (result.Succeeded)
                {
                    var role = await _roleManager.FindByNameAsync("Patient".ToLower());
                    await _userManager.AddToRoleAsync(newUser, role.Name);

                    //var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
                    //var code = HttpUtility.UrlEncode(emailToken);
                    //var confirmLink = "https://hotsting_domain/api/account/confirmemail?userId=" + newUser.Id + "&token=" + code;
                    //Email.SendAccountConfirmationEmail(newUser.Email, newUser.UserName, confirmLink);

                    NotificationExtension.NewPatientAlert(newUser);

                    var token = GenerateJwtToken(newUser, role.Name);
                    return Ok(new { token });

                }
                message = "Something went wrong. Please try again.";
                return BadRequest(new { message });

            }
            message = "Something went wrong. Please try again.";
            return BadRequest(new { message });

        }

        [HttpPost("Psychologist/Add")]
        public async Task<ActionResult> AddPsychologist([FromBody] CreatePsychologistResource model)
        {

            var message = "";
            if (ModelState.IsValid)
            {

                var emailExists = await _userManager.FindByEmailAsync(model.EmailAddress);
                if (emailExists != null)
                {
                    message = "Account with provided email address  already exist.";
                    return BadRequest(new { message });
                }

                var psychologistWithContactNumberExists = _dbContext.Psychologists.Any(item => item.WorkContactNumber.Equals(model.WorkContactNumber));

                if (psychologistWithContactNumberExists)
                {
                    message = "An account with  the provided work contact number number already exist.";
                    return BadRequest(new { message });
                }


                var newUser = new ApplicationUser()
                {
                    UserName = model.EmailAddress,
                    Email = model.EmailAddress,
                    PhoneNumber = model.WorkContactNumber,
                };

                var assignedPassword = GenerateRandomPassword();
                var result = await _userManager.CreateAsync(newUser, assignedPassword);
                if (result.Succeeded)
                {
                    var role = await _roleManager.FindByNameAsync("psychologist".ToLower());
                    await _userManager.AddToRoleAsync(newUser, role.Name);
                    var created = _userService.AddPsychologist(model, assignedPassword);


                    var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
                    var code = HttpUtility.UrlEncode(emailToken);

                    //TODO: Once Deployed, Require Confirmed Email Address and Send Confirmation Link Via Email
                    //var confirmLink = "https://api_hosting_domain/api/account/confirmemail?userId=" + newUser.Id + "&token=" + code;

                    NotificationExtension.AddPsychologistNotification(created.PsychologistId);
                    return Ok();

                }
                message = "Something went wrong. Please try again.";
                return BadRequest(new { message });

            }
            message = "Something went wrong. Please try again.";
            return BadRequest(new { message });
        }

        [HttpGet("Psychologist/ResentAccountCreated/{psychologistId}")]
        public IActionResult ResendAccountCreatedEmailToPsychologist(int psychologistId)
        {
           
                NotificationExtension.ResentAddPsychologistNotification(psychologistId);
                return Ok();

        }

        public static string GenerateRandomPassword(PasswordOptions opts = null)
        {
            if (opts == null) opts = new PasswordOptions()
            {
                RequiredLength = 8,
                RequiredUniqueChars = 4,
                RequireDigit = true,
                RequireLowercase = true,
                RequireNonAlphanumeric = true,
                RequireUppercase = true
            };

            string[] randomChars = new[] {
                "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
                "abcdefghijkmnopqrstuvwxyz",    // lowercase
                "0123456789",                   // digits
                "!@$?_-"                        // non-alphanumeric
            };
            Random rand = new Random(Environment.TickCount);
            List<char> chars = new List<char>();

            if (opts.RequireUppercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[0][rand.Next(0, randomChars[0].Length)]);

            if (opts.RequireLowercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[1][rand.Next(0, randomChars[1].Length)]);

            if (opts.RequireDigit)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[2][rand.Next(0, randomChars[2].Length)]);

            if (opts.RequireNonAlphanumeric)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[3][rand.Next(0, randomChars[3].Length)]);

            for (int i = chars.Count; i < opts.RequiredLength
                                      || chars.Distinct().Count() < opts.RequiredUniqueChars; i++)
            {
                string rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count),
                    rcs[rand.Next(0, rcs.Length)]);
            }

            return new string(chars.ToArray());


        }

        private object GenerateJwtToken(ApplicationUser user,string userRole)
        {

            
            var claims = new List<Claim>
            {
                new Claim("UserName",user.UserName),
                new Claim("UserType",userRole),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
