using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebPreisBerechnungAuB.Models;
using WebPreisBerechnungAuB.Models.ViewModel;

namespace WebPreisBerechnungAuB.Repo
{
    public interface Ihelper
    {
        Task<ShowPriceCalculation> calculatExtraChargeListScreenprintAndTransfer(PositionLogo data, OneLogoAndPosition fillModel, List<PositionLogo> positionLogo);
        Task<List<ExtraChargeList>> CreateExtraChargeList(LogoVM logovm);
        Task<List<SelectListItem>> findSelectedExtraChargeList(List<int> extraChargeList);
        Task<List<ExtraChargeList>> loadExtraChargeListFromLogo(Models.Logo logo);
        Task<ExtraChargeList> loadExtraChargeListFromTransfer(Models.Logo logo, PositionLogo data, OneLogoAndPosition fillModel);
        Task<decimal> priceofTransferApplication(PositionLogo data, OneLogoAndPosition fillModel);
        Task<List<ExtraChargeList>> updateExtraChargeList(LogoVM logovm);
    }
}