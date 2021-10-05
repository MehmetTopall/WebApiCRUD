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
        private IService<User> _userService;
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
            var users = _userService.GetAll();
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
            var users= _userService.GetById(id);
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
            var createdUser= _userService.Create(user);
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
            if (_userService.GetById(user.Id)!=null){
                return Ok(_userService.Update(user));
            }
            return NotFound("Başarısız!!!!");
            
        }
        /// <summary>
        /// Delete the User
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_userService.GetById(id) != null)
            {
                _userService.Delete(id);
                return Ok("Kişi silme işlemi başarılı..");
            }
            return NotFound("Böyle bir kişi bulunamadı!!!");

        }







    }

}
