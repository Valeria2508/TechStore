using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TechStore.DTO.Users;
using TechStore.Models;
using TechStore.Repositories;

namespace TechStore.Controllers.v1.Users
{
    [ApiController]
    [Route("api/v1/users")]
    [Tags("user")]
    public class UserPostController : UserController
    {
        public UserPostController(IUserRepository userRepository) : base(userRepository)
        {
        }
        [HttpPost]
        [SwaggerOperation(
            Summary = "Login user",
            Description = "Login user with email and password"
        )]
        [SwaggerResponse(200, "User logged in successfully")]
        [SwaggerResponse(400, "Bad request")]
        [SwaggerResponse(401, "Unauthorized")]
        public async Task<ActionResult<User>> Post([FromBody] UserDTO user)
        {
            await _userRepository.Add(user);
            return Ok();
        }
    }
}