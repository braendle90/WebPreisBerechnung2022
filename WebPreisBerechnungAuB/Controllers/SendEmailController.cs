using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Tls;
using System.IO;
using System.Linq;
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


        public SendEmailController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IEmailSender emailSender, IWebHostEnvironment webHostEnvironment)
        {
            this._context = context;
            this._userManager = userManager;
            this._webHostEnvironment = webHostEnvironment;
            this._getFromDB = new GetFromDB(_context, userManager);
            this._helper = new helper(_context, userManager);
            _emailSender = emailSender;

        }
        public async Task<IActionResult> SendOfferMail(string body)
        {

            var message = new Message(new string[] { "angebot@aub.at" }, "Test mail with Attachments", "This is the content from our mail with attachments.", null);

            await _emailSender.SendEmailAsync(message);


            //var message = new Message(new string[] { "angebot@aub.at" }, "Test email async", "This is the content from our async email.");
            //await _emailSender.SendEmailAsync(message);


            return View();
        }
    }
}
