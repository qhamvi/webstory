using System;
using System.Collections.Generic;

namespace webstory.Dtos
{
    public record RoleDto
    {
        public Guid id {get; init;}

        // public string[]  nameTopic {get; set;}
        public string  nameRole {get; init;}
    }
}