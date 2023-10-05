using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using wevibackend.Models;
using wevibackend.Models.Account;

namespace wevibackend.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly WeviContext _db;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserController(WeviContext weviContext, UserManager<User> userManager, SignInManager<User> signInManager )
        {
            _db = weviContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        [HttpGet]
        [Authorize]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        //Todo
        [HttpGet("{username}", Name = "Get")]
        [Authorize]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<Response>> Post(RegisterModel value)
        {
            if (IsUsernameAndEmailExist(value.Username, value.Email))
            {
                return StatusCode(403); // already exist 
            };

            var user = new User()
            {
                UserName = value.Username,
                Email = value.Email
            };
            var result = await _userManager.CreateAsync(user, value.Password);
            if (result.Succeeded)
            {
                return Ok(new Response(){Status=ResponseStatus.Success, Message = "User created"});
            }
            else 
            {
                if (result.Errors.Count() > 0)
                {
                    var message = "";
                    foreach (IdentityError e in result.Errors)
                    {
                        message += e.Description;
                    }

                    return StatusCode(500, new Response() { Status = ResponseStatus.Fail, Message = message });
                }
                else
                {
                    return StatusCode(500, new Response() { Status = ResponseStatus.Fail, Message = "Server Error" });
                }
            }
        }

        // PUT: api/User/5
        //Todo
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/User/5
        //Todo
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private static UserDTO ToUserDTO(User user)
        {
            return new UserDTO()
            {
                Username = user.UserName,
                Email = user.Email
            };
        }

        private bool IsUsernameAndEmailExist(string username, string email)
        {
            var userNameCount= _db.Users
                .Count(user => user.UserName != null && user.UserName.Equals(username));
            var emailCount= _db.Users
                .Count(user => user.Email != null && user.Email.Equals(email));
            return userNameCount != 0 || emailCount != 0;
        } 
    }
}
