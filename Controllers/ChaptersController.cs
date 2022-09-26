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
    [Route("chapters")]
    public class ChaptersController : ControllerBase
    {
        private readonly CChaptersRepository Chapter_Repository;

        public ChaptersController(CChaptersRepository repository)
        {
            this.Chapter_Repository = repository;
        }

        //GET /chapters
        [HttpGet]
        public IEnumerable<ChapterDto> GetChapters()
        {
            var chapters = Chapter_Repository.GetChapters().Select(chapter => chapter.AsChapterDto());
            return chapters;
        }
        //GET/chapters/{idChapter}
        [HttpGet("{idChapter}")]
        public ActionResult<ChapterDto> GetChapter(Guid idChapter)
        {
            var chapter = Chapter_Repository.GetChapter(idChapter);
            if (chapter is null)
            {
                return NotFound();
            }
            return chapter.AsChapterDto();
        }
        //POST /chapters/{idChapter}
        [HttpPost]
        public ActionResult<ChapterDto> CreateChapter(CreateChapterDto chapterDto)
        {
            Chapter chapter = new()
            {
                id = Guid.NewGuid(),
                titleChap = chapterDto.titleChap,
                idStory = chapterDto.idStory,
                collector = chapterDto.collector,
                createDate = DateTimeOffset.Now,
                content = chapterDto.content
            };
            Chapter_Repository.CreateChapter(chapter);
            return CreatedAtAction(nameof(GetChapter), new { idChapter = chapter.id }, chapter.AsChapterDto());

        }

        //PUT /chapters
        [HttpPut("{idChapter}")]
        public ActionResult UpdateChapter(Guid idChapter, UpdateChapterDto chapterDto)
        {
            var existingChapter = Chapter_Repository.GetChapter(idChapter);
            if (existingChapter is null)
            {
                return NotFound();
            }
            Chapter updateChapter = existingChapter with 
            {
                titleChap = chapterDto.titleChap,
                idStory = chapterDto.idStory,
                collector = chapterDto.collector,
                createDate = DateTimeOffset.Now,
                content = chapterDto.content
            };
            Chapter_Repository.UpdateChapter(updateChapter);
            return NoContent();
        }

        //UPDATE idStory
        [HttpPut("{idChapter}/idStory")]
        public ActionResult UpdateIdStory(Guid idChapter, UpdateChapterDto chapterDto)
        {
            var existingChapter = Chapter_Repository.GetChapter(idChapter);
            if (existingChapter is null)
            {
                return NotFound();
            }
            Chapter updateChapter = existingChapter with 
            {
                idStory = chapterDto.idStory,
            };
            Chapter_Repository.UpdateChapter(updateChapter);
            return NoContent();
        }

        //DELETE /chapters/{idChapter}
        [HttpDelete("{idChapter}")]
        public ActionResult DeleteChapter (Guid idChapter)
        {
            var existingChapter = Chapter_Repository.GetChapter(idChapter);
            if (existingChapter is null)
            {
                return NotFound();
            }
            Chapter_Repository.DeleteChapter(idChapter);
            return NoContent();
        }

    }
}