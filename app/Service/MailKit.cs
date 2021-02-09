using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;

namespace app.Service
{
    public class Mail_kit
    {
        public async Task SendMailAsync(string mail, string subject, string message)
        {

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Админ", "drogremtalpavlov@yandex.ru"));
            emailMessage.To.Add(new MailboxAddress("",mail));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text=message};

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.yandex.ru", 465, true);
                await client.AuthenticateAsync("drogremtalpavlov@yandex.ru", "21ruPAVLOV");
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }

        } 

    }
}
