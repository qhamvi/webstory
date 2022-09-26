using System;

namespace webstory.Dtos
{
    public record UpdateUserDto
    {

        public string username { get; init; }

        public string password { get; init; }

        public string PhotoFileName { get; init; }
        // public string idRole {get; init;}

        public string fullName { get; init; }

        public string phone { get; init; }

        public string email { get; init; }

        public string country {get; init;}
        

        // public string[] like {get; init;}

        // public string[] history{get; init;}
    }
}