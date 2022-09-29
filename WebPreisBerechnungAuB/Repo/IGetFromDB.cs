using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebPreisBerechnungAuB.Models;
using WebPreisBerechnungAuB.Models.ViewModel;

namespace WebPreisBerechnungAuB.Repo
{
    public interface IGetFromDB
    {
        Task<PriceTableVM> emptyPriceTableVM();
        Task<List<Position>> findAllPosition();
        Task<OrderPositionLogo> findOplById(int? id);
        Task<PositionLogo> findPositionLogoById(int? id);
        Task<List<Models.Logo>> getAllLogosFromUser(ApplicationUser user);
        Task<List<PriceTableTransfer>> GetAllPriceTableTransfer();
        Task<ExtraChargeList> GetExtraChargeListByLogoAsync(Models.Logo logo);
        Task<RangeSurfaceSize> getRangeSurfaceSizeByID(int id);
        Task<List<Color>> loadAllColor();
        Task<Color> loadAllColorById(int? id);
        Task<LogoVM> loadAllLogosFromUserAndCreateLogoVM(ApplicationUser user);
        Task<List<Models.Logo>> loadAllLogoslByOfferId(string id, ApplicationUser user);
        Task<List<Models.Logo>> loadAllLogoslByOfferIdAndUser(string id, ApplicationUser user);
        Task<List<Models.Logo>> loadAllLogoslByUser(ApplicationUser user);
        Task<LogoVM> loadallOplAndCreateVm(string id, ApplicationUser user);
        Task<LogoVM> loadallOplAndCreateVmFromUser(ApplicationUser user);
        Task<List<OrderPositionLogo>> loadAllOrderPositionLogoByUser(ApplicationUser user);
        Task<List<OrderPositionLogo>> loadAllOrderPositionLogoByUserAndOfferId(ApplicationUser user, string offerId);
        Task<List<PositionLogo>> loadAllPositionLogosByOfferId(string offerId);
        Task<List<PositionLogo>> loadAllPositionLogosByOfferIdAndUser(string offerId, ApplicationUser user);
        Task<List<PositionLogo>> loadAllPositionLogosByUser(ApplicationUser user);
        Task<List<PriceTable>> loadAllScreenprintPrice();
        Task<List<TextilColor>> loadAllTextilColor();
        Task<List<Textil>> loadAllTextils();
        Task<List<SelectListItem>> loadExtraCharges();
        Task<Models.Logo> loadLogoById(int? id);
        Task<OrderPositionLogo> loadOrderPositionLogoById(int id);
        Task<List<OrderPositionLogo>> loadOrderPositionLogoByOfferid(string offerId);
        Task<Position> loadPositionById(int id);
        Task<List<PositionVM>> loadPositionLogoAndCreateVM(string id, ApplicationUser user);
        Task<PriceTable> loadScreenprintPriceByID(int? id);
        Task<TextilColor> loadTextiColorlById(int id);
        Task<Textil> loadTextilById(int id);
        Task RemoveExtraChargeListByLogo(Models.Logo logo);
        Task RemoveLogoFromExtraChargeByLogo(Models.Logo logo);
        Task removeLogoFromPositionLogoByLogoIdAndUser(int logoId, ApplicationUser user);
        Task removeOrderPositionFromOrderAndUser(int orderId, ApplicationUser user);
        Task updateOplToDB(OrderPositionLogo model);
        Task writeOplToDb(OrderPositionLogo model);
    }
}