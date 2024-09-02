using System.Collections.Generic;
using System.Threading.Tasks;
using POS_Test_1.Models;

namespace POS_Test_1.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByResetTokenAsync(string resetToken);
        Task<bool> CreateUserAsync(User user);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int id);
        Task<bool> SaveAsync();
    }
}
