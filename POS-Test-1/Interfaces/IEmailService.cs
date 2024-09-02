using System.Threading.Tasks;
using POS_Test_1.Models;

namespace POS_Test_1.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendResetPasswordEmail(User user);
    }
}
