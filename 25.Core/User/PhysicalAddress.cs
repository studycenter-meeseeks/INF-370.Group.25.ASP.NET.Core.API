using Microsoft.EntityFrameworkCore;

namespace _25.Core.User
{
    [Owned]
    public class PhysicalAddress
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string CityOrTown { get; set; }
        public string Province { get; set; }
        public string ZipCode { get; set; }
    }
}