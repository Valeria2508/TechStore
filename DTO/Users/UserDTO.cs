using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.DTO.Users
{
    public class UserDTO
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required int RoleId { get; set; }
    }
}