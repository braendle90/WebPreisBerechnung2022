using System.Threading.Tasks;
using WebPreisBerechnungAuB.Models;

namespace WebPreisBerechnungAuB.Services
{
    public interface IUserService
    {

        Task<ApplicationUser> CurrentUser();

    }
}
