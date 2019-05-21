﻿using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Library.Application.Services.MailService;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;

namespace Library.Application
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _emailSettings;

        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                var toEmail = string.IsNullOrEmpty(email) ? _emailSettings.ToEmail : email;
                var mail = new MailMessage()
                {
                    From = new MailAddress(_emailSettings.UsernameEmail, "Erik Versteeg"),
                    Subject = subject,
                    Body = htmlMessage,
                    IsBodyHtml = true,
                    Priority = MailPriority.Normal
                };
                mail.To.Add(new MailAddress(toEmail));
                //mail.CC.Add(new MailAddress(_emailSettings.CcEmail));

                using (SmtpClient smtp = new SmtpClient(_emailSettings.PrimaryDomain, _emailSettings.PrimaryPort))
                {
                    smtp.Credentials = new NetworkCredential(_emailSettings.UsernameEmail, _emailSettings.UsernamePassword);
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
    }
}
