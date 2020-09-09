using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _25.Core.User
{
    public class LevelOfEducation
    {
        [Key]
        public int LevelOfEducationId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual List<Patient> Patients { get; set; }

        public LevelOfEducation()
        {
            Patients = new List<Patient>();
        }
    }
}