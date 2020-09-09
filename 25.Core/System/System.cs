using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _25.Core.System
{
    public class System
    {
        [Key]
        public int SystemId { get; set; }

        [Required]
        public string Name { get; set; }

    }
}