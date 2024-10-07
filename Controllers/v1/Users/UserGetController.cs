using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TechStore.Models;
using TechStore.Repositories;

namespace TechStore.Controllers.v1.Users
{
    [ApiController]
    [Route("api/v1/users")]
    [Tags("user")]
    public class UserGetController : UserController
    {
        public UserGetController(IUserRepository userRepository) : base(userRepository)
        {
        }
        [HttpGet]
        [SwaggerOperation(
            Summary = "Get users",
            Description = "Returns all the registered users (admins, employees)"
        )]
        [SwaggerResponse(200, "Ok: Returns all the registered users (admins, employees)")]
        [SwaggerResponse(204, "No Content: There are not users in the database")]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            var user1 = await _userRepository.Get();
            return Ok(user1);
        }
    }
}