using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        private readonly HttpContext _http;
        // private readonly UserManager<User> _userManager;
        // private readonly SignInManager<User> _signInManager;
        //
        //
        // public UserController(UserManager<User> usermanager, SignInManager<User> signInManager)
        // {
        //     _userManager = usermanager;
        //     _signInManager = signInManager;
        // }

        // GET: api/User
        //Todo

        public UserController(WeviContext weviContext, HttpContext httpContext)
        {
            _db = weviContext;
            _http = httpContext;
        }
        
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        //Todo
        [HttpGet("{username}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<User>> Post(RegisterModel value)
        {
            IsUsernameAndEmailExist(value.Username, value.Email);
            return BadRequest();
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
            var result = _db.Users
                .Where(user => user.UserName == username).Count(user => user.Email == email);
            
            if (result == 0)
            {
                return false;
            }
            return true;
        } 
    }
}
