using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebPreisBerechnungAuB.Data;
using WebPreisBerechnungAuB.Models;

namespace WebPreisBerechnungAuB.Controllers
{
    public class ExtraChargesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExtraChargesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExtraCharges
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExtraCharge.ToListAsync());
        }

        // GET: ExtraCharges/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extraCharge = await _context.ExtraCharge
                .FirstOrDefaultAsync(m => m.Id == id);
            if (extraCharge == null)
            {
                return NotFound();
            }

            return View(extraCharge);
        }

        // GET: ExtraCharges/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExtraCharges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ChargeName,ChargePrice,ChargeTyp,isOneTimeCharge")] ExtraCharge extraCharge)
        {
            if (ModelState.IsValid)
            {
                _context.Add(extraCharge);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(extraCharge);
        }

        // GET: ExtraCharges/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extraCharge = await _context.ExtraCharge.FindAsync(id);
            if (extraCharge == null)
            {
                return NotFound();
            }
            return View(extraCharge);
        }

        // POST: ExtraCharges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ChargeName,ChargePrice,ChargeTyp,isOneTimeCharge")] ExtraCharge extraCharge)
        {
            if (id != extraCharge.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(extraCharge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExtraChargeExists(extraCharge.Id))
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
            return View(extraCharge);
        }

        // GET: ExtraCharges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extraCharge = await _context.ExtraCharge
                .FirstOrDefaultAsync(m => m.Id == id);
            if (extraCharge == null)
            {
                return NotFound();
            }

            return View(extraCharge);
        }

        // POST: ExtraCharges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var extraCharge = await _context.ExtraCharge.FindAsync(id);
            _context.ExtraCharge.Remove(extraCharge);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExtraChargeExists(int id)
        {
            return _context.ExtraCharge.Any(e => e.Id == id);
        }
    }
}
