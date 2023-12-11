using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPreisBerechnungAuB.Data;
using WebPreisBerechnungAuB.Models;
using WebPreisBerechnungAuB.Models.ViewModel;

namespace WebPreisBerechnungAuB.Repo
{


    public class GetFromDB : IGetFromDB
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public GetFromDB(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            this._userManager = userManager;
        }


        public async Task<List<Textil>> loadAllTextils()
        {

            var allTextils = await _context.Textils.ToListAsync();

            return allTextils;
        }

        public async Task<List<Color>> loadAllColor()
        {

            List<Color> allColor = await _context.Colors.ToListAsync();

            return allColor;
        }

        public async Task<Color> loadAllColorById(int? id)
        {

            Color Color = await _context.Colors
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return Color;
        }

        public async Task<Textil> loadTextilById(int id)
        {

            var TextilById = await _context.Textils.Where(x => x.Id == id).FirstOrDefaultAsync();

            return TextilById;
        }

        public async Task<Position> loadPositionById(int id)
        {
            var PositionById = await _context.Positions.FindAsync(id);

            return PositionById;
        }


        public async Task<List<SelectListItem>> loadExtraCharges()
        {

            List<SelectListItem> items = new List<SelectListItem>();

            var index = 0;


            var extraCharge = await _context.ExtraCharge.ToListAsync();

            foreach (var item in extraCharge)
            {

                if (index == 2)
                {
                    items.Add(new SelectListItem
                    {
                        Text = item.ChargeName.ToString(),
                        Value = item.Id.ToString(),
                        Selected = true,
                    });

                }
                else
                {


                    items.Add(new SelectListItem
                    {
                        Text = item.ChargeName.ToString(),
                        Value = item.Id.ToString(),
                        //Group = new SelectListGroup() { Name = "First Group" }
                    });
                }
                index++;
            }
            return items;
        }

        public async Task<List<PriceTable>> loadAllScreenprintPrice()
        {

            List<PriceTable> model = await _context.PriceTable
                .Include(x => x.Range)
                .Include(x => x.Texil)
                .Include(x => x.NumberColors)
                .ToListAsync();

            return model;
        }

        public async Task<PriceTable> loadScreenprintPriceByID(int? id)
        {

            PriceTable model = await _context.PriceTable
                .Include(x => x.Range)
                .Include(x => x.Texil)
                .Include(x => x.NumberColors)
                .Where(x => x.Id == id).FirstOrDefaultAsync();

            return model;
        }

        public async Task<PriceTableVM> emptyPriceTableVM()
        {
            var color = await loadAllColor();
            var textil = await loadAllTextils();
            var range = await _context.RangeTable.ToListAsync();

            PriceTableVM priceTableVm = new PriceTableVM
            {

                PriceTable = null,
                NumberColorList = color,
                TexilList = textil,
                RangeTableList = range,

            };

            return priceTableVm;
        }

        public async Task<List<TextilColor>> loadAllTextilColor()
        {
            var allTextilColor = await _context.TextilColors.ToListAsync();

            return allTextilColor;
        }

        public async Task<List<PositionLogo>> loadAllPositionLogosByOfferId(string offerId)
        {

            var allPositionLogosById = await _context.PositionLogos
                .Include(x => x.Position)
                .Include(x => x.Logo)
                .Include(x => x.Logo.Color)
                .Include(x => x.Logo.File)
                .Include(x => x.OrderPositionLogo)
                .Include(x => x.OrderPositionLogo.Order)
                .Include(x => x.OrderPositionLogo.Order.Textil)
                .Include(x => x.OrderPositionLogo.Order.TextilColor)
                .Include(x => x.OrderPositionLogo.User)
                .Where(x => x.Logo.OfferId == offerId).ToListAsync();

            return allPositionLogosById;
        }

        public async Task<List<PositionLogo>> loadAllPositionLogosByOfferIdAndUser(string offerId, ApplicationUser user)
        {

            var allPositionLogosById = await _context.PositionLogos
                .Include(x => x.Position)
                .Include(x => x.Logo)
                .Include(x => x.Logo.Color)
                .Include(x => x.Logo.File)
                .Include(x => x.OrderPositionLogo)
                .Include(x => x.OrderPositionLogo.Order)
                .Include(x => x.OrderPositionLogo.Order.Textil)
                .Include(x => x.OrderPositionLogo.Order.TextilColor)
                .Include(x => x.OrderPositionLogo.User)
                .Where(x => x.OrderPositionLogo.User == user)
                .Where(x => x.Logo.OfferId == offerId).ToListAsync();

            return allPositionLogosById;
        }

        public async Task<List<PositionLogo>> loadAllPositionLogosByUser(ApplicationUser user)
        {

            var allPositionLogosById = await _context.PositionLogos
                .Include(x => x.Position)
                .Include(x => x.Logo)
                .Include(x => x.Logo.Color)
                .Include(x => x.Logo.File)
                .Include(x => x.OrderPositionLogo)
                .Include(x => x.OrderPositionLogo.Order)
                .Include(x => x.OrderPositionLogo.Order.Textil)
                .Include(x => x.OrderPositionLogo.Order.TextilColor)
                .Include(x => x.OrderPositionLogo.User)
                .Where(x => x.OrderPositionLogo.User == user)
                .ToListAsync();

            return allPositionLogosById;
        }

        public async Task removeOrderPositionFromOrderAndUser(int orderId, ApplicationUser user)
        {




            var allPositionLogos = await _context.PositionLogos
         .Include(x => x.Position)
         .Include(x => x.Logo)
         .Include(x => x.Logo.Color)
         .Include(x => x.Logo.File)
         .Include(x => x.OrderPositionLogo)
         .Include(x => x.OrderPositionLogo.Order)
         .Include(x => x.OrderPositionLogo.Order.Textil)
         .Include(x => x.OrderPositionLogo.Order.TextilColor)
         .Include(x => x.OrderPositionLogo.User)
         .Where(x => x.OrderPositionLogo.User == user)
         .Where(x => x.OrderPositionLogo.Id == orderId).FirstOrDefaultAsync();

            //Change the Logo to null that the Logo can be delete
            if (allPositionLogos != null)
            {
                allPositionLogos.OrderPositionLogo = null;


                _context.Update(allPositionLogos);
                await _context.SaveChangesAsync();


            }
            OrderPositionLogo ordePosition = await findOplById(orderId);

            Order order = ordePosition.Order;
            order.Textil = null;
            order.TextilColor = null;

            _context.Update(order);
            _context.Remove(order);
            await _context.SaveChangesAsync();



        }

        public async Task<ExtraChargeList> GetExtraChargeListByLogoAsync(WebPreisBerechnungAuB.Models.Logo logo)
        {

            var extraCharge = await _context.ExtraChargeList
                 .Include(x => x.Logo)
                 .Include(x => x.ExtraCharge)
                 .Where(x => x.Logo == logo).FirstOrDefaultAsync();

            return extraCharge;
        }

        public async Task RemoveLogoFromExtraChargeByLogo(WebPreisBerechnungAuB.Models.Logo logo)
        {
            var extraCharge = await GetExtraChargeListByLogoAsync(logo);

            extraCharge.Logo = null;

            _context.Update(extraCharge);
            await _context.SaveChangesAsync();

        }

        public async Task RemoveExtraChargeListByLogo(WebPreisBerechnungAuB.Models.Logo logo)
        {
            var extraChargeList = await _context.ExtraChargeList
                .Include(x => x.Logo)
                .Include(x => x.ExtraCharge)
                .Where(x => x.Logo == logo).ToListAsync();


            _context.RemoveRange(extraChargeList);
            await _context.SaveChangesAsync();
        }


        public async Task removeLogoFromPositionLogoByLogoIdAndUser(int logoId, ApplicationUser user)
        {

            WebPreisBerechnungAuB.Models.Logo logoToRemove = await loadLogoById(logoId);

            await RemoveExtraChargeListByLogo(logoToRemove);


            var allPositionLogosById = await _context.PositionLogos
                .Include(x => x.Position)
                .Include(x => x.Logo)
                .Include(x => x.Logo.File)
                .Include(x => x.Logo.Color)
                .Include(x => x.OrderPositionLogo)
                .Include(x => x.OrderPositionLogo.Order)
                .Include(x => x.OrderPositionLogo.Order.Textil)
                .Include(x => x.OrderPositionLogo.Order.TextilColor)
                .Include(x => x.OrderPositionLogo.User)
                .Where(x => x.OrderPositionLogo.User == user)
                .Where(x => x.Logo == logoToRemove).FirstOrDefaultAsync();

            //Change the Logo to null that the Logo can be delete
            if (allPositionLogosById != null)
            {
                allPositionLogosById.Logo = null;


                _context.Update(allPositionLogosById);
                await _context.SaveChangesAsync();


            }

            logoToRemove.Color = null;
            _context.Update(logoToRemove);
            _context.Remove(logoToRemove);
            await _context.SaveChangesAsync();


        }

        public async Task<LogoVM> loadallOplAndCreateVm(string id, ApplicationUser user)
        {
            List<Color> colorList = await loadAllColor();

            List<WebPreisBerechnungAuB.Models.Logo> logoList = await loadAllLogoslByOfferIdAndUser(id, user);

            List<PositionLogo> positionLogo = await loadAllPositionLogosByOfferIdAndUser(id, user);

            var modelVm = new LogoVM
            {
                ColorList = colorList,
                OfferId = id,
                LogoList = logoList,
                PositionLogo = positionLogo

            };

            return modelVm;
        }



        public async Task<LogoVM> loadallOplAndCreateVmFromUser(ApplicationUser user)
        {
            List<Color> colorList = await loadAllColor();

            List<WebPreisBerechnungAuB.Models.Logo> logoList = await loadAllLogoslByUser(user);

            List<PositionLogo> positionLogo = await loadAllPositionLogosByUser(user);

            var modelVm = new LogoVM
            {
                ColorList = colorList,
                LogoList = logoList,
                PositionLogo = positionLogo

            };

            return modelVm;
        }

        public async Task<LogoVM> loadAllLogosFromUserAndCreateLogoVM(ApplicationUser user)
        {
            List<Color> colorList = await loadAllColor();

            List<WebPreisBerechnungAuB.Models.Logo> logoList = await getAllLogosFromUser(user);

            //List<PositionLogo> positionLogo = await loadAllPositionLogosByOfferIdAndUser(id, user);

            var modelVm = new LogoVM
            {
                ColorList = colorList,
                LogoList = logoList,
                // PositionLogo = positionLogo

            };

            return modelVm;
        }

        public async Task<List<Position>> findAllPosition()
        {

            var allPosition = await _context.Positions.ToListAsync();

            return allPosition;

        }

        public async Task<List<PositionVM>> loadPositionLogoAndCreateVM(string id, ApplicationUser user)
        {


            PositionVM modelVm = null;


            var positionList = await _context.Positions.ToListAsync();
            var logoList = await loadAllLogoslByOfferIdAndUser(id, user);
            List<PositionLogo> positionLogoList = await loadAllPositionLogosByOfferIdAndUser(id, user);


            string OfferId = id;

            var opl = _context.OrderPositionLogos
                .Include(x => x.Order)
                .Include(t => t.Order.Textil)
                .Include(t => t.Order.TextilColor)
                .Where(x => x.Order.OfferId == OfferId)
                .Where(x => x.User == user)
                .ToList();


            List<PositionVM> PositionVMList = new List<PositionVM>();

            foreach (var item in opl)
            {
                var positionLogosOrderedByOrderPositionId = positionLogoList.Where(x => x.OrderPositionLogo == item).ToList();


                var positionVM = new PositionVM
                {
                    OrderId = item.Order.Id,
                    OrderPositionId = item.Id,
                    PositionList = positionList,
                    LogoList = logoList,
                    TextilName = item.Order.Textil.TextilName,
                    OfferId = id,
                    positionLogoList = positionLogosOrderedByOrderPositionId,
                };

                PositionVMList.Add(positionVM);
            }



            return PositionVMList;


        }

        public async Task<TextilColor> loadTextiColorlById(int id)
        {

            var TextilColorById = await _context.TextilColors.Where(x => x.Id == id).FirstOrDefaultAsync();

            return TextilColorById;
        }

        public async Task<List<WebPreisBerechnungAuB.Models.Logo>> loadAllLogoslByOfferId(string id, ApplicationUser user)
        {


            var LogosById = await _context.Logos
            .Include(x => x.Color)
            .Include(x => x.File)
            .Where(x => x.OfferId == id).ToListAsync();

            return LogosById;
        }


        public async Task<List<OrderPositionLogo>> loadAllOrderPositionLogoByUser(ApplicationUser user)
        {

            var oplList = await _context.OrderPositionLogos
                .Include(x => x.User)
                .Include(x => x.Order)
                .Include(x => x.Order.Textil)
                .Include(x => x.Order.TextilColor)
                .Where(x => x.User == user)
                .ToListAsync();

            return oplList;
        }

        public async Task<List<OrderPositionLogo>> loadAllOrderPositionLogoByUserAndOfferId(ApplicationUser user, string offerId)
        {

            var oplList = await _context.OrderPositionLogos
                .Include(x => x.User)
                .Include(x => x.Order)
                .Include(x => x.Order.Textil)
                .Include(x => x.Order.TextilColor)
                .Where(x => x.User == user)
                .Where(x => x.Order.OfferId == offerId)
                .ToListAsync();

            return oplList;
        }

        public async Task<OrderPositionLogo> loadOrderPositionLogoById(int id)
        {

            OrderPositionLogo orderpositionLogoByid = await _context.OrderPositionLogos
                .Include(x => x.User)
                .Include(x => x.Order)
                .Include(x => x.Order.Textil)
                .Include(x => x.Order.TextilColor)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return orderpositionLogoByid;
        }

        public async Task<List<OrderPositionLogo>> loadOrderPositionLogoByOfferid(string offerId)
        {

            List<OrderPositionLogo> opl = _context.OrderPositionLogos
               .Include(x => x.Order)
               .Include(x => x.Order.Textil)
               .Include(x => x.Order.TextilColor)
               .Include(x => x.User)
               .Where(x => x.Order.OfferId == offerId).ToList();

            return opl;
        }

        public async Task writeOplToDb(OrderPositionLogo model)
        {
            if (model.Order != null)
            {
                _context.OrderPositionLogos.Add(model);
                await _context.SaveChangesAsync();

            }

        }

        public async Task updateOplToDB(OrderPositionLogo model)
        {
            if (model.Order != null)
            {
                _context.OrderPositionLogos.Update(model);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<OrderPositionLogo> findOplById(int? id)
        {
            var oplById = await _context.OrderPositionLogos
                .Include(x => x.User)
                .Include(x => x.Order)
                .Include(x => x.Order.Textil)
                .Include(x => x.Order.TextilColor)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return oplById;

        }

        public async Task<PositionLogo> findPositionLogoById(int? id)
        {

            var positionLogoById = await _context.PositionLogos
                .Include(x => x.Position)
                .Include(x => x.Logo)
                .Include(x => x.Logo.Color)
                .Include(x => x.Logo.File)
                .Include(x => x.OrderPositionLogo)
                .Include(x => x.OrderPositionLogo.Order.Textil)
                .Include(x => x.OrderPositionLogo.Order.TextilColor)
                .Include(x => x.OrderPositionLogo.User)
                .Include(x => x.OrderPositionLogo.Order)
                .Where(x => x.Id == id).FirstOrDefaultAsync();

            return positionLogoById;
        }




        #region LogoRegion


        public async Task<WebPreisBerechnungAuB.Models.Logo> loadLogoById(int? id)
        {
            var LogosById = await _context.Logos
            .Include(x => x.Color)
            .Include(x => x.File)
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

            return LogosById;
        }

        public async Task<List<WebPreisBerechnungAuB.Models.Logo>> loadAllLogoslByOfferIdAndUser(string id, ApplicationUser user)
        {


            var LogosById = await _context.Logos
            .Include(x => x.Color)
            .Where(x => x.User == user)
            .Where(x => x.OfferId == id).ToListAsync();

            return LogosById;
        }


        public async Task<List<WebPreisBerechnungAuB.Models.Logo>> loadAllLogoslByUser(ApplicationUser user)
        {


            var LogosById = await _context.Logos
            .Include(x => x.Color)
            .Where(x => x.User == user)
            .ToListAsync();

            return LogosById;
        }

        public async Task<List<WebPreisBerechnungAuB.Models.Logo>> getAllLogosFromUser(ApplicationUser user)
        {

            var logoListFromUser = await _context.Logos
            .Include(x => x.Color)
            .Where(x => x.User == user)
            .ToListAsync();

            return logoListFromUser;
        }


        #endregion // Ende von LogoRegion


        #region PriceTableTransfer


        public async Task<RangeSurfaceSize> getRangeSurfaceSizeByID(int id)
        {
            var rangeSurfaceSize = await _context.RangeSurfaceSizes.FindAsync(id);

            return rangeSurfaceSize;
        }

        public async Task<List<PriceTableTransfer>> GetAllPriceTableTransfer()
        {
            var priceTableTransferList = await _context.PriceTableTransfer
                .Include(x => x.Texil)
                .Include(x => x.RangeLogo)
                .ToListAsync();


            return priceTableTransferList;
        }

        public async Task<List<Color>> LoadColorsByFilter(Func<Color, bool> filter = null)
        {
            if (filter != null)
            {
                return _context.Colors.Where(filter).ToList();
            }
            return await _context.Colors.ToListAsync();
        }

        #endregion // Ende von PriceTableTransfer


    }

}
