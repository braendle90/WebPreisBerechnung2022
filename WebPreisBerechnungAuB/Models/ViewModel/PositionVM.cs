using System.Collections.Generic;

namespace WebPreisBerechnungAuB.Models.ViewModel
{
    public class PositionVM
    {

        public int Id { get; set; }
        public int OrderId { get; set; }
        public int OrderPositionId { get; set; }
        public string OfferId { get; set; }
        public string TextilName { get; set; }
        public int LogoId { get; set; }
        public int PositionId { get; set; }
        public Logo Logo { get; set; }
        public Position Position { get; set; }
        public int PositionLogoId { get; set; }

        public PositionLogo positionLogo { get; set; }
        public List<PositionLogo> positionLogoList { get; set; }
        public List<Position> PositionList { get; set; }
        public List<Logo> LogoList { get; set; }
    }
}
