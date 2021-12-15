using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//using System.Net.Mail;
using System.Threading.Tasks;
using MailKit.Net.Smtp;

namespace EbayView.Services
{
    public class MailServices : IMailServices
    {
        private readonly MailSetting mailSettings;
        public MailServices(IOptions<MailSetting> _mailSettings)
        {
            mailSettings = _mailSettings.Value;//AzureStorage
        }
         
        public async Task SendEmailAsync(string mailto, string subject, string body, IList<IFormFile> attachments = null)
        {
            var email = new MimeMessage
            {
                Sender = MailboxAddress.Parse(mailSettings.Email),
                Subject = subject
            };
            email.To.Add(MailboxAddress.Parse(mailto));
            //throw new NotImplementedException();
            var builder = new BodyBuilder();
            if (attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }
            builder.HtmlBody = body;
            email.Body = builder.ToMessageBody();
            email.From.Add(new MailboxAddress(mailSettings.DisplayName, mailSettings.Email));
            // connect to providor
            using var smtp = new SmtpClient();//using MailKit.Net.Smtp;
            smtp.Connect(mailSettings.Host, mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(mailSettings.Email, mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        } 
         
    }
}
