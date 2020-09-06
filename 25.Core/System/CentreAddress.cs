using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace _25.Core.System
{
    [Owned]
    public class CentreAddress
    {
        [Required]
        public string Line1 { get; set; }
        //Optional
        public string Line2 { get; set; }
        [Required]
        public string CityOrTown { get; set; }
        [Required]
        public string Province { get; set; }
        [Required]
        public string ZipCode { get; set; }
    }
}