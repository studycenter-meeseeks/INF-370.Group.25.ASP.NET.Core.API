using System.Collections.Generic;

namespace _25.Services.Resources.Application
{
    public class RolePrivilegesResource
    {
        public string RoleName { get; set; }

        public virtual List<SubSystemResource> Subsystems { get; set; }

        public RolePrivilegesResource()
        {
            Subsystems = new List<SubSystemResource>();
        }
    }

    public class SubSystemResource
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<PrivilegeResource> Privileges { get; set; }

        public SubSystemResource()
        {
            Privileges = new List<PrivilegeResource>();
        }

    }

    public class PrivilegeResource
    {
        public string Name { get; set; }
    }

   
}