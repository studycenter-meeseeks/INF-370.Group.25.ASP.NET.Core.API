using System.ComponentModel.DataAnnotations;

namespace _25.Core.User
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdNumber { get; set; }
        public PhysicalAddress PhysicalAddress { get; set; }

        public virtual EmployeeType EmployeeType { get; set; }
        public int EmployeeTypeId { get; set; }

    }
}