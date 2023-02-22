using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;
using WebPreisBerechnungAuB.Models.ViewModel;

namespace WebPreisBerechnungAuB
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
        Task SendMailViewModel(SendOfferViewModel model);
        Task SendEmailAsync(Message message);
    }
}
