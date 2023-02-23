using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MimeKit.Text;
using MimeKit;
using System.Diagnostics;
using WebPreisBerechnungAuB.Models;
using MailKit.Net.Smtp;

namespace WebPreisBerechnungAuB.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult SendEmail(string body)
        {

            body = " hey Dominik";

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("ettie.reichel63@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("ettie.reichel63@ethereal.email"));
            email.Subject = "Tes Email From E-Mail ";
            email.Body = new TextPart(TextFormat.Html) { Text = body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate("ettie.reichel63@ethereal.email", "gsqNaxS4YRUdYbaePn");
            smtp.Send(email);
            smtp.Disconnect(true);

            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
