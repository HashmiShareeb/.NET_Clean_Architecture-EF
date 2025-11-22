using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crispy_winner.Domain.Entities;
using FinancialApi.Domain.Interfaces;
using FinancialApi.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace crispy_winner.Presentation.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class UsersController : ControllerBase
    {
        private readonly FinancialsService _financialsService;
        private readonly UserService _userService;

        public UsersController(FinancialsService _financialsService, UserService _userService)
        {
           this._financialsService = _financialsService;
           this._userService = _userService;
        }
        
        // basic list for now
        public static List<Users> users = new List<Users>
        {
        // sample user
          new Users
          {
            UserId= Guid.NewGuid(),
            UserName= "john_doe",
            Email="john_doe@example.com"
          }
        };

        //**HTTP METHODS**
        [HttpGet]
        //? Action result so it also returns status codes 
        public async Task<ActionResult<List<Users>>> GetUsers()
        {
            //return Ok(users); // 200 status code
            
            var allUsers  = await _userService.GetAllUsers();
            return Ok(allUsers);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<Users>> GetUserById(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                return BadRequest("UserId Not Found or doesn't exist");
            }
            var usersById = await _userService.GetUserById(userId);
            return Ok(usersById);
        }
        
        [HttpPost]
        public async Task<ActionResult<Users>> AddUser([FromBody] Users newUser)
        {
            if (newUser == null)
                return BadRequest();

            newUser.UserId = Guid.NewGuid();

            // add to DB
            await _userService.AddUser(newUser);

            return CreatedAtAction(nameof(GetUserById), new { userId = newUser.UserId }, newUser);
        }




        // IActionResult for no content return because its an update
        [HttpPut("{userId}")]
        public IActionResult UpdateUser(string userId, Users updatedUser)
        {
            var user = users.FirstOrDefault(u => u.UserId == Guid.Parse(userId));
            if (updatedUser == null || Guid.Parse(userId) != updatedUser.UserId)
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
            var user = users.FirstOrDefault(u => u.UserId == Guid.Parse(userId)); //Parse string to Guid
            if (user == null)
            {
                return NotFound(); // 404 status code
            }

            users.Remove(user);
            return NoContent(); // 204 status code
        }
    }
}