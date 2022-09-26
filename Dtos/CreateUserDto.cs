using System;
using System.ComponentModel.DataAnnotations;

namespace webstory.Dtos
{
    public record CreateUserDto
    {
        // public Guid id { get; init; }
        [MinLength(5)]
        public string username { get; init; }
        [MinLength(5)]
        public string password { get; init; }

        // public string photo { get; init; }
        //public string idRole {get; init;}

        // public string fullName { get; init; }

        // public string phone { get; init; }

        // public string email { get; init; }

        // public string country {get; init;}
        
        // public DateTimeOffset createDate {get; init;}

        //public string[] like {get; init;}

        //public string[] history{get; init;}
    }
}