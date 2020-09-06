using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _25.Core.User
{
    public class Psychologist
    {
        [Key]
        public int PsychologistId { get; set; }
        [Required]
        public string PracticeNo { get; set; }
        [Required]
        public string HPCSANo { get; set; }

        [Required]
        public string FullName { get; set; }
        public string About { get; set; }
        [Required]
        public string PracticeTitle { get; set; }
        [Required]
        public string WorkContactNumber { get; set; }
        [Required]
        public string CellContactNumber { get; set; }
        [Required]
        public string EmailAddress { get; set; }

        public virtual List<PsychologistQualification> Qualifications { get; set; }
        public virtual List<PsychologistService> Services { get; set; }

        public Psychologist()
        {
            Qualifications =new List<PsychologistQualification>();
            Services = new List<PsychologistService>();
        }

    }
}