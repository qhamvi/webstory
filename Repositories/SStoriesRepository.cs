using System;
using System.Collections.Generic;
using webstory.Entities;

namespace webstory.Repositories
{
    public interface SStoriesRepository
    {
        void CreateStory(Story story);
        void DeleteStory(Guid idStory);
        IEnumerable<Story> GetStories();
        Story GetStory(Guid idStory);
        void UpdateStory(Story story);
        IEnumerable<Story> GetStoriesTrue();
        IEnumerable<Story> GetStoriesFull();
        // IEnumerable<Story> GetStoriesTopic(string nametopic);
        List<Story> GetStoriesTopic(string nametopic);

    

    }
}