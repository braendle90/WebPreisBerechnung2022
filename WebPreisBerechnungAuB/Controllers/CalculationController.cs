using System.Collections.Generic;
using WebPreisBerechnungAuB.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebPreisBerechnungAuB.Data;
using WebPreisBerechnungAuB.Models.ViewModel;
using WebPreisBerechnungAuB.Repo;
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


