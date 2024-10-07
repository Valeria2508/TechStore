using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TechStore.Repositories;

namespace TechStore.Controllers.v1.Users
{
    [ApiController]
    [Route("api/v1/users")]
    [Tags("user")]
    [Authorize]
    public class UserDeleteController : UserController
    {
        public UserDeleteController(IUserRepository userRepository) : base(userRepository)
        {
        }

        [HttpDelete]
        [SwaggerOperation(
        Summary = "Delete user",
        Description = "Delete user, using its Id")]
        [SwaggerResponse(204, "User deleted successfully")]
        public async Task<IActionResult> Delete (int id){
            await _userRepository.Delete(id);
            return NoContent();
        }
    }
    }
