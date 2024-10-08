using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class UserUpdateController : UserController
    {
        public UserUpdateController(IUserRepository userRepository) : base(userRepository)
        {
        }
        [HttpPut]
        [SwaggerOperation(
            Summary = "Update user",
            Description = "Update user, finding it by Id and putting the newInfo"
        )]
        [SwaggerResponse(200, "User updated")]
        [SwaggerResponse(400, "Bad request, please try again")]
        public async Task<ActionResult<User>> Update([FromHeader]int id, [FromBody] UserDTO user){
            await _userRepository.Update(id, user);
            return Ok();
        }
    }
}