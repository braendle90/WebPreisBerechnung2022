using System.ComponentModel;

namespace WebPreisBerechnungAuB.Models
{
    public class Offer
    {

        public int Id { get; set; }
        [DisplayName("Angebots Nummer")]
        public string OfferId { get; set; }
        [DisplayName("Angebot Name")]
        public string OfferName { get; set; }
        [DisplayName("Angebot bestellt")]
        public bool IsOrdered { get; set; }

       

    }
}
