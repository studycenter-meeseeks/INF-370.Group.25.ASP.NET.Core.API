using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _25.Core.User;

namespace _25.Core.Payments
{
    public class MedicalAid
    {
        [Key]
        public int MedicalAidId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Option { get; set; }
        [Required]
        public string Number { get; set; }

        public virtual MedicalAidMainMember MainMember { get; set; }
        public virtual List<MedicalAidDependentMember> DependentMembers { get; set; }

        public virtual Patient Patient { get; set; }
        public int PatientId { get; set; }

        public MedicalAid()
        {
            DependentMembers = new List<MedicalAidDependentMember>();
        }
        
    }
}