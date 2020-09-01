using System.ComponentModel.DataAnnotations;

namespace _25.Core.System
{
    public class AuditLog
    {
        [Key]
        public int AuditLogId { get; set; }
        [Required]
        public string Who { get; set; }
        [Required]
        private string What { get; set; }
        [Required]
        private string When { get; set; }
    }
}