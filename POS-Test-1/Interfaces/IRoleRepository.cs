using System.Collections.Generic;
using System.Threading.Tasks;
using POS_Test_1.Models;

namespace POS_Test_1.Interfaces
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task<Role> GetRoleByIdAsync(int id);
        Task<bool> CreateRoleAsync(Role role);
     
        Task<bool> UpdateRoleAsync(Role role);
        Task<bool> DeleteRoleAsync(int id);
        Task<bool> SaveAsync();
     
    }
}
