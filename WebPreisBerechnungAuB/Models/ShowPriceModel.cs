using System.Collections.Generic;
using System.ComponentModel;

namespace WebPreisBerechnungAuB.Models
{
    public class ShowPriceModel
    {

        public ShowPriceModel()
        {

        }
        public int Id { get; set; }

        public Position Position { get; set; }
        public Logo Logo { get; set; }

        public List<ExtraChargeList> extraChargeLists { get; set; } = new List<ExtraChargeList>();

        [DisplayName("Anbringungskosten")]
        public decimal Anbringung { get; set; }
        public OrderPositionLogo OrderPositionLogo { get; set; }

        public decimal PricePerPices { get; set; }
        public decimal PriceExtraCharge { get; set; }
        public decimal PricePerPicesTransfer { get; set; }

        public int PiecesofTextilWithThisLogo { get; set; }

        public decimal TotalPriceScreenPrint { get; set; }
        public decimal TotalPriceTransfer { get; set; }

    }
}
