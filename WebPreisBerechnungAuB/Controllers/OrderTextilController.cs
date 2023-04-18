using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPreisBerechnungAuB.Data;
using WebPreisBerechnungAuB.Models;
using WebPreisBerechnungAuB.Models.ViewModel;
using WebPreisBerechnungAuB.Repo;

namespace WebPreisBerechnungAuB.Controllers
{
    [Authorize]
    public class OrderTextilController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IGetFromDB _getFromDB;

        public OrderTextilController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            this._userManager = userManager;
            this._getFromDB = new GetFromDB(_context, userManager);
        }

        public async Task<IActionResult> Index(string? id)
        {

            Offer offer = null;


            if (id == null)
            {
                offer = new Offer
                {
                    OfferId = Guid.NewGuid().ToString(),
                    IsOrdered = false,
                };

                _context.Add(offer);
                await _context.SaveChangesAsync();

            }
            else
            {

                offer = await _context.Offers.Where(x => x.OfferId == id).FirstOrDefaultAsync();


            }



            ApplicationUser user = await _userManager.GetUserAsync(User);
            //string guid = "56dd6-4845-4830-9a39-3493c4ab01e3";
            //string guid = "56ddf9e6-4845-4830-9a39-3493c4ab01e3";

            var allOpl = await _getFromDB.loadAllOrderPositionLogoByUserAndOfferId(user, offer.OfferId);





            var orderVm = new OrderVMList
            {
                OrderPositionLogos = allOpl,
                OfferId = offer.OfferId,
                Offer = offer,

            };






            return View(orderVm);
        }




        [HttpPost]
        public async Task<IActionResult> AddOrderName(string? offerId, string offerName)
        {
            if (offerName == null)
            {
                offerName = " ";
            }


            Offer offer = await _context.Offers.Where(x => x.OfferId == offerId).FirstOrDefaultAsync();
            var user = await _userManager.GetUserAsync(User);

            if (offerName == null)
            {
                offer.OfferName = "Angebot ohne Name";
            }
            else
            {
                offer.OfferName = offerName;
            }

            _context.Update(offer);
            await _context.SaveChangesAsync();


            var allOpl = await _getFromDB.loadAllOrderPositionLogoByUserAndOfferId(user, offerId);

            var orderVm = new OrderVMList
            {
                OrderPositionLogos = allOpl,
                OfferId = offerId,
                Offer = offer,

            };




            var html = Helper.RenderRazorViewToString(this, "_ViewAllOrderPartialList", orderVm);

            return Json(new { isValid = true, orderName = offerName });

            //var html = Helper.RenderRazorViewToString(this, "_ViewAllOrderPartialList", orderVm);

            //return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAllOrderPartialList", orderVm) });


        }

        [HttpGet]
        public async Task<IActionResult> AddOrEdit(int? id, string offerId)
        {
            var user = await _userManager.GetUserAsync(User);
            Offer offer = await _context.Offers.Where(x => x.OfferId == offerId).FirstOrDefaultAsync();

            var allTextils = await _getFromDB.loadAllTextils();
            var allTextilColor = await _getFromDB.loadAllTextilColor();

            if (id == 0)
            {
                var vm = new OrderVMList
                {
                    OfferId = offerId,
                    TextilColorList = allTextilColor,
                    TextilList = allTextils,
                    Offer = offer,
                };

                return View("_EditPartialOrder", vm);

            }

            var oplById = await _getFromDB.findOplById(id);





            var editVm = new OrderVMList
            {
                NumberOfPieces = oplById.Order.NumberOfPieces,
                TextilColorList = allTextilColor,
                TextilList = allTextils,
                OfferId = offerId,
                Id = oplById.Id,
                Offer = offer,

            };



            return View("_EditPartialOrder", editVm);
        }
        [HttpPost]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("NumberOfPieces,TextilColorId,TextilId,OfferId")] OrderVMList model)
        {
            var user = await _userManager.GetUserAsync(User);
            var textil = await _getFromDB.loadTextilById(model.TextilId);
            var textilColor = await _getFromDB.loadTextiColorlById(model.TextilColorId);
            var vmOpl = new OrderPositionLogo();
            var orderVmList = new List<OrderVMList>();
            Offer offer = await _context.Offers.Where(x => x.OfferId == model.OfferId).FirstOrDefaultAsync();


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


                var allOpl = await _getFromDB.loadAllOrderPositionLogoByUserAndOfferId(user, model.OfferId);

                var orderVm = new OrderVMList
                {
                    OrderPositionLogos = allOpl,
                    OfferId = model.OfferId,
                    Offer = offer,

                };





                var html = Helper.RenderRazorViewToString(this, "_ViewAllOrderPartialList", orderVm);

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAllOrderPartialList", orderVm) });
            }


            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "_ViewAllOrderPartialList", model) });
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

            Offer offer = null;
            var user = await _userManager.GetUserAsync(User);
            OrderPositionLogo model = await _getFromDB.findOplById(id);
            var offerId = model.Order.OfferId;

            await _getFromDB.removeOrderPositionFromOrderAndUser(id, user);


            var allOpl = await _getFromDB.loadAllOrderPositionLogoByUserAndOfferId(user, offerId);



            offer = await _context.Offers.Where(x => x.OfferId == offerId).FirstOrDefaultAsync();




            var orderVm = new OrderVMList
            {
                OfferId = offerId,
                OrderPositionLogos = allOpl,
                Offer = offer,

            };




            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAllOrderPartialList", orderVm) });

        }

        private bool TransactionModelExists(int id)
        {
            return _context.Logos.Any(e => e.Id == id);
        }



    }



}

