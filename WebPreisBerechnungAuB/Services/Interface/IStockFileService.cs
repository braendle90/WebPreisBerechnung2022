using System.Collections.Generic;
using System.Threading.Tasks;
using WebPreisBerechnungAuB.Models;

namespace WebPreisBerechnungAuB.Services.Interface
{
    public interface IStockFileService
    {
        Task<IEnumerable<Inventory>> GetInventoriesAsync();
    }
}
