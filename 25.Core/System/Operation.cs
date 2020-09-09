using System.ComponentModel.DataAnnotations;

namespace _25.Core.System
{
    public class Operation
    {
        [Key]
        public int OperationId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}