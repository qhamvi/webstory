using System;
using System.Collections.Generic;
using System.Linq;
using webstory.Entities;

namespace webstory.Repositories
{
    

    public class InMemRolesRepository : RRolesRepository
    {
        private readonly List<Role> roles = new()
        {
            new Role { id = Guid.NewGuid(), nameRole = "Admin" },
            new Role { id = Guid.NewGuid(), nameRole = "Collector" },
            new Role { id = Guid.NewGuid(), nameRole = "Member" },
            new Role { id = Guid.NewGuid(), nameRole = "Guest" }
        };
        public IEnumerable<Role> GetRoles()
        {
            return roles;
        }
        public Role GetRole(Guid idRole2)
        {
            return roles.Where(role => role.id == idRole2).SingleOrDefault();
        }

        public void CreateRole(Role role)
        {
            roles.Add(role);
        }

        public void UpdateRole(Role role)
        {
            var index = roles.FindIndex(existingRole => existingRole.id == role.id);
            roles[index] = role ;
        }

        public void DeleteRole(Guid idRole2)
        {
            var index = roles.FindIndex(existingRole => existingRole.id == idRole2);
            roles.RemoveAt(index);
        }
    }
}