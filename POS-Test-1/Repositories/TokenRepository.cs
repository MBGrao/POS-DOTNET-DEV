using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using POS_Test_1.Data;
using POS_Test_1.Interfaces;
using POS_Test_1.Models;

namespace POS_Test_1.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly ApplicationDbContext _context;

        public TokenRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Token> GetTokenByUserIdAsync(int userId)
        {
            return await _context.Tokens.FirstOrDefaultAsync(t => t.UserId == userId);
        }

        public async Task<Token> GetTokenByValueAsync(string tokenValue)
        {
            return await _context.Tokens.FirstOrDefaultAsync(t => t.Value == tokenValue);
        }

        public async Task<bool> CreateTokenAsync(Token token)
        {
            await _context.Tokens.AddAsync(token);
            return await SaveAsync();
        }

        public async Task<bool> DeleteTokenAsync(int userId)
        {
            var token = await _context.Tokens.FirstOrDefaultAsync(t => t.UserId == userId);
            if (token == null)
            {
                return false;
            }
            _context.Tokens.Remove(token);
            return await SaveAsync();
        }
        public User GetUserById(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User not found.");
            }
            return user;
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
