using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebPreisBerechnungAuB.Services;

namespace WebPreisBerechnungAuB.Controllers
{
    public class CalculationController : Controller
    {
        private readonly ICalculationService _service;

        public CalculationController(ICalculationService service)
        {
            _service = service;
        }



        [HttpGet]
        public async Task<IActionResult> Index(string? id)
        {
            var list = await _service.GetCalculationVMs(id);

            return View("ShowPriceTable", list);
        }


    }
}


