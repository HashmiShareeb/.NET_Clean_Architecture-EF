using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crispy_winner.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace crispy_winner.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        // basic list for now
        public static List<Users> users = new List<Users>
        {
        // sample user
          new Users
          {
            UserId= Guid.NewGuid().ToString(),
            UserName= "john_doe",
            Email="john_doe@example.com"
          }
        };

        //**HTTP METHODS**
        [HttpGet]
        //? Action result so it also returns status codes 
        public ActionResult<List<Users>> GetUsers()
        {
            return Ok(users); // 200 status code
        }

        [HttpGet("{userId}")]
        public ActionResult<Users> GetUserById(string userId)
        {
            var user = users.FirstOrDefault(u => u.UserId == userId);
            if (user == null)
            {
                return NotFound(); // 404 status code
            }
            return Ok(user); // 200 status code
        }

        [HttpPost]
        public ActionResult<Users> CreateUser(Users newUser)
        {
            if (newUser == null)
            {
                return BadRequest(); // return bad request if newUser is null
            }

            newUser.UserId = Guid.NewGuid().ToString(); // assign new GUID as UserId
            users.Add(newUser);

            //specify that the object was created => 200 status code
            return CreatedAtAction(nameof(GetUserById), new { userId = newUser.UserId }, newUser);


        }

        // IActionResult for no content return because its an update
        [HttpPut("{userId}")]
        public IActionResult UpdateUser(string userId, Users updatedUser)
        {
            var user = users.FirstOrDefault(u => u.UserId == userId);
            if (updatedUser == null || userId != updatedUser.UserId)
            {
                return NotFound(); // 400 status code
            }
            if (user == null)
            {
                return NotFound(); // 404 status code
            }

            // Update user properties
            user.UserId = updatedUser.UserId;
            user.UserName = updatedUser.UserName;
            user.Email = updatedUser.Email;

            return NoContent(); // 204 status code

        }

        [HttpDelete("{userId}")]
        public IActionResult DeleteUser(string userId)
        {
            var user = users.FirstOrDefault(u => u.UserId == userId);
            if (user == null)
            {
                return NotFound(); // 404 status code
            }

            users.Remove(user);
            return NoContent(); // 204 status code
        }
    }
}