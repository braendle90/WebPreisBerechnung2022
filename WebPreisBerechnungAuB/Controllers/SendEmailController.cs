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
using WebPreisBerechnungAuB.Helpers;
using WebPreisBerechnungAuB.Models;
using WebPreisBerechnungAuB.Models.ViewModel;
using WebPreisBerechnungAuB.Repo;
using WebPreisBerechnungAuB.Services;

namespace WebPreisBerechnungAuB.Controllers
{
    public class SendEmailController : Controller
    {




        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICalculationService _service;
        private readonly ITemplateReader template;
        private readonly IGetFromDB _getFromDB;
        private readonly Ihelper _helper;
        private readonly IEmailSender _emailSender;


        public SendEmailController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IEmailSender emailSender, 
            IWebHostEnvironment webHostEnvironment, ICalculationService service, ITemplateReader template)
        {
            this._context = context;
            this._userManager = userManager;
            this._webHostEnvironment = webHostEnvironment;
            _service = service;
            this.template = template;
            this._getFromDB = new GetFromDB(_context, userManager);
            this._helper = new helper(_context, userManager);
            _emailSender = emailSender;

        }
        public async Task<IActionResult> SendOfferMail()
        {

            var message = new Message(new string[] { "d.braendle@aub.at" },"Test mail with Attachments", "This is the content from our mail with attachments.");


            await _emailSender.SendEmailAsync(message);
            //"Test mail with Attachments"
            //"This is the content from our mail with attachments."


            //var message = new Message(new string[] { "angebot@aub.at" }, "Test email async", "This is the content from our async email.");
            //await _emailSender.SendEmailAsync(message);


            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> SendEmail(string id)
        {
            var list = await _service.GetCalculationVMs(id);
            var model = new SendOfferViewModel()
            {
                CalculationVMList = list,
                MailContent = new MailContent(),
            };
            model = template.ReadSendContingenteEmailFile(model);

            await _emailSender.SendMailViewModel(model);
            return RedirectToAction("Index", "Home");


        }
    }
}
