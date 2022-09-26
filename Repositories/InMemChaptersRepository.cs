using System;
using System.Collections.Generic;
using System.Linq;
using webstory.Entities;

namespace webstory.Repositories
{
   
    public class InMemChaptersRepository : CChaptersRepository
    {
         
        public static List<Chapter> chapters = new()
        {
            new Chapter { id = Guid.NewGuid(), titleChap = "Chuong 1", idStory = "truyen1", collector = "colector1", createDate = DateTimeOffset.UtcNow, publishDate = DateTimeOffset.UtcNow, content = "VIIIIIIIIIIIIII" },
            new Chapter { id = Guid.NewGuid(), titleChap = "Chuong 1", idStory = "truyen1", collector = "colector1", createDate = DateTimeOffset.UtcNow, publishDate = DateTimeOffset.UtcNow, content = "VIIIIIIIIIIIIII" },
            new Chapter { id = Guid.NewGuid(), titleChap = "Chuong 1", idStory = "truyen1", collector = "colector1", createDate = DateTimeOffset.UtcNow, publishDate = DateTimeOffset.UtcNow, content = "VIIIIIIIIIIIIII" }

        };
        public IEnumerable<Chapter> GetChapters()
        {
            return chapters;
        }
        public Chapter GetChapter(Guid idChapter)
        {
            return chapters.Where(chapter => chapter.id == idChapter).SingleOrDefault();
        }

        public void CreateChapter(Chapter chapter)
        {
            chapters.Add(chapter);
        }

        public void UpdateChapter(Chapter chapter)
        {
            var index = chapters.FindIndex(exstingChapter => exstingChapter.id == chapter.id);
            chapters[index] = chapter ;
        }

        public void DeleteChapter(Guid idChapter)
        {
            var index = chapters.FindIndex(existingChapter => existingChapter.id == idChapter);
            chapters.RemoveAt(index) ;
        }
    }
}