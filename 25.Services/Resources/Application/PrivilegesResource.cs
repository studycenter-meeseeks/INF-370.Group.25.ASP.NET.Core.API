using System.Collections.Generic;

namespace _25.Services.Resources.Application
{
    public class RolePrivilegesResource
    {
        public string Id { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }

        public virtual List<SubsystemResource> Subsystems { get; set; }

        public RolePrivilegesResource()
        {
            Subsystems = new List<SubsystemResource>();
        }
    }

    public class SubsystemResource
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<OperationResource> Privileges { get; set; }

        public SubsystemResource()
        {
            Privileges = new List<OperationResource>();
        }

    }

    public class OperationResource
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public bool HasPermission { get; set; }
    }
}