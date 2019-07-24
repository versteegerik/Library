using Library.Domain.Models;
using System.Threading.Tasks;

namespace Library.Application.Services.MailService
{
    public interface IMailService
    {
        //TODO replace with prdefined mails
        Task SendEmailAsync(string email, string subject, string htmlMessage);

        Task SendApplicationUserConfirmEmail(DomainUser domainUser, string callbackUrl);
    }
}
