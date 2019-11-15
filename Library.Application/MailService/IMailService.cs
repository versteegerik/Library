using Library.Domain.Models;
using Library.Infrastructure.Security.Models;
using System.Threading.Tasks;

namespace Library.Application.Services.MailService
{
    public interface IMailService
    {
        //TODO replace with prdefined mails
        Task SendEmailAsync(string email, string subject, string htmlMessage);

        Task SendApplicationUserConfirmEmail(ApplicationUser applicationUser, string callbackUrl);
    }
}
