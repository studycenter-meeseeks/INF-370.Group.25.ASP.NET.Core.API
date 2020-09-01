using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _25.Core.User
{
    public class HomeLanguage
    {
        [Key]
        public int HomeLanguageId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual List<Patient> Patients { get; set; }

        public HomeLanguage()
        {
            Patients = new List<Patient>();
        }
    }
}