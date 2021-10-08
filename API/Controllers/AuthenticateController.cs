﻿using API.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IJWTAuthenticationManager jwtAuthenticationManager;
        public AuthenticateController(IJWTAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Kimlik Doğrulama İşlemi Başarılı........" };
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authentication([FromBody] AutPersonCredential autPersonCredential)
        {
            var token = jwtAuthenticationManager.Authenticate(autPersonCredential.UserName, autPersonCredential.Password);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }


    public class AutPersonCredential
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}