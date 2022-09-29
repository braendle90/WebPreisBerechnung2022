using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebPreisBerechnungAuB.Data;
using WebPreisBerechnungAuB.Models;
using WebPreisBerechnungAuB.Models.ViewModel;
using WebPreisBerechnungAuB.Repo;

namespace WebPreisBerechnungAuB.Controllers
{
    public class PriceTablesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IGetFromDB _getFromDB;
        private readonly UserManager<ApplicationUser> _userManager;

        public PriceTablesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this._getFromDB = new GetFromDB(_context, userManager);
            this._userManager = userManager;
        }

        // GET: PriceTables
        public async Task<IActionResult> Index()
        {

            //            public Textil Texil { get; set; }

            //public Color NumberColors { get; set; }
            //public RangeTable Range { get; set; }

            var model = await _getFromDB.loadAllScreenprintPrice();


            return View(model);
        }

        // GET: PriceTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priceTable = await _context.PriceTable
                .FirstOrDefaultAsync(m => m.Id == id);
            if (priceTable == null)
            {
                return NotFound();
            }

            return View(priceTable);
        }

        // GET: PriceTables/Create
        public async Task<IActionResult> Create()
        {

            var model = await _getFromDB.emptyPriceTableVM();

            return View(model);
        }

        // POST: PriceTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RangeFrom,RangeId,Price,RangeTo,TexilId,NumberColorsId,PriceTable,Price")] PriceTableVM model)
        {

            PriceTable priceTable = new PriceTable();

            Textil textil = await _getFromDB.loadTextilById(model.TexilId);
            Color color = await _getFromDB.loadAllColorById(model.NumberColorsId);
            var range = await _context.RangeTable.Where(x => x.Id == model.RangeId).FirstOrDefaultAsync();

            priceTable.NumberColors = color;
            priceTable.Price = model.Price;
            priceTable.Range = range;
            priceTable.Texil = textil;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(priceTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PriceTableExists(priceTable.Id))
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

            return View(priceTable);
        }

        // GET: PriceTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            var color = await _getFromDB.loadAllColor();
            var textil = await _getFromDB.loadAllTextils();
            var range = await _context.RangeTable.ToListAsync();


            
            

            if (id == null)
            {
                return NotFound();
            }

            var priceTable = await _getFromDB.loadScreenprintPriceByID(id);


            //var textilSorted = new List<Textil>();

            //textilSorted.Add(priceTable.Texil);

            //textil.Remove(priceTable.Texil);

            //textilSorted.AddRange(textil);

            


            if (priceTable == null)
            {
                return NotFound();
            }

            PriceTableVM priceTableVm = new PriceTableVM
            {
               
                PriceTable = priceTable,
                NumberColorList = color,
                TexilList = textil,
                RangeTableList = range,

            };


            return View(priceTableVm);
        }

        // POST: PriceTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RangeFrom,RangeId,Price,RangeTo,TexilId,NumberColorsId,PriceTable,Price")] PriceTableVM model)
        {
            PriceTable priceTable = await _context.PriceTable
                .Include(x => x.Range)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            Textil textil = await _getFromDB.loadTextilById(model.TexilId);    
            Color color = await _getFromDB.loadAllColorById(model.NumberColorsId);
            var range = await _context.RangeTable.Where(x => x.Id == model.RangeId).FirstOrDefaultAsync();

            priceTable.NumberColors = color;
            priceTable.Price = model.Price;
            priceTable.Range = range;
            priceTable.Texil = textil;


            




            if (id != priceTable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(priceTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PriceTableExists(priceTable.Id))
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
            return View(priceTable);
        }

        // GET: PriceTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priceTable = await _context.PriceTable
                .FirstOrDefaultAsync(m => m.Id == id);
            if (priceTable == null)
            {
                return NotFound();
            }

            return View(priceTable);
        }

        // POST: PriceTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var priceTable = await _context.PriceTable.FindAsync(id);
            _context.PriceTable.Remove(priceTable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PriceTableExists(int id)
        {
            return _context.PriceTable.Any(e => e.Id == id);
        }
    }
}
