using System.Threading.Tasks;
using POS_Test_1.Models;

namespace POS_Test_1.Interfaces
{
    public interface ITokenRepository
    {
        Task<Token> GetTokenByUserIdAsync(int userId);
        Task<Token> GetTokenByValueAsync(string tokenValue);
        Task<bool> CreateTokenAsync(Token token);
        Task<bool> DeleteTokenAsync(int userId);
        Task<bool> SaveAsync();
    }
}
