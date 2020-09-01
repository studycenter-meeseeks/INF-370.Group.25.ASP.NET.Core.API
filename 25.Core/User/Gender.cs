using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _25.Core.User
{
    public class Gender
    {
        [Key]
        public int GenderId { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual List<Patient> Patients { get; set; }
        public virtual List<Employee> Employees { get; set; }

        public Gender()
        {
            Patients = new List<Patient>();
            Employees = new List<Employee>();
        }

    }
}