using Bookstore.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.WebApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UsersController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_userServices.GetUsers());
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            _userServices.AddUser(user);
            return CreatedAtRoute("GetUser", new { id = user.Id }, user);
        }

        [HttpPost("/login")]
        public IActionResult Login([FromBody] User model)
        {
            var user = _userServices.Login(model.Email, model.Password);

            if (user == null)
                return Ok(new { message = "Username or password incorrect" });

            if (user.UserStatus == "blocked")
                return Ok(new { message = "Your account is blocked, please contact the administrator for more informations." });

            return Ok(new
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Role = user.Role,
                UserStatus = user.UserStatus
            });
        }

        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetUser(string id)
        {
            return Ok(_userServices.GetUser(id));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(string id)
        {
            _userServices.DeleteUser(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateUser(User user)
        {
            return Ok(_userServices.UpdateUser(user));
        }

    }
}
