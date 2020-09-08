using _25.Core.User;
using _25.Data.Context;
using _25.Services.Resources.User;
using _25.Services.Services.Interfaces;

namespace _25.Services.Services.Implementations
{
    public class UserService:IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }


        public Psychologist AddPsychologist(CreatePsychologistResource resource)
        {
            throw new System.NotImplementedException();
        }
    }
}