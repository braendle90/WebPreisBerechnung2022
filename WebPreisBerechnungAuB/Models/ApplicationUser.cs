using Microsoft.AspNetCore.Identity;

namespace WebPreisBerechnungAuB.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string Company { get; set; }

        public string LastName { get; set; }
    }
}
