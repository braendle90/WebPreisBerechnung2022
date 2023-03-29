using Microsoft.AspNetCore.Mvc;
using WebPreisBerechnungAuB.Data;

namespace WebPreisBerechnungAuB.Controllers
{
    public class DesignerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DesignerController(ApplicationDbContext context)
        {
            this._context = context;
        }


        public IActionResult Index()
        {


            return View();
        }

        public IActionResult LoadImage()
        {



            return View("_EditPartialDesigner");


        }
    }
}
