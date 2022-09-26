using System;

namespace webstory.Dtos
{
    public record ChapterDto
    {
        public Guid id {get; init;}

        public string titleChap {get; init;}

        public string idStory {get; init;}

        public string collector {get; init;}
        
        public DateTimeOffset createDate {get; init;}

        public DateTimeOffset publishDate {get; init;}
        
        public string content {get; init;}

        
    }
}