using System;
using System.Collections.Generic;

namespace webstory.Entities
{
    public record Topic
    {
        public Guid id {get; init;}

        // public string[]  nameTopic {get; set;}
        public string[]  nameTopic {get; init;}
    }
}