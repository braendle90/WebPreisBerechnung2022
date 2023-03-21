using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class PriceTableTransfersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IGetFromDB _getFromDB;
        private readonly Ihelper _helper;

        public PriceTableTransfersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            this._userManager = userManager;
            this._getFromDB = new GetFromDB(_context, userManager);
            this._helper = new helper(_context, userManager);
        }

        // GET: PriceTableTransfers
        public async Task<IActionResult> Index()
        {

            var modelVMList = new PriceTableTransferVM();

            var allPriceTableTransfer = await _getFromDB.GetAllPriceTableTransfer();

            modelVMList.PriceTableTransferList = allPriceTableTransfer;

            return View(modelVMList);

        }




        // GET: PriceTableTransfers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priceTableTransfer = await _context.PriceTableTransfer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (priceTableTransfer == null)
            {
                return NotFound();
            }

            return View(priceTableTransfer);
        }

        // GET: PriceTableTransfers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PriceTableTransfers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Price")] PriceTableTransfer priceTableTransfer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(priceTableTransfer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(priceTableTransfer);
        }

        // GET: PriceTableTransfers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priceTableTransfer = await _context.PriceTableTransfer.FindAsync(id);
            var rangePriceTableList = await _context.RangeSurfaceSizes.ToListAsync();
            var textilList = await _getFromDB.loadAllTextils();


            var PriceTableTransferVM = new PriceTableTransferVM
            {
                Price = (decimal)priceTableTransfer.Price,
                TexilList = textilList,
                RangeLogoList = rangePriceTableList,



            };

            if (priceTableTransfer == null)
            {
                return NotFound();
            }
            return View(PriceTableTransferVM);
        }

        // POST: PriceTableTransfers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TexilId,RangeLogo,RangeLogo,Texil,Price")] PriceTableTransferVM priceTableTransfer)
        {

            var textil = await _getFromDB.loadTextilById(priceTableTransfer.Texil.Id);
            var rangeSurface = await _context.RangeSurfaceSizes.Where(x =>x.Id == priceTableTransfer.RangeLogo.Id).FirstOrDefaultAsync();

            var model = new PriceTableTransfer 
            {
                Id = id,
                Price = (double)priceTableTransfer.Price,   
                RangeLogo = rangeSurface,
                Texil = textil,

            };


            if (id != priceTableTransfer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PriceTableTransferExists(priceTableTransfer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(priceTableTransfer);
        }

        // GET: PriceTableTransfers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priceTableTransfer = await _context.PriceTableTransfer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (priceTableTransfer == null)
            {
                return NotFound();
            }

            return View(priceTableTransfer);
        }

        // POST: PriceTableTransfers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var priceTableTransfer = await _context.PriceTableTransfer.FindAsync(id);
            _context.PriceTableTransfer.Remove(priceTableTransfer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PriceTableTransferExists(int id)
        {
            return _context.PriceTableTransfer.Any(e => e.Id == id);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePrice(PriceTableVM model)

        {

            var priceTable = await _getFromDB.GetAllPriceTableTransfer();

            foreach (var priceTransfer in priceTable)
            {

                priceTransfer.Price = (priceTransfer.Price / 100) * (100 + (double)model.PriceUpdatePercent);

                _context.Update(priceTransfer);
                await _context.SaveChangesAsync();
            }


            return RedirectToAction(nameof(Index));
        }


    }
}
