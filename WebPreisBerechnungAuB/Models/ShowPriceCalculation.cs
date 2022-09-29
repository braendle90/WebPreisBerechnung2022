using System.Collections.Generic;

namespace WebPreisBerechnungAuB.Models
{
    public class ShowPriceCalculation
    {

        public int Id { get; set; }

        public decimal PricePerPices { get; set; }
        public decimal TotalPriceTransfer { get; set; }
        public decimal TotalPriceScreenPrint { get; set; }
        public decimal PriceExtraCharge { get; set; }
        public List<ExtraChargeList> ExtraChargeList { get; set; }
    }
}
