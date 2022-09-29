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
    public class TestController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IGetFromDB _getFromDB;

        public TestController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            this._userManager = userManager;
            this._getFromDB = new GetFromDB(_context, userManager);
        }
        public IActionResult Index()
        {
            var logo = _context.PositionLogos.FirstOrDefault();

            var read = _context.ExtraChargeList
                .Include(x => x.ExtraCharge)
                .ToList();   

            var list = new List<ExtraChargeList>();

            var extraCharge1 = new ExtraCharge
            {

                ChargeName = "Text Charge 11",
                ChargePrice = 99,
           
            };
            var extraCharge2 = new ExtraCharge
            {

                ChargeName = "Text Charge 2222",
                ChargePrice = 99,
          
            };

            var extraChargeList1 = new ExtraChargeList
            {
                ExtraCharge = extraCharge1,
                IsSelected = true,
                GroupName   = "gruppen_Name111111"
            };
            var extraChargeList2 = new ExtraChargeList
            {
                ExtraCharge = extraCharge2,
                IsSelected = true,
                GroupName = "gruppen_Name2222"
            };

            list.Add(extraChargeList1);
            list.Add(extraChargeList2);

            logo.ExtraChargeLists = list;

            _context.ExtraChargeList.AddRange(list);
            _context.PositionLogos.Update(logo);
            _context.SaveChanges();

            return View();
        }
    }
}
