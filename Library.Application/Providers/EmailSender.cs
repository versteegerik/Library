using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Library.Application.Providers
{
    public class EmailSender : IEmailSender
    {
        private readonly ILogger<EmailSender> _logger;
        private readonly EmailSenderSettings _emailSenderSettings;

        // Get our parameterized configuration
        public EmailSender(ILogger<EmailSender> logger, IConfiguration configuration)
        {
            _logger = logger;
            var section = configuration.GetSection(nameof(EmailSender));
            if (section == null)
            {
                _logger.LogError("Missing section EmailSender in appsettings");
            }

            _emailSenderSettings = new EmailSenderSettings(section);
        }

        // Use our configuration to send the email by using SmtpClient
        public async Task SendEmailAsync(string emailAddress, string subject, string htmlMessage)
        {
            try
            {
                var mail = new MailMessage()
                {
                    From = new MailAddress(_emailSenderSettings.UsernameEmail, _emailSenderSettings.DisplayName),
                    Subject = subject,
                    Body = htmlMessage,
                    IsBodyHtml = true,
                    Priority = MailPriority.Normal
                };
                mail.To.Add(new MailAddress(emailAddress));
                //mail.CC.Add(new MailAddress(_emailSettings.CcEmail));

                using (SmtpClient smtp = new SmtpClient(_emailSenderSettings.PrimaryDomain, _emailSenderSettings.PrimaryPort))
                {
                    smtp.Credentials = new NetworkCredential(_emailSenderSettings.UsernameEmail, _emailSenderSettings.UsernamePassword);
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(mail);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
    }
}