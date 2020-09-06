﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _25.Core.System;

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

        public virtual Centre Centre { get; set; }
        public int CentreId { get; set; }
        public virtual Gender Gender { get; set; }
        public int GenderId { get; set; }
        public virtual Title Title { get; set; }
        public int TitleId { get; set; }

        public virtual List<PsychologistQualification> Qualifications { get; set; }
        public virtual List<PsychologistService> Services { get; set; }

        public Psychologist()
        {
            Qualifications =new List<PsychologistQualification>();
            Services = new List<PsychologistService>();
        }

    }
}