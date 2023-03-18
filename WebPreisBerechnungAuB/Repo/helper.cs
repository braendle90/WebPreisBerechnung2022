using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPreisBerechnungAuB.Data;
using WebPreisBerechnungAuB.Models;
using WebPreisBerechnungAuB.Models.ViewModel;

namespace WebPreisBerechnungAuB.Repo

{
    public class helper : Ihelper
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private ICalculationPiecesLogoandPosition _calcRepo;

        public helper(ApplicationDbContext context, UserManager<ApplicationUser> userManager = null)
        {
            this._context = context;
            this._calcRepo = new CalculationPiecesLogoandPosition(_context);
        }


        public async Task<List<SelectListItem>> findSelectedExtraChargeList(List<int> extraChargeList)
        {

            List<SelectListItem> items = new List<SelectListItem>();


            var index = 0;


            var extraCharge = await _context.ExtraCharge.ToListAsync();

            foreach (var item in extraCharge)
            {
                items.Add(new SelectListItem
                {
                    Text = item.ChargeName.ToString(),
                    Value = item.Id.ToString(),
                    //Group = new SelectListGroup() { Name = "First Group" }
                });
            }


            foreach (var item in extraChargeList)
            {

                items.Find(x => x.Value == item.ToString()).Selected = true;

            }
            return items;
        }

        public async Task<List<ExtraChargeList>> CreateExtraChargeList(LogoVM logovm)
        {


            var newExtraChargeList = new List<ExtraChargeList>();

            foreach (var item in logovm.ExtraChargeListsModel)
            {
                var newExtraCharge = new ExtraChargeList
                {
                    ExtraCharge = _context.ExtraCharge.Find(item.ExtraCharge.Id),
                    IsSelected = item.IsSelected,
                    Logo = logovm.Logo,
                    ChargePieces = logovm.Logo.Color.NumberOfColors,
                    };





                newExtraChargeList.Add(newExtraCharge);

            }

            _context.AddRange(newExtraChargeList);
            _context.SaveChanges();

            return newExtraChargeList;
        }

        public async Task<List<ExtraChargeList>> updateExtraChargeList(LogoVM logovm)
        {
            var updateExtraChargeList = new List<ExtraChargeList>();

            foreach (var item in logovm.ExtraChargeListsModel)
            {

                var extraChargeListLoading = await _context.ExtraChargeList
                    .Include(x => x.ExtraCharge)
                    .Where(x => x.Id == item.Id)
                    .FirstOrDefaultAsync();

                extraChargeListLoading.IsSelected = item.IsSelected;
                extraChargeListLoading.ChargePieces = logovm.Logo.Color.NumberOfColors;

                if (extraChargeListLoading.ExtraCharge.Id == 1 || extraChargeListLoading.ExtraCharge.Id == 2)
                {
                    extraChargeListLoading.ChargePriceTotal = (logovm.Logo.Color.NumberOfColors * extraChargeListLoading.ExtraCharge.ChargePrice);

                }
                updateExtraChargeList.Add(extraChargeListLoading);
            }

            //// add ExtraCharge for Transfer
            //var extraChargeTransfer = await _context.ExtraCharge.Where(x => x.ChargeTyp == "Transfer").FirstOrDefaultAsync();
            //var extraChargeListTransferAdd = new ExtraChargeList
            //{
            //    ExtraCharge = extraChargeTransfer,
            //    IsSelected = true,
            //    Logo = logovm.Logo,
            //};
            //updateExtraChargeList.Add(extraChargeListTransferAdd);


            _context.ExtraChargeList.UpdateRange(updateExtraChargeList);
            await _context.SaveChangesAsync();

            return updateExtraChargeList;

        }

        public async Task<List<ExtraChargeList>> loadExtraChargeListFromLogo(WebPreisBerechnungAuB.Models.Logo logo)
        {


            List<ExtraChargeList> updateExtraChargeList = await _context.ExtraChargeList
                .Include(x => x.ExtraCharge)
                .Include(x => x.Logo)
                .Where(x => x.Logo == logo)
                .Where(x => x.IsSelected == true)
                .Where(x => x.ExtraCharge.ChargeTyp == "Logo")
                .ToListAsync();



            return updateExtraChargeList;
        }

        public async Task<ExtraChargeList> loadExtraChargeListFromTransfer(WebPreisBerechnungAuB.Models.Logo logo, PositionLogo data, OneLogoAndPosition fillModel)
        {
            ExtraChargeList updateExtraChargeList = await _context.ExtraChargeList
                .Include(x => x.ExtraCharge)
                .Include(x => x.Logo)
                .Where(x => x.Logo == logo)
                .Where(x => x.IsSelected == true)
                .Where(x => x.ExtraCharge.ChargeTyp == "Transfer")
                .FirstOrDefaultAsync();

            var applicationPrice = (decimal)_calcRepo.ApplicationTransferPrice(data, data.Logo.LogoSurfaceSize, fillModel.Pieces);
            var applicationPricePieces = (applicationPrice * data.OrderPositionLogo.Order.NumberOfPieces);
            updateExtraChargeList.ExtraCharge.ChargePrice = applicationPricePieces;

            return updateExtraChargeList;

        }

        public async Task<decimal> priceofTransferApplication(PositionLogo data, OneLogoAndPosition fillModel)
        {
            var applicationPrice = (decimal)_calcRepo.ApplicationTransferPrice(data, data.Logo.LogoSurfaceSize, fillModel.Pieces);
            var applicationPricePieces = (applicationPrice * data.OrderPositionLogo.Order.NumberOfPieces);

            return applicationPricePieces;
        }

        public async Task<ShowPriceCalculation> calculatExtraChargeListScreenprintAndTransfer(PositionLogo data, OneLogoAndPosition fillModel)
        {
            List<ExtraChargeList> extraChargeLists = new List<ExtraChargeList>();


            var extraChargeListsLogo = await loadExtraChargeListFromLogo(data.Logo);

            //  ExtraChargeList extraChargeListsTransfer = new ExtraChargeList();

            // extraChargeListsTransfer = await loadExtraChargeListFromTransfer(data.Logo, data, fillModel);



            var priceExtraLogo = extraChargeListsLogo.Sum(x => x.ChargePriceTotal);
            var applicationPrice = (decimal)_calcRepo.ApplicationTransferPrice(data, data.Logo.LogoSurfaceSize, fillModel.Pieces);
            var applicationPricePieces = (applicationPrice * data.OrderPositionLogo.Order.NumberOfPieces);

            var priceScreenprint = _calcRepo.priceOfPrint(data, fillModel.Pieces);
            var totalPriceScreenprint = priceExtraLogo + priceScreenprint;
            var priceTransfer = _calcRepo.PriceofTransfer(data, fillModel.Pieces);
            var totalPriceTransfer = (applicationPricePieces + priceTransfer);
            //extraChargeListsTransfer.ExtraCharge.ChargePrice = applicationPricePieces;

            // extraChargeLists.Add(extraChargeListsTransfer);
            extraChargeLists.AddRange(extraChargeListsLogo);

            ShowPriceCalculation showPriceCalculation = new ShowPriceCalculation
            {
                ExtraChargeList = extraChargeLists,
                PriceExtraCharge = priceExtraLogo,
                PricePerPices = priceScreenprint,
                TotalPriceScreenPrint = totalPriceScreenprint,
                TotalPriceTransfer = totalPriceTransfer,
            };


            return showPriceCalculation;
        }

    }

}
