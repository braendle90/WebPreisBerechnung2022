using System.ComponentModel;

namespace WebPreisBerechnungAuB.Models
{
    public class PriceTable
    {

        public int Id { get; set; }
        public Textil Texil { get; set; }

        public Color NumberColors { get; set; }
        public RangeTable Range { get; set; }

        [DisplayName("Preis")]

        public decimal Price { get; set; }
        public decimal PriceUpdatePercent { get; set; }
    }
}
