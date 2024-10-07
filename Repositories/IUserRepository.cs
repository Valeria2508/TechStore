using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechStore.DTO.Auth;
using TechStore.DTO.Users;

namespace TechStore.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDTO>> Get();
        Task Add(UserDTO product);
        Task Delete(int id);
        Task Update(int id,UserDTO product);
        Task<string> Login(LoginDTO login);
    }
}