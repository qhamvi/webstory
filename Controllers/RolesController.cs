using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using webstory.Dtos;
using webstory.Entities;
using webstory.Repositories;

namespace webstory.Controllers
{
    [ApiController]
    [Route("roles")]
    public class RolesController : ControllerBase
    {
        private readonly RRolesRepository Role_Repository;

        public RolesController(RRolesRepository Rolerepository)
        {
            this.Role_Repository = Rolerepository;
        }

        //GET /roles
        [HttpGet]
        public IEnumerable<RoleDto> GetRoles()
        {
            var roles = Role_Repository.GetRoles().Select( role => role.AsRoleDto());
            return roles ;
        }

        //GET /roles/{id}
        [HttpGet("{idRole}")]
        public ActionResult<RoleDto> GetRole(Guid idRole)
        {
            var role = Role_Repository.GetRole(idRole);
            if(role is null)
            {
                return NotFound();
            } 
            return role.AsRoleDto() ;
        }

        //POST /roles
        [HttpPost]
        public ActionResult<RoleDto> CreateRole(CreateRoleDto roleDto)
        {
            Role role = new()
            {
                id = Guid.NewGuid(),
                nameRole = roleDto.nameRole
            };
            Role_Repository.CreateRole(role);
            return CreatedAtAction(nameof(GetRole), new {idRole = role.id}, role.AsRoleDto());
        }

        //PUT /roles
        [HttpPut("{idRole}")]
        public ActionResult UpdateRole(Guid idRole, UpdateRoleDto roleDto)
        {
            var existingRole = Role_Repository.GetRole(idRole);
            if(existingRole is null)
            {
                return NotFound();
            }
            Role updateRole = existingRole with
            {
                nameRole = roleDto.nameRole
            };
            Role_Repository.UpdateRole(updateRole);
            return NoContent();
        }

        //DELETE /roles/{idRole}
        [HttpDelete("{idRole}")]
        public ActionResult DeleteRole(Guid idRole)
        {
            var existingRole = Role_Repository.GetRole(idRole);
            if( existingRole is null)
            {
                return NotFound();
            }
            Role_Repository.DeleteRole(idRole);
            return NoContent();
        }
    }
}