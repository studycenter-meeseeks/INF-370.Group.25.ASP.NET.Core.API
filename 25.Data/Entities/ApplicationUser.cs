using Microsoft.AspNetCore.Identity;

namespace _25.Data.Entities
{
    public class ApplicationUser:IdentityUser
    {
        //If there is a need to extent IdentityUser
        public bool IsActive { get; set; }
    }
}