using System.Collections.Generic;

namespace WebPreisBerechnungAuB.Models.ViewModel
{
    public class OfferVM
    {

        public int Id { get; set; }
        public string OfferId { get; set; }
        public Offer Offer { get; set; }

        public List<OrderPositionLogo> OrderPostionLogoListe { get; set; }
        public List<PositionLogo> PositionLogoListe { get; set; }
    }
}
