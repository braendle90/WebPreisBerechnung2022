using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WebPreisBerechnungAuB
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
        Task SendEmailAsync(Message message);

    }
}
