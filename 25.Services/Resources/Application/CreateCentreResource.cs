using System.ComponentModel.DataAnnotations;

namespace _25.Services.Resources.Application
{
    public class CreateCentreResource
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required]
        public string AddressCityOrTown { get; set; }
        [Required]
        public string Province { get; set; }
        [Required]
        public string ZipCode { get; set; }
    }
}