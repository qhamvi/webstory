using System;
using System.Collections.Generic;
using webstory.Entities;

namespace webstory.Repositories
{
    public interface RRolesRepository
    {
        Role GetRole(Guid idRole2);
        IEnumerable<Role> GetRoles();

        void CreateRole (Role role);

        void UpdateRole (Role role);

        void DeleteRole (Guid idRole2);
    }
}