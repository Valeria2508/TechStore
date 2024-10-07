using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            var user1 = await _userRepository.Get();
            return Ok(user1);
        }
    }
}