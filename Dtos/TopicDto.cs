using System;
using System.Collections.Generic;

namespace webstory.Dtos
{
    public record TopicDto
    {
        public Guid id {get; init;}

        // public string[]  nameTopic {get; set;}
        public string[]  nameTopic {get; init;}
    }
}