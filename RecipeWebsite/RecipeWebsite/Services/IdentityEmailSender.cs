﻿using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit;
using RecipeWebsite.Models;

namespace RecipeWebsite.Services
{
    public class IdentityEmailSender : IEmailSender
    {
        private readonly MailSettings _mailSettings;

        public IdentityEmailSender(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task SendContactEmailAsync(string emailfrom, string name, string subject, string htmlMessage)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(emailfrom);
            email.To.Add(MailboxAddress.Parse(_mailSettings.Mail));
            email.Subject = subject;

            var builder = new BodyBuilder();
            builder.HtmlBody = $"<b>{name}</b> has sent you an email and can be reached at: <b>{emailfrom}</b><br /><br />{htmlMessage}";

            email.Body = builder.ToMessageBody();

            await SendEmail(email);
        }

        public async Task SendEmailAsync(string emailTo, string subject, string htmlMessage)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(emailTo));
            email.Subject = subject;

            var builder = new BodyBuilder();
            builder.HtmlBody = htmlMessage;

            email.Body = builder.ToMessageBody();

            await SendEmail(email);
        }

        private async Task SendEmail(MimeMessage email)
        {
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);

            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
