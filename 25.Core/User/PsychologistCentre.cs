using System.ComponentModel.DataAnnotations;
using _25.Core.System;

namespace _25.Core.User
{
    public class PsychologistCentre
    {
        public virtual Centre Centre { get; set; }
        public int CentreId { get; set; }

        public virtual Psychologist Psychologist { get; set; }
        public int PsychologistId { get; set; }
    }
}