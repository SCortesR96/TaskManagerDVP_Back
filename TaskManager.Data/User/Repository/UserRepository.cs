using Mapster;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data.Context;
using TaskManager.Data.User.Entities;
using TaskManager.Domain.User.Models.DTO;
using TaskManager.Domain.User.Repositories;

namespace TaskManager.Data.User.Repository
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
            List<UserEntity> result = await _context.users.Where(x => x.IsActived == true).ToListAsync();
            return result.Adapt<List<ShowUserDTO>>();
        }

        public async Task<ShowUserDTO> CreateUser(StoreUserDTO user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            var userResult = user.Adapt<UserEntity>();
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

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.users.Where(x => x.Id == id).FirstOrDefaultAsync();

            user.IsActived = false;

            _context.Update(user);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
