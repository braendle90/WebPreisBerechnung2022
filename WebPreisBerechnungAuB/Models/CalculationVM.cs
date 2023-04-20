using System.Collections.Generic;

namespace WebPreisBerechnungAuB.Models
{
    public class CalculationVM
    {
        public int Id { get; set; }

        public OrderPositionLogo OrderPositionLogo { get; set; }
        public List<ShowPriceModel> ShowPriceModel { get; set; } = new List<ShowPriceModel>();
    }
}
