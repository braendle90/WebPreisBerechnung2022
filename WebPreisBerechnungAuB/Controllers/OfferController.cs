using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebPreisBerechnungAuB.Data;
using WebPreisBerechnungAuB.Models;
using WebPreisBerechnungAuB.Models.ViewModel;
using WebPreisBerechnungAuB.Repo;

namespace WebPreisBerechnungAuB.Controllers
{
    [Authorize]
    public class OfferController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IGetFromDB _getFromDB;
        private ICalculationPiecesLogoandPosition _calcRepo;

        public OfferController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            this._userManager = userManager;
            this._getFromDB = new GetFromDB(_context, userManager);
            this._calcRepo = new CalculationPiecesLogoandPosition(_context);
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var colorId = 2;
            var text = "Farbig";
            var colors = await _getFromDB.LoadColorsByFilter(x => x.ColorName.Contains(text));
            var allColors = await _getFromDB.LoadColorsByFilter();

            //var liste = _context.OrderPositionLogos
            //    .Include(x => x.Order)
            //    .Include(x => x.User)
            //    .Include(x => x.Order.Textil)
            //    .Include(x => x.Order.TextilColor)
            //    .Where(x => x.User == user)
            //    .AsEnumerable()
            //    .GroupBy(x => x.Order.OfferId)
            //    .Select(grp => new OfferVM
            //    {
            //        OfferId = grp.Key,
            //        OrderPostionLogoListe = grp.ToList()
            //    })
            //    .ToList();

            var liste = _context.OrderPositionLogos
                .Include(x => x.Order)
                .Include(x => x.Order.Textil)
                .Include(x => x.Order.TextilColor)
                .Where(x => x.User == user)
                .AsEnumerable()
                .GroupBy(x => x.Order.OfferId)
                .Select(grp => new OfferVM
                {
                    OfferId = grp.Key,
                    OrderPostionLogoListe = grp.ToList(),
                    Offer = _context.Offers.Where(x => x.OfferId == grp.Key).FirstOrDefault(),
                })
                .ToList();

            foreach (var item in liste)
            {
                item.Offer = _context.Offers.Where(x => x.OfferId == item.OfferId).FirstOrDefault();
            }

            return View(liste);

        }
    }
}
