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
    [Route("comments")]
    public class CommentsController : ControllerBase
    {
        private readonly CCommentsRepository Comment_Repository ;

        public CommentsController(CCommentsRepository repository)
        {
            this.Comment_Repository = repository ;
        }
        
        //GET /comments
        [HttpGet]
        public IEnumerable<CommentDto> GetComments()
        {
            var comments = Comment_Repository.GetComments().Select(comments => comments.AsCommentDto());
            return comments;
        }

        //GET /comments/ {idComment}
        [HttpGet("{idComment}")]
        public ActionResult<CommentDto> GetComment(Guid idComment)
        {
            var comment = Comment_Repository.GetComment(idComment);
            if(comment is null)
            {
                return NotFound();
            }
            return comment.AsCommentDto();
        }

        //POST /comments
        [HttpPost]
        public ActionResult<CommentDto> CreateComment (CreateCommentDto commentDto)
        {
            Comment comment = new()
            {
                id = Guid.NewGuid(),
                idUser = commentDto.idUser,
                idStory = commentDto.idStory,
                content = commentDto.content,
                dateCom = DateTimeOffset.Now
            };
            Comment_Repository.CreateComment(comment);
            return CreatedAtAction(nameof(GetComment), new {idComment = comment.id}, comment.AsCommentDto());

        }
        //PUT / comments/{idComment}
        [HttpPut("{idComment}")]
        public ActionResult UpdateComment(Guid idComment, UpdateCommentDto commentDto)
        {
            var existingComment = Comment_Repository.GetComment(idComment);
            if(existingComment is null)
            {
                return NotFound();
            }
            Comment updateComment = existingComment with 
            {
                idUser = commentDto.idUser,
                idStory = commentDto.idStory,
                content = commentDto.content,
                dateCom = DateTimeOffset.Now
            };
            Comment_Repository.UpdateComment(updateComment);
            return NoContent();
        }

        //DELETE /comments/{idComment}
        [HttpDelete("{idComment}")]
        public ActionResult DeleteComment (Guid idComment)
        {
            var existingComment = Comment_Repository.GetComment(idComment);
            if( existingComment is null)
            {
                return NotFound();
            }
            Comment_Repository.DeleteComment(idComment);
            return NoContent();
        }

    }
}
