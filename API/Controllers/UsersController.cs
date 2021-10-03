using Business.Abstract;
using Business.Concrete;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        public UsersController()
        {
            _userService = new UserManager();
        }
        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var users = _userService.GetAllUsers();
            return Ok(users); //200 + data
        }
        /// <summary>
        /// Get User By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        // [Route("getUserById/{id}")] => api/user/getUserById/2
        public IActionResult Get(int id)
        {
            var users= _userService.GetUserById(id);
            if (User != null)
            {
                return Ok(users); //200 + data
            }
            return NotFound(); //404
        }
        /// <summary>
        /// Create a User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            var createdUser= _userService.CreateUser(user);
            return CreatedAtAction("Get", new { id = createdUser.Id }, createdUser); //201 + data
        }
        /// <summary>
        /// Update the User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] User user)
        {
            if (_userService.GetUserById(user.Id)!=null){
                return Ok(_userService.UpdateUser(user));
            }
            return NotFound();
            
        }
        /// <summary>
        /// Delete the User
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_userService.GetUserById(id) != null)
            {
                _userService.DeleteUser(id);
                return Ok();
            }
            return NotFound();

        }







    }

}
