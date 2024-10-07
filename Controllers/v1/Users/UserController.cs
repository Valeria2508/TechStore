using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechStore.Repositories;

namespace TechStore.Controllers.v1.Users
{
    [ApiController]
    [Route("api/v1/users")]

    public class UserController : ControllerBase
    {
        protected readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
    }
}