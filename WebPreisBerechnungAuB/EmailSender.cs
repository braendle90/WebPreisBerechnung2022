using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace WebPreisBerechnungAuB
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            throw new System.NotImplementedException();
        }
    }
}
