using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechStore.Config;
using TechStore.Data;
using TechStore.DTO.Auth;
using TechStore.DTO.Users;
using TechStore.Models;
using TechStore.Repositories;

namespace TechStore.Services
{
    public class UserService : IUserRepository
    {
        protected readonly ApplicationDbContext _context;
        protected readonly Utilities _utilities;
        public UserService(ApplicationDbContext context, Utilities utilities)
        {
            _context = context;
            _utilities = utilities;
        }

        public async Task Add(UserDTO user)
        {
            user.Password = _utilities.EncryptSHA256(user.Password);
            var user1 = new User
            {
                Email = user.Email,
                Password = user.Password, //hasheo contraseña
                RoleId = user.RoleId //asigno rol de usuario por defecto

            };
            _context.Users.Add(user1);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var user1 = await _context.Users.FindAsync(id);
            if (user1 != null)
            {
                _context.Users.Remove(user1);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<UserDTO>> Get()
        {
            var user1 = await _context.Users.Include(u => u.Roles).Select(user1 => new UserDTO
            {
                Id = user1.Id,
                Email = user1.Email,
                Password = user1.Password,
                RoleId = user1.Roles.Id,
                RoleName = user1.Roles.Name
            }).ToListAsync();
            return user1;
        }

        public async Task<string> Login(LoginDTO login)
        {
            var user1 = await _context.Users.FirstOrDefaultAsync(u => u.Email == login.Email);

            if (user1 != null)
            {
                if (user1.Password == _utilities.EncryptSHA256(login.Password)) //valida la contraseña que sea igual a la del hasheo
                {
                    if (user1.RoleId == 1)//admin rol
                    {
                        var token = _utilities.GenerateJwtToken(user1);
                        return token;
                    }
                    return "empleado regular";
                }
                return "usuario o contraseña invalida";
            }
            return "usuario o contraseña invalida";
        }

        public async Task Update(int id, UserDTO user)
        {
            var user1 = await _context.Users.FindAsync(id);
            if (user1 != null)
            {
                user1.Email = user.Email;
                user1.Password = _utilities.EncryptSHA256(user.Password);
                user1.RoleId = user.RoleId;

                _context.Entry(user1).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}