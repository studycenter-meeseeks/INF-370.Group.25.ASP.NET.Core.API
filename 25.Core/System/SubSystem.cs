using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _25.Core.System
{
    public class SubSystem
    {
        [Key]
        public int SubSystemId { get; set; }
        [Required]
        public string Name { get; set; }
       
    }
}