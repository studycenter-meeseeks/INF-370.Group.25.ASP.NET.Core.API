using System.ComponentModel.DataAnnotations;
using _25.Core.System;

namespace _25.Core.User
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string EmployeeNumber { get; set; }
        [Required]
        public string IdNumber { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public virtual EmployeePhysicalAddress PhysicalAddress { get; set; }

        public virtual EmployeeType EmployeeType { get; set; }
        public int EmployeeTypeId { get; set; }

        public virtual Gender Gender { get; set; }
        public int GenderId { get; set; }
        public virtual Title Title { get; set; }
        public int TitleId { get; set; }

        public virtual Centre Centre { get; set; }
        public int CentreId { get; set; }

    }
}