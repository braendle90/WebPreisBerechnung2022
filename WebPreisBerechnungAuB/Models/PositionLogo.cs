using System.Collections.Generic;

namespace WebPreisBerechnungAuB.Models
{
    public class PositionLogo
    {
        public int Id { get; set; }

        public Position Position { get; set; }
        public Logo Logo { get; set; }
        public OrderPositionLogo OrderPositionLogo { get; set; }

        public List<ExtraChargeList> ExtraChargeLists { get; set; }

    }
}
