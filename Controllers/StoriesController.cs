using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using webstory.Dtos;
using webstory.Entities;
using webstory.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace webstory.Controllers
{
    [ApiController]
    [Route("stories")]
    public class StoriesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        private readonly SStoriesRepository Story_Repository;
        public StoriesController(SStoriesRepository repository, IConfiguration configuration, IWebHostEnvironment env)
        {
            this.Story_Repository = repository;
            this._configuration = configuration;
            this._env = env;
        }

        //GET /stories --GET ALL
        [HttpGet]
        public IEnumerable<StoryDto> GetStories()
        {
            var stories = Story_Repository.GetStories().Select(story => story.AsStoryDto());
            return stories;
        }
        // GET /stories/true        --GET ALL TRUE
        [HttpGet("true")]
        public IEnumerable<StoryDto> GetStoriesTrue()
        {
            var stories = Story_Repository.GetStoriesTrue().Select(story2 => story2.AsStoryTrueDto());
            return stories;
        }


        //GET /stories/topic        --GET ALL TOPIC
        [HttpGet("topic/{nametopic}")]
        public IEnumerable<StoryDto> GetStoriesTopic(string nametopic)
        {
            var stories = Story_Repository.GetStoriesTopic(nametopic).Select(story2 => story2.AsStoryDto());
            return stories;
        }


        // GET /stories/true    --GET ALL FULL
        [HttpGet("topic/full")]
        public IEnumerable<StoryDto> GetStoriesFull()
        {
            var stories = Story_Repository.GetStoriesFull().Select(story2 => story2.AsStoryFullDto());
            return stories;
        }

        //GET /stories /idStory ---GET 1 IDSTORY
        [HttpGet("{idStory}")]
        public ActionResult<StoryDto> GetStory(Guid idStory)
        {
            var story = Story_Repository.GetStory(idStory);
            if (story is null)
            {
                return NotFound();
            }
            return story.AsStoryDto();
        }

        //POST /stories 
        [HttpPost]
        public ActionResult<StoryDto> CreateStoryDto(CreateStoryDto storyDto)
        {
            Story story = new Story
            {
                id = Guid.NewGuid(),
                titleStory = storyDto.titleStory,
                author = storyDto.author,
                collector = storyDto.author,
                topic = storyDto.topic,
                complete = storyDto.complete,
                status = false, //mac dinh status la false
                createDate = DateTimeOffset.Now,
                publishDate = DateTimeOffset.UtcNow, //Now lay gio local o may -- UtcNow lay mui gio o noi khac
                ImageFileName = storyDto.ImageFileName,
                summary = storyDto.summary,
                listChap = storyDto.listChap,
                numberChap = storyDto.listChap.Count,
                idCom = storyDto.idCom
            };
            Story_Repository.CreateStory(story);
            return CreatedAtAction(nameof(GetStory), new { idStory = story.id }, story.AsStoryDto());
        }

        //PUT /stories/{idStory}
        [HttpPut("{idStory}")]
        public ActionResult<StoryDto> UpdateStory(Guid idStory, UpdateStoryDto storyDto)
        {
            var existingStory = Story_Repository.GetStory(idStory);
            if (existingStory is null)
            {
                return NotFound();
            }
            Story updateStory = existingStory with
            {
                titleStory = storyDto.titleStory,
                author = storyDto.author,
                collector = storyDto.author,
                topic = storyDto.topic,
                complete = storyDto.complete,
                // createDate = DateTimeOffset.UtcNow,
                //publishDate = DateTimeOffset.UtcNow,
                ImageFileName = storyDto.ImageFileName,
                summary = storyDto.summary,
                listChap = storyDto.listChap,
                numberChap = storyDto.listChap.Count,
                idCom = storyDto.idCom
            };
            Story_Repository.UpdateStory(updateStory);
            return NoContent();
        }
        // UPDATE ListChap STORY OF CHAPTER
        [HttpPut("{idStory}/chapter")]
        public ActionResult<StoryDto> UpdateStoryChapter(Guid idStory, UpdateStoryDto storyDto)
        {
            var existingStory = Story_Repository.GetStory(idStory);
            if (existingStory is null)
            {
                return NotFound();
            }
            Story updateStory = existingStory with
            {
                listChap = storyDto.listChap
            };
            Story_Repository.UpdateStory(updateStory);
            return NoContent();
        }
        [HttpPut("{idStory}/comment")]
        public ActionResult<StoryDto> UpdateStoryComment(Guid idStory, UpdateStoryDto storyDto)
        {
            var existingStory = Story_Repository.GetStory(idStory);
            if (existingStory is null)
            {
                return NotFound();
            }
            Story updateStory = existingStory with
            {
                idCom = storyDto.idCom
            };
            Story_Repository.UpdateStory(updateStory);
            return NoContent();
        }
       
        //PUT /stories/true/idStory--- status = true  -- publishDate update
        [HttpPut("true/{idStory}")]
        public ActionResult<StoryDto> UpdateStoryTrue(Guid idStory, UpdateStoryDto storyDto)
        {
            var existingStory = Story_Repository.GetStory(idStory);
            if (existingStory is null)
            {
                return NotFound();
            }
            Story updateStory = existingStory with
            {
                status = true,
                publishDate = DateTimeOffset.Now
            };
            Story_Repository.UpdateStory(updateStory);
            return NoContent();
        }

        //PUT /stories/full/idStory--- complete = full
        [HttpPut("full/{idStory}")]
        public ActionResult<StoryDto> UpdateStoryFull(Guid idStory, UpdateStoryDto storyDto)
        {
            var existingStory = Story_Repository.GetStory(idStory);
            if (existingStory is null)
            {
                return NotFound();
            }
            Story updateStory = existingStory with
            {
                complete = true
            };
            Story_Repository.UpdateStory(updateStory);
            return NoContent();
        }

        //DELETE /stories/ {idStory}
        [HttpDelete("{idStory}")]
        public ActionResult DeleteStory(Guid idStory)
        {
            var existingStory = Story_Repository.GetStory(idStory);
            if (existingStory is null)
            {
                return NotFound();
            }
            Story_Repository.DeleteStory(idStory);
            return NoContent();
        }

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {

                return new JsonResult("cp.png");

            }
        }



    }
}