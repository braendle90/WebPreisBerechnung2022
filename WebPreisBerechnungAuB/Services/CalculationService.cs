using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPreisBerechnungAuB.Data;
using WebPreisBerechnungAuB.Models;
using WebPreisBerechnungAuB.Repo;

namespace WebPreisBerechnungAuB.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService userService;
        private ICalculationPiecesLogoandPosition _calcRepo;
        private readonly Ihelper _helper;

        public CalculationService(ApplicationDbContext context, IUserService userService)
        {
            this._context = context;
            this.userService = userService;
            this._calcRepo = new CalculationPiecesLogoandPosition(_context);
            this._helper = new helper(_context);
        }

        public async Task<List<CalculationVM>> GetCalculationVMs(string id)
        {
            var user = await userService.CurrentUser();

            var checkOfferId = await _context.OrderPositionLogos
                .Include(x => x.User)
                .Include(x => x.Order)
                .FirstOrDefaultAsync(x => x.Order.OfferId == id);

            var positonLogoList = await _context.PositionLogos
                .Include(x => x.Logo)
                .Include(x => x.Logo.Color)
                .Include(x => x.Logo.User)
                .Include(x => x.Position)
                .Include(x => x.OrderPositionLogo).Include(x => x.OrderPositionLogo.Order)
                .Where(x => x.OrderPositionLogo.User == user)
                .Where(x => x.OrderPositionLogo.Order.OfferId == id).ToListAsync();

            var opl = await _context.OrderPositionLogos
                .Include(x => x.Order)
                .Include(x => x.Order.Textil)
                .Include(x => x.Order.TextilColor)
                .Include(x => x.User)
                .Where(x => x.User == user)
                .Where(x => x.Order.OfferId == id).ToListAsync();

            // Preisberechnung

            var ListofLogosWithDupes = new List<int>();
            var ListofPositionsWithDupes = new List<int>();

            //Create Alist of all LogoId and PositionID
            foreach (var item in positonLogoList)
            {
                ListofLogosWithDupes.Add(item.Logo.Id);
                ListofPositionsWithDupes.Add(item.Position.Id);
            }


            //Distinct that Logo and Positon List
            var ListofLogosDistinct = ListofLogosWithDupes.Distinct().ToList();
            var ListofPositionsDistinct = ListofPositionsWithDupes.Distinct().ToList();

            var oneLogoPositionPieces = new List<OneLogoAndPosition>();

            foreach (var logoid in ListofLogosDistinct)
            {
                foreach (var positionId in ListofPositionsDistinct)
                {
                    var notNullReturnModel = _calcRepo.calc(logoid, positionId, positonLogoList);

                    if (notNullReturnModel != null)
                    {
                        oneLogoPositionPieces.Add(notNullReturnModel);
                    }
                }
            }



            var list = new List<CalculationVM>();

            foreach (var item in opl)
            {
                CalculationVM calcvm = new CalculationVM();
                calcvm.OrderPositionLogo = item;

                list.Add(calcvm);
            }

            //List<ShowPriceModel> showPriceModeList = new List<ShowPriceModel>();

            //ShowPriceModel showPriceModel = new ShowPriceModel();
            //showPriceModel.Id = 123;
            //showPriceModeList.Add(showPriceModel);

            foreach (var data in positonLogoList)
            {

                var fillModel = oneLogoPositionPieces
                    .Where(x => x.Logo == data.Logo)
                    .Where(x => x.Position == data.Position)
                    .FirstOrDefault();


                ShowPriceCalculation showPriceCalculation = new ShowPriceCalculation();

                showPriceCalculation = await _helper.calculatExtraChargeListScreenprintAndTransfer(data, fillModel, positonLogoList);

                data.ExtraChargeLists = showPriceCalculation.ExtraChargeList;

                var anbringung = await _helper.priceofTransferApplication(data, fillModel);

                ShowPriceModel showPriceModel = new ShowPriceModel
                {
                    Logo = await _calcRepo.CalculationLogoPrice(data.Logo),
                    extraChargeLists = showPriceCalculation.ExtraChargeList,
                    Anbringung = anbringung,
                    Position = data.Position,
                    OrderPositionLogo = data.OrderPositionLogo,
                    PiecesofTextilWithThisLogo = fillModel.Pieces,
                    PricePerPices = showPriceCalculation.PricePerPices,
                    PricePerPicesTransfer = _calcRepo.PriceofTransfer(data, fillModel.Pieces),
                    TotalPriceTransfer = showPriceCalculation.TotalPriceTransfer,

                    TotalPriceScreenPrint = showPriceCalculation.TotalPriceScreenPrint,
                    PriceExtraCharge = showPriceCalculation.PriceExtraCharge,

                };

                list.Where(x => x.OrderPositionLogo == data.OrderPositionLogo).FirstOrDefault().ShowPriceModel.Add(showPriceModel);

                var calcTotalScreenprint = list.Where(x => x.OrderPositionLogo == data.OrderPositionLogo).FirstOrDefault().ShowPriceModel.Sum(x => x.TotalPriceScreenPrint);
                var calcTotalTransfer = list.Where(x => x.OrderPositionLogo == data.OrderPositionLogo).FirstOrDefault().ShowPriceModel.Sum(x => x.TotalPriceTransfer);

                list.Where(x => x.OrderPositionLogo == data.OrderPositionLogo).FirstOrDefault().OrderPositionLogo.Order.PriceScreenPrint = calcTotalScreenprint;
                list.Where(x => x.OrderPositionLogo == data.OrderPositionLogo).FirstOrDefault().OrderPositionLogo.Order.PriceTransfer = calcTotalTransfer;

            }


            return list;



        }


    }
}
