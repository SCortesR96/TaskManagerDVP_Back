using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.User.Models.DTO;

namespace TaskManager.Domain.User.Repositories
{
    public interface IUsersRepository
    {
        public Task<List<ShowUserDTO>> GetUsers();
        public Task<ShowUserDTO> CreateUser(StoreUserDTO user);
        public Task<ShowUserDTO> UpdateUser(UpdateUserDTO user, int id);
        public Task<bool> DeleteUser(int id);
    }
}
