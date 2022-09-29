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
    public class PositionController : Controller
    {


        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IGetFromDB _getFromDB;

        public PositionController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            this._userManager = userManager;
            this._getFromDB = new GetFromDB(_context, userManager);

        }
        [HttpGet]
        public async Task<IActionResult> Index(string? id)
        {

            var user = await _userManager.GetUserAsync(User);

            var PositionVMList = await _getFromDB.loadPositionLogoAndCreateVM(id,user);





            return View(PositionVMList);
        }
        [HttpGet]
        public async Task<IActionResult> AddOrEdit(int id, string offerId, int orderPositionId)
        {

            var user = await _userManager.GetUserAsync(User);
            PositionVM positionVM;

            var positionList = await _context.Positions.ToListAsync();
            var logoList = await _getFromDB.loadAllLogoslByOfferIdAndUser(offerId,user);

            var oplById = await _getFromDB.findOplById(id);

            if (id == 0)
            {
                positionVM = new PositionVM
                {
                    OrderId = 0,
                    PositionList = positionList,
                    LogoList = logoList,
                    TextilName = "",
                    OfferId = offerId,
                    PositionLogoId = 0,
                    OrderPositionId = orderPositionId,

                };


                return View("_EditPartialPosition", positionVM);

            }

            else
            {

                PositionLogo positionLogo = await _getFromDB.findPositionLogoById(id);



                positionVM = new PositionVM
                {
                    OrderPositionId = positionLogo.OrderPositionLogo.Id,
                    PositionList = positionList,
                    LogoList = logoList,
                    TextilName = positionLogo.OrderPositionLogo.Order.Textil.TextilName,
                    OfferId = offerId,
                    PositionLogoId = positionLogo.Id,
                    
                };

            }



            return View("_EditPartialPosition", positionVM);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("OfferId,OrderPositionId,OrderId,PositionLogoId,PositionId,LogoId,TextilName,OrderId,Id,Logo")] PositionVM model)
        {
            var user = await _userManager.GetUserAsync(User);
            var position = await _getFromDB.loadPositionById(model.PositionId);
            var logo = await _getFromDB.loadLogoById(model.LogoId);
            var orderPositionLogo = await _getFromDB.loadOrderPositionLogoById(model.OrderPositionId);
            var offerId = model.OfferId; 
            PositionVM positionVM;
            List<PositionVM> modelVm;


            if (ModelState.IsValid)
            {



                if (id == 0)
                {


                    var positionLogo = new PositionLogo
                    {

                        Logo = logo,
                        Position = position,
                        OrderPositionLogo = orderPositionLogo,


                    };
                    _context.Add(positionLogo);
                    await _context.SaveChangesAsync();

                }


                else
                {

                    PositionLogo positionLogo = await _getFromDB.findPositionLogoById(id);

                    positionLogo.Logo = logo;
                    positionLogo.Position = position;
                    positionLogo.OrderPositionLogo = orderPositionLogo;


                    _context.Update(positionLogo);
                    await _context.SaveChangesAsync();

                    positionVM = new PositionVM
                    {
                        OrderPositionId = positionLogo.OrderPositionLogo.Id,

                    };

                }

                modelVm = await _getFromDB.loadPositionLogoAndCreateVM(offerId,user);



                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAllPositionPartial", modelVm) });

            }


            modelVm = await _getFromDB.loadPositionLogoAndCreateVM(offerId, user);




            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "_ViewAllPositionPartial", modelVm) });
        }




        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _getFromDB.findPositionLogoById(id);

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
            var model = await _getFromDB.findPositionLogoById(id);
            var offerId = model.OrderPositionLogo.Order.OfferId;

            _context.PositionLogos.Remove(model);
            await _context.SaveChangesAsync();



            var modelVm = await _getFromDB.loadPositionLogoAndCreateVM(offerId,user);



            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAllPositionPartial", modelVm) });

        }

        private bool TransactionModelExists(int id)
        {
            return _context.Logos.Any(e => e.Id == id);
        }



    }
}
