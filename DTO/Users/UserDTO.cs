using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.DTO.Users
{
    public class UserDTO
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public string Password { get; set; }
        public required int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}