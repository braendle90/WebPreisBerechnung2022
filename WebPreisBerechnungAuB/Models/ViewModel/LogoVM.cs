using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;

namespace WebPreisBerechnungAuB.Models.ViewModel
{
    public class LogoVM
    {

        public int Id { get; set; }

        [DisplayName("Angebots Nummer")]
        public string OfferId { get; set; }

        public List<Logo> LogoList { get; set; }
        public Logo Logo { get; set; }

        public int ColorId { get; set; }
        public List<Color> ColorList { get; set; }

        public List<SelectListItem> SelectColorList { get; set; }
        public bool IsCalculated { get; set; }

        public List<PositionLogo> PositionLogo { get; set; }

        public List<SelectListItem> ExtraChargeList { get; set; }
        public List<ExtraCharge> ExtraChargeListCheckbox { get; set; }
        public int[] ExtraChargeId { get; set; }

        public List<ExtraChargeList> ExtraChargeListsModel { get; set; }

        public bool ShowUserLogos { get; set; }
        public string Image { get; set; }
        public string ImagePath { get; set; }


    }
}
