using System;

namespace webstory.Entities
{
    public record Role 
    {
        public Guid id {get; init;}

        public string nameRole {get; init;}
    }
}