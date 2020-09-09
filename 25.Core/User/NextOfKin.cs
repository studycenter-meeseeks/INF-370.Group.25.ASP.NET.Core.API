using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace _25.Core.User
{
    [Owned]
    public class NextOfKin
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string ContactNumber { get; set; }

    }
}