using System.ComponentModel.DataAnnotations;

namespace _25.Core.User
{
    public class PsychologistQualification
    {
        [Key]
        public int PsychologistQualificationId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual Psychologist Psychologist { get; set; }
        public int PsychologistId { get; set; }

    }
}