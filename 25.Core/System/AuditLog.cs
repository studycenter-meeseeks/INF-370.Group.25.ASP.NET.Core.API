using System;
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
        public string What { get; set; }
        [Required]
        public DateTime When { get; set; }
    }
}