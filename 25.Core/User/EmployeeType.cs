using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _25.Core.User
{
    /// <summary>
    /// An employee can either be admin, psychologist or  any other new employee type that can be added at a later stage. 
    /// </summary>
    public class EmployeeType
    {
        [Key]
        public int EmployeeTypeId { get; set; }
        [Required]
        public string Description { get; set; }

        public List<Employee> Employees { get; set; }

        public EmployeeType()
        {
            Employees = new List<Employee>();
        }
    }
}