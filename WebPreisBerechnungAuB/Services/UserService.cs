using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using WebPreisBerechnungAuB.Models;
using WebPreisBerechnungAuB.Services.Interface;

namespace WebPreisBerechnungAuB.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(IHttpContextAccessor accessor, UserManager<ApplicationUser> userManager)
        {
            _accessor = accessor;
            _userManager = userManager;
        }
        public async Task<ApplicationUser> CurrentUser()
        {
            var claim = _accessor?.HttpContext?.User as ClaimsPrincipal;
            var user = await _userManager.FindByNameAsync(claim.Identity.Name);
            return user;
        }
    }
}
