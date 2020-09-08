using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _25.Core.User;

namespace _25.Core.System
{
    public class Centre
    {
        [Key]
        public int CentreId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual CentreAddress Address { get; set; }

        public virtual List<PsychologistCentre> Psychologists { get; set; }
        public virtual List<Employee> Employees { get; set; }

        public Centre()
        {
            Psychologists = new List<PsychologistCentre>();
            Employees = new List<Employee>();
        }

    }
}