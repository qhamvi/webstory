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
    
    [Route("users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        private readonly UUsersRepository User_Repository ;
        public UsersController(UUsersRepository repository,IConfiguration configuration, IWebHostEnvironment env)
        {
            this.User_Repository = repository ;
            this._configuration = configuration;
            this._env = env;
        }
       

        //GET /users
        [HttpGet]
        public IEnumerable<UserDto> GetUsers()
        {
            var users = User_Repository.GetUsers().Select(user => user.AsUserDto());
            return users ;
        }
        //GET /users / {idUser}
        [HttpGet("{idUser}")]
        public ActionResult<UserDto> GetUser(Guid idUser)
        {
            var user = User_Repository.GetUser(idUser);
            if (user is null)
            {
                return NotFound();
            }
            return user.AsUserDto() ;
        }

        // GET /user/username:password
        // [HttpGet("{username}/{password}")]
        [HttpGet("login/auth")]
        public ActionResult<UserDto> LoginUser(string username, string password)
        {
            var user = User_Repository.LoginUser(username,password);
            if (user is null) 
            {
                return NotFound();
            }
            return user.AsUserDto();
        }



        //POST /users/admins COLLECTOR
        [HttpPost("admins")]
        public ActionResult<UserDto> CreateAdmin (CreateUserDto userDto)
        {
            User user = new User {
                 id = Guid.NewGuid(),
                username = userDto.username,
                password = userDto.password,
                idRole = "Admin",
                PhotoFileName = "null.png",
                fullName = "",
                phone ="",
                email="",
                country="",
                createDate= DateTimeOffset.Now,
                like=null,
                history=null
            };
            User_Repository.CreateUser(user);
            return CreatedAtAction(nameof(GetUser), new {idUser = user.id}, user.AsUserDto());
        }
        //POST /users/collectors COLLECTOR
        [HttpPost("collectors")]
        public ActionResult<UserDto> CreateCollector (CreateUserDto userDto)
        {
            User user = new User {
                 id = Guid.NewGuid(),
                username = userDto.username,
                password = userDto.password,
                idRole = "Collector",
                PhotoFileName = "null.png",
                fullName = "",
                phone ="",
                email="",
                country="",
                createDate= DateTimeOffset.Now,
                like=null,
                history=null
            };
            User_Repository.CreateUser(user);
            return CreatedAtAction(nameof(GetUser), new {idUser = user.id}, user.AsUserDto());
        }

        //POST /users /members /MEMBER
        [HttpPost("members")]
        public ActionResult<UserDto> CreateMember(CreateUserDto userDto)
        {
            User user = new User {
                id = Guid.NewGuid(),
                username = userDto.username,
                password = userDto.password,
                idRole = "Member",
                PhotoFileName = "null.png",
                fullName = "",
                phone ="",
                email="",
                country="",
                createDate= DateTimeOffset.Now,
                like=null,
                history=null
            };
            User_Repository.CreateUser(user);
            return CreatedAtAction(nameof(GetUser), new {idUser = user.id}, user.AsUserDto());

        }
        //PUT /users /{idUser} --Cai lai thong tin ca nhan
        [HttpPut("{idUser}")]
        public ActionResult<UserDto> UpdateUser(Guid idUser,UpdateUserDto userDto)
        {
            var existingUser = User_Repository.GetUser(idUser);
            if(existingUser is null)
            {
                return NotFound();
            }
            User updateUser = existingUser with
            {
                username = userDto.username,
                password = userDto.password,
                PhotoFileName = userDto.PhotoFileName,
                fullName = userDto.fullName,
                phone = userDto.phone,
                email = userDto.email,
                country = userDto.country,
                // like = userDto.like,
                // history = userDto.history
            };
            User_Repository.UpdateUser(updateUser);
            return NoContent();
        }

        //PUT /users /{idUser}/image --IMAGE 
        [HttpPut("{idUser}/image")]
        public ActionResult<UserDto> UpdateImage(Guid idUser,UpdateUserDto userDto)
        {
            var existingUser = User_Repository.GetUser(idUser);
            if(existingUser is null)
            {
                return NotFound();
            }
            User updateUser = existingUser with
            {
                PhotoFileName = userDto.PhotoFileName,
            };
            User_Repository.UpdateUser(updateUser);
            return NoContent();
        }

        //PUT /users /like/{idUser} // Cap nhat gia tri like (yeu thich)
        [HttpPut("like/{idUser}")]
        public ActionResult<UserDto> UpdateLike(Guid idUser,UpdateLikeDto userDto)
        {
            var existingUser = User_Repository.GetUser(idUser);
            if(existingUser is null)
            {
                return NotFound();
            }
            User updateUser = existingUser with
            {

                like = userDto.like
                
            };
            User_Repository.UpdateUser(updateUser);
            return NoContent();
        }
        //PUT /users/history/{idUser} --Cap nhat gia tri history
        [HttpPut("history/{idUser}")]
        public ActionResult<UserDto> UpdateHistory(Guid idUser, UpdateHistoryDto userDto)
        {
            var existingUser = User_Repository.GetUser(idUser);
            if (existingUser is null)
            {
                return NotFound();
            }
            User updateUser = existingUser with 
            {
                history = userDto.history
            };
            User_Repository.UpdateUser(updateUser);
            return NoContent() ;
        }
        //DELETE /users/{idUser} 
        [HttpDelete("{idUser}")]
        public ActionResult<UserDto> DeleteUser(Guid idUser)
        {
            var existingUser = User_Repository.GetUser(idUser);
            if(existingUser is null)
            {
                return NotFound() ;
            }
            User_Repository.DeleteUser(idUser);
            return NoContent() ;
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