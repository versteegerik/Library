using Library.Domain.Model;
using System.Threading.Tasks;

namespace Library.Domain.Services
{
    public interface IMailService
    {
        Task SendApplicationUserConfirmEmail(ApplicationUser applicationUser, string callbackUrl);
    }
}
