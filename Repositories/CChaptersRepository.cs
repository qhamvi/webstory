using System;
using System.Collections.Generic;
using webstory.Entities;

namespace webstory.Repositories
{
    public interface CChaptersRepository
    {
        Chapter GetChapter(Guid idChapter);
        IEnumerable<Chapter> GetChapters();

        void CreateChapter(Chapter chapter);
        void UpdateChapter(Chapter chapter);
        void DeleteChapter(Guid idChapter) ;

    }
}