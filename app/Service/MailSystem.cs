using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;


namespace app.Service
{
    public class MailSystem
    {

        public void SendMail(string mail, string subject,string message)
        {
            MailAddress from = new MailAddress("drogremtalpavlov@yandex.ru", "Админ");
            MailAddress to = new MailAddress(mail, "");
            MailMessage m = new MailMessage(from,to);

            m.Subject = subject;
            m.Body = message;
            SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 587);
            smtp.Credentials = new NetworkCredential("drogremtalpavlov@yandex.ru", "21ruPAVLOV");
            smtp.EnableSsl = false;
            smtp.SendMailAsync(m);
        }
    }
}
