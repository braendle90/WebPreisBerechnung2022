using System.Threading.Tasks;
using WebPreisBerechnungAuB.Models;

namespace WebPreisBerechnungAuB.Services.Interface;

public interface IUserService
{
    Task<ApplicationUser> CurrentUser();
}
