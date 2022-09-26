using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using webstory.Dtos;
using webstory.Entities;
using webstory.Repositories;

namespace webstory.Controllers
{
    [ApiController]
    [Route("topics")]
    public class TopicsController : ControllerBase
    {
        private readonly TTopicsRepository Topic_Repository;

        public TopicsController(TTopicsRepository Topicrepository)
        {
            this.Topic_Repository = Topicrepository;
        }

        //GET /topics
        [HttpGet]
        public IEnumerable<TopicDto> GetTopics()
        {
            var topics = Topic_Repository.GetTopics().Select( topic => topic.AsTopicDto());
            return topics ;
        }

        //GET /topics/{id}
        [HttpGet("{idTopic}")]
        public ActionResult<TopicDto> GetTopic(Guid idTopic)
        {
            var topic = Topic_Repository.GetTopic(idTopic);
            if(topic is null)
            {
                return NotFound();
            } 
            return topic.AsTopicDto() ;
        }

        //POST /topics
        [HttpPost]
        public ActionResult<TopicDto> CreateTopic(CreateTopicDto topicDto)
        {
            Topic topic = new()
            {
                id = Guid.NewGuid(),
                nameTopic = topicDto.nameTopic
            };
            Topic_Repository.CreateTopic(topic);
            return CreatedAtAction(nameof(GetTopic), new {idTopic = topic.id}, topic.AsTopicDto());
        }

        //PUT /topics
        [HttpPut("{idTopic}")]
        public ActionResult UpdateTopic(Guid idTopic, UpdateTopicDto topicDto)
        {
            var existingTopic = Topic_Repository.GetTopic(idTopic);
            if(existingTopic is null)
            {
                return NotFound();
            }
            Topic updateTopic = existingTopic with
            {
                nameTopic = topicDto.nameTopic
            };
            Topic_Repository.UpdateTopic(updateTopic);
            return NoContent();
        }

        //DELETE /topics/{idTopic}
        [HttpDelete("{idTopic}")]
        public ActionResult DeleteTopic(Guid idTopic)
        {
            var existingTopic = Topic_Repository.GetTopic(idTopic);
            if( existingTopic is null)
            {
                return NotFound();
            }
            Topic_Repository.DeleteTopic(idTopic);
            return NoContent();
        }
    }
}