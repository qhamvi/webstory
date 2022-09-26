using System;
using System.Collections.Generic;

namespace webstory.Entities
{
    public record Story
    {
         public Guid id {get; init;}

        public string titleStory {get; init;}

        public string author {get; init;}

        public string collector {get; init;}
        public List<string> topic {get; init;}
        public bool complete {get; init;}
        public bool status {get; init;}
        
        public DateTimeOffset createDate {get; init;}

        public DateTimeOffset publishDate {get; init;}
        public string ImageFileName {get; init;}
        
        public int numberChap {get; init; } 
        public List<string> listChap {get; init;}
        public string summary {get; init;}

        public List<string> idCom {get; init;}
    }
}