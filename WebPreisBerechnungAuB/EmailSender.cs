using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit.Text;
using MimeKit;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using WebPreisBerechnungAuB.Models;

namespace WebPreisBerechnungAuB
{
    public class EmailSender 
    {
        public async Task SendEmailAsync(EMail emailModel)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("ettie.reichel63@ethereal.email"));
            email.To.Add(MailboxAddress.Parse(emailModel.emailAdressTo));
            email.Subject = emailModel.subject;
            email.Body = new TextPart(TextFormat.Html) { Text = emailModel.htmlMessage };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate("ettie.reichel63@ethereal.email", "gsqNaxS4YRUdYbaePn");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}



