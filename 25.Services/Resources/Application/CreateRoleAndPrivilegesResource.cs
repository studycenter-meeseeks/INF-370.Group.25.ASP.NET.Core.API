using System.Collections.Generic;

namespace _25.Services.Resources.Application
{
    public class CreateRoleAndPrivilegesResource
    {
        public string RoleName { get; set; }

        public List<Privilege> Privileges { get; set; }

    }

    public class Privilege
    {
        public string SubSystem { get; set; }
        public string Operation { get; set; }

    }
}