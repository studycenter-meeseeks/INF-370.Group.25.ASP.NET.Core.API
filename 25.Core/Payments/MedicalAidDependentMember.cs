using System.ComponentModel.DataAnnotations;
using _25.Core.User;
using Microsoft.EntityFrameworkCore;

namespace _25.Core.Payments
{
    public class MedicalAidDependentMember
    {
        [Key]
        public int MedicalAidDependentMemberId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string IdNumber { get; set; }
      
    }
}