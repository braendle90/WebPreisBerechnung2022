using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Tls;
using System.Threading.Tasks;
using WebPreisBerechnungAuB.Data;
using WebPreisBerechnungAuB.Models;
using WebPreisBerechnungAuB.Repo;

namespace WebPreisBerechnungAuB.Controllers
{
    public class SendEmailController : Controller
    {




        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IGetFromDB _getFromDB;
        private readonly Ihelper _helper;
        private readonly IEmailSender _emailSender;



        public SendEmailController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            this._context = context;
            this._userManager = userManager;
            this._webHostEnvironment = webHostEnvironment;
            this._getFromDB = new GetFromDB(_context, userManager);
            this._helper = new helper(_context, userManager);
            
        }
        public async Task<IActionResult> SendOfferMail(string body)
        {
            var user = await _userManager.GetUserAsync(User);

            var mail = new EMail();
            mail.emailAdressTo = user.Email;
            mail.htmlMessage = body;   
            mail.subject = body;



            var sender = new EmailSender();
            sender.SendEmailAsync(mail);        


            return View();
        }
    }
}
