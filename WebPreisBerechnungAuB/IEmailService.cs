using System.Threading.Tasks;

namespace WebPreisBerechnungAuB
{
    public interface IEmailService
    {
        /// <summary>
        /// 1. Erstelle einen ViewModel welches die Daten welche zum kunden gesendet werden beinhaltet + die email und name des empfängers
        /// 2. Dieses ViewModel kommt in den Parameter der Task SendMailAsync() Methode
        /// 
        /// Mail.Kit
        /// </summary>
        /// <returns></returns>
        Task SendMailAsync();
    }
}
