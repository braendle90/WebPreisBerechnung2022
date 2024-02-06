using System.Collections.Generic;
using System.Threading.Tasks;
using WebPreisBerechnungAuB.Models;

namespace WebPreisBerechnungAuB.Services
{
    public interface ICalculationService
    {
        Task<List<CalculationVM>> GetCalculationVMs(string id);
    }
}