using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechStore.DTO.Auth;
using TechStore.Repositories;

namespace TechStore.Controllers.v1.Auth
{
    [ApiController]
    [Route("api/v1/auth")]

    public class AuthController : ControllerBase
    {
        protected readonly IUserRepository _userRepository;
        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<string>> login( LoginDTO login)
        {
            var token = await _userRepository.Login(login);
            return Ok($"Logged in successfully this is your token: {token}");
        }
    }

}