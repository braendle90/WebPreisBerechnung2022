using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebPreisBerechnungAuB.Models
{
    public class Order
    {
        public int Id { get; set; }
        [DisplayName("Angebots Nummer")]
        public string OfferId { get; set; }

        [DisplayName("Stückzahl")]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int NumberOfPieces { get; set; }
        public bool isOrdered { get; set; }
        public Textil Textil { get; set; }
        public TextilColor TextilColor { get; set; }

        [DisplayName("Preis Transfer")]
        public decimal PriceTransfer { get; set; }
        [DisplayName("Preis Siebdruck")]
        public decimal PriceScreenPrint { get; set; }
    }
}
