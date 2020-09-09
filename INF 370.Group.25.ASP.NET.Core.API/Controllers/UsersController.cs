using System.Collections.Generic;
using _25.Data.Context;
using _25.Services.Resources.User;
using _25.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace INF_370.Group._25.ASP.NET.Core.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ApplicationDbContext _context;

        public UsersController(IUserService userService,ApplicationDbContext context)
        {
            _userService = userService;
            _context = context;
        }

        [HttpGet("Psychologists/GetAll")]
        public ActionResult<IEnumerable<GetPsychologistResource>> GetPsychologists()
        {

            return _userService.GetPsychologists();
        }
    }
}
