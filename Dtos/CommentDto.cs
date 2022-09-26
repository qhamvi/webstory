using System;

namespace webstory.Dtos
{
    public record CommentDto
    {
        public Guid id {get; init;}

        public string idUser {get; init;}

        public string idStory {get; init;}

        public string content {get; init;}
        
        public DateTimeOffset dateCom {get; init;}
    }
}