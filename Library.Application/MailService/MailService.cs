using Library.Domain.Models;
using Library.Domain.Properties;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Library.Application.Services.MailService
{
    public class MailService : IMailService
    {
        private readonly MailServiceSettings _mailServiceSettings;

        public MailService(IOptions<MailServiceSettings> mailServiceSettings)
        {
            _mailServiceSettings = mailServiceSettings.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                var toEmail = string.IsNullOrEmpty(email) ? _mailServiceSettings.ToEmail : email;
                var mail = new MailMessage()
                {
                    From = new MailAddress(_mailServiceSettings.UsernameEmail, _mailServiceSettings.DisplayName),
                    Subject = subject,
                    Body = htmlMessage,
                    IsBodyHtml = true,
                    Priority = MailPriority.Normal
                };
                mail.To.Add(new MailAddress(toEmail));
                //mail.CC.Add(new MailAddress(_emailSettings.CcEmail));

                using (SmtpClient smtp = new SmtpClient(_mailServiceSettings.PrimaryDomain, _mailServiceSettings.PrimaryPort))
                {
                    smtp.Credentials = new NetworkCredential(_mailServiceSettings.UsernameEmail, _mailServiceSettings.UsernamePassword);
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(mail);
                }
            }
            catch (Exception ex)
            {
                var test = ex.Message;
                //do something here
            }
        }

        //TODO for now mail domain user security stuff ??
        public async Task SendApplicationUserConfirmEmail(IDomainUser domainUser, string callbackUrl)
        {
            await SendEmailAsync(
                domainUser.Email,
                DomainResources.MailService_Subject_ApplicationUserConfirmEmail,
                string.Format(DomainResources.MailService_Mail_ApplicationUserConfirmEmail, callbackUrl));
        }
    }
}
