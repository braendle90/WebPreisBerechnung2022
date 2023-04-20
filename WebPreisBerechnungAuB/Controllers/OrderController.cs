using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPreisBerechnungAuB.Data;
using WebPreisBerechnungAuB.Models;
using WebPreisBerechnungAuB.Models.ViewModel;
using WebPreisBerechnungAuB.Repo;

namespace WebPreisBerechnungAuB.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IGetFromDB _getFromDB;

        public OrderController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            this._userManager = userManager;
            this._getFromDB = new GetFromDB(_context, userManager);
        }

        public async Task<IActionResult> Index()
        {

            var user = await _userManager.GetUserAsync(User);
            var orderVmList = new List<OrderVM>();



            //string guid = Guid.NewGuid().ToString();
            string guid = "56ddf9e6-4845-4830-9a39-3493c4ab01e3";

            var allOpl = await _getFromDB.loadAllOrderPositionLogoByUser(user);




            foreach (var opl in allOpl)
            {
                var orderVm = new OrderVM
                {
                    NumberOfPieces = opl.Order.NumberOfPieces,
                    TextilColorName = opl.Order.TextilColor.TextilColorName,
                    TextilName = opl.Order.Textil.TextilName,
                    OfferId = opl.Order.OfferId,
                    Id = opl.Id
                };

                orderVmList.Add(orderVm);
            }




            return View(orderVmList);
        }

        [HttpGet]
        public async Task<IActionResult> AddOrEdit(int? id, string offerId)
        {
            var user = await _userManager.GetUserAsync(User);

            var allTextils = await _getFromDB.loadAllTextils();
            var allTextilColor = await _getFromDB.loadAllTextilColor();

            if (id == 0)
            {
                var vm = new OrderVM
                {
                    OfferId = offerId,
                    TextilColorList = allTextilColor,
                    TextilList = allTextils,
                };

                return View("_EditPartialOrder", vm);

            }

            var oplById = await _getFromDB.findOplById(id);





            var editVm = new OrderVM
            {
                NumberOfPieces = oplById.Order.NumberOfPieces,
                TextilColorList = allTextilColor,
                TextilList = allTextils,
                OfferId = offerId,
                Id = oplById.Id,

            };



            return View("_EditPartialOrder", editVm);
        }
        [HttpPost]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("NumberOfPieces,TextilColorId,TextilId,OfferId")] OrderVM model)
        {
            var user = await _userManager.GetUserAsync(User);
            var textil = await _getFromDB.loadTextilById(model.TextilId);
            var textilColor = await _getFromDB.loadTextiColorlById(model.TextilColorId);
            var vmOpl = new OrderPositionLogo();
            var orderVmList = new List<OrderVM>();


            var order = new Order
            {
                NumberOfPieces = model.NumberOfPieces,
                OfferId = model.OfferId,
                Textil = textil,
                TextilColor = textilColor,
            };


            if (ModelState.IsValid)
            {

                if (id == 0)
                {
                    vmOpl.User = user;
                    vmOpl.Order = order;
                    await _getFromDB.writeOplToDb(vmOpl);
                }
                else
                {
                    vmOpl = await _getFromDB.findOplById(id);
                    vmOpl.Order = order;
                    vmOpl.User = user;
                    await _getFromDB.updateOplToDB(vmOpl);
                }

                var allOpl = await _getFromDB.loadAllOrderPositionLogoByUser(user);

                foreach (var opl in allOpl)
                {
                    var orderVm = new OrderVM
                    {
                        NumberOfPieces = opl.Order.NumberOfPieces,
                        TextilColorName = textilColor.TextilColorName,
                        TextilName = textil.TextilName,
                        OfferId = opl.Order.OfferId,
                        Id = opl.Id
                    };

                    orderVmList.Add(orderVm);

                }


                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAllOrderPartial", orderVmList) });
            }


            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "_ViewAllOrderPartial", model) });
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _getFromDB.findOplById(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var orderVmList = new List<OrderVM>();
            var model = await _getFromDB.findOplById(id);

            _context.OrderPositionLogos.Remove(model);
            await _context.SaveChangesAsync();

            var oplListNewLoad = await _context.OrderPositionLogos
                    .Include(x => x.User)
                    .Include(x => x.Order)
                    .Include(x => x.Order.Textil)
                    .Include(x => x.Order.TextilColor)
                    .Where(x => x.User == user)
                    .ToListAsync();

            var allOpl = await _getFromDB.loadAllOrderPositionLogoByUser(user);

            foreach (var opl in allOpl)
            {
                var orderVm = new OrderVM
                {
                    NumberOfPieces = opl.Order.NumberOfPieces,
                    TextilColorName = opl.Order.TextilColor.TextilColorName,
                    TextilName = opl.Order.Textil.TextilName,
                    OfferId = opl.Order.OfferId,
                    Id = opl.Id
                };

                orderVmList.Add(orderVm);

            }


            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAllOrderPartial", orderVmList) });

        }

        private bool TransactionModelExists(int id)
        {
            return _context.Logos.Any(e => e.Id == id);
        }



    }
}

