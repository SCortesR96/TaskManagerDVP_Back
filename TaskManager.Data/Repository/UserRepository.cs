using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data.Context;
using TaskManager.Data.Entities;
using TaskManager.Domain.User.Models.DTO;
using TaskManager.Domain.User.Repositories;

namespace TaskManager.Data.Repository
{
    public class UserRepository : IUsersRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ShowUserDTO>> GetUsers()
        {
            List<User> result = await _context.users.Where(x => x.IsActived == true).ToListAsync();
            return result.Adapt<List<ShowUserDTO>>();
        }

        public async Task<ShowUserDTO> CreateUser(StoreUserDTO user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            var userResult = user.Adapt<User>();
            userResult.CreatedAt = DateTime.Now;
            userResult.CreatedBy = "scortesr";
            userResult.UpdatedBy = "scortesr";

            _context.users.Add(userResult);
            var reuslt = await _context.SaveChangesAsync();

            return user.Adapt<ShowUserDTO>();
        }

        public async Task<ShowUserDTO> UpdateUser(UpdateUserDTO user, int id)
        {
            var result = await _context.users.Where(x => x.Id == id).FirstOrDefaultAsync();

            result.Name = user.Name;
            result.LastName = user.LastName;
            result.SecondLastName = user.SecondLastName;
            result.Username = user.Username;
            result.Email = user.Email;
            result.RolId = user.RolId;
            result.IsActived = user.IsActived;

            _context.Update(result);
            await _context.SaveChangesAsync();
            return user.Adapt<ShowUserDTO>();
        }

        public async Task<Boolean> DeleteUser(int id)
        {
            User user = await _context.users.Where(x => x.Id == id).FirstOrDefaultAsync();

            user.IsActived = false;

            _context.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
