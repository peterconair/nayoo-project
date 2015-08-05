using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nayoo.Data.ClassHelper
{
    public class UserRoles
    {
        public List<Role> Roles { get; set; }
        public UserRoles()
        {
            Roles = new List<Role>();
            Roles.Add(new Role { RoleName = "ADMIN" });
            Roles.Add(new Role { RoleName = "MEMBER" });
            Roles.Add(new Role { RoleName = "SECURITY" });
            Roles.Add(new Role { RoleName = "COMMITTEE" });
            Roles.Add(new Role { RoleName = "STAFF" });
        }

    }

    public class Role
    {
        public string RoleName { get; set; }
        public Role()
        {
        }
    }
}
