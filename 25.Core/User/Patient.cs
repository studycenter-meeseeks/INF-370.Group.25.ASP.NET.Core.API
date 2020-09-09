using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _25.Core.Payments;

namespace _25.Core.User
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Required]
        public string Number { get; set; } //System Generated

        [Required]
        public string Name { get; set; } //First Form

        [Required]
        public string ContactNumber { get; set; } //First Form

        [Required]
        public string Surname { get; set; } //First Form

        [Required]
        public string EmailAddress { get; set; } //First Form


        [Required]
        public string IdNumber { get; set; } //Second Form
        [Required]
        public string Occupation { get; set; } //Second Form


        public virtual Gender Gender { get; set; } //Second Form
        public int GenderId { get; set; }

        public virtual LevelOfEducation LevelOfEducation { get; set; } //Second Form
        public int LevelOfEducationId { get; set; }

        public virtual HomeLanguage HomeLanguage { get; set; } //Second Form
        public int HomeLanguageId { get; set; }

        public virtual Title Title { get; set; } //Second Form
        public int TitleId { get; set; }



        [Required]
        public virtual PatientPhysicalAddress PhysicalAddress { get; set; } //Third form
        //Optional
        public virtual LegalGuardian LegalGuardian { get; set; } //Third form
        //Optional
        public virtual NextOfKin NextOfKin { get; set; } //Third form




        //optional
        public string ContactNumberWork { get; set; } //Fourth Form
        //optional
        public string ContactNumberHome { get; set; } //Fourth Form
        public virtual List<MedicalAid> MedicalAids { get; set; } //Fourth Form



        public Patient()
        {
            MedicalAids = new List<MedicalAid>();
        }

    }
}