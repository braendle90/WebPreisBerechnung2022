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
    public class LogoSavedController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IGetFromDB _getFromDB;

        public LogoSavedController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            this._userManager = userManager;
            this._getFromDB = new GetFromDB(_context, userManager);
        }

        // GET: LogoSaved
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            var allLogosFromUser = await _getFromDB.getAllLogosFromUser(user);


            return View(allLogosFromUser);
        }

        // GET: LogoSaved/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logo = await _context.Logos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (logo == null)
            {
                return NotFound();
            }

            return View(logo);
        }

        // GET: LogoSaved/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LogoSaved/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LogoName,SurfaceWidht,SurfaceHight,LogoSurfaceSize,OfferId,isOld,LogoPrice,PricePerScreen,TotalPriceScreenPrint,TotalPriceTransfer,TransferLogoPrice,isLogoStorage")] Logo logo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(logo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(logo);
        }

        // GET: LogoSaved/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logo = await _context.Logos.FindAsync(id);
            if (logo == null)
            {
                return NotFound();
            }
            return View(logo);
        }

        // POST: LogoSaved/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LogoName,SurfaceWidht,SurfaceHight,LogoSurfaceSize,OfferId,isOld,LogoPrice,PricePerScreen,TotalPriceScreenPrint,TotalPriceTransfer,TransferLogoPrice,isLogoStorage")] Logo logo)
        {
            if (id != logo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(logo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogoExists(logo.Id))
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
            return View(logo);
        }

        // GET: LogoSaved/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logo = await _context.Logos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (logo == null)
            {
                return NotFound();
            }

            return View(logo);
        }

        // POST: LogoSaved/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var logo = await _context.Logos.FindAsync(id);
            _context.Logos.Remove(logo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LogoExists(int id)
        {
            return _context.Logos.Any(e => e.Id == id);
        }
    }
}
