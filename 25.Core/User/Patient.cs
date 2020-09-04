using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _25.Core.Payments;
using Microsoft.VisualBasic;

namespace _25.Core.User
{
    public class Patient
    {
        [Key]
         public int PatientId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string IdNumber { get; set; }

        [Required]
        public string ContactNumber { get; set; }

        [Required] 
        public string EmailAddress { get; set; }
        //optional
        public string ContactNumberWork { get; set; }
        //optional
        public string ContactNumberHome { get; set; }

        [Required]
        public string Occupation { get; set; }
        
        [Required]
        public virtual PatientPhysicalAddress PhysicalAddress { get; set; }
        //Optional
        public virtual LegalGuardian LegalGuardian { get; set; }
        //Optional
        public virtual NextOfKin NextOfKin { get; set; }

        public virtual Gender Gender { get; set; }
        public int GenderId { get; set; }

        public virtual LevelOfEducation LevelOfEducation { get; set; }
        public int LevelOfEducationId { get; set; }

        public virtual HomeLanguage HomeLanguage { get; set; }
        public int HomeLanguageId { get; set; }

        public virtual Title Title { get; set; }
        public int TitleId { get; set; }

        public virtual List<MedicalAid> MedicalAids { get; set; }

        public Patient()
        {
            MedicalAids = new List<MedicalAid>();
        }

    }
}