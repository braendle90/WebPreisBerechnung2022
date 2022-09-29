using System.Collections.Generic;
using System.ComponentModel;

namespace WebPreisBerechnungAuB.Models.ViewModel
{
    public class PriceTableTransferVM
    {

        public int Id { get; set; }
        [DisplayName("Textil")]

        public PriceTableTransfer PriceTableTransfer { get; set; }
        public List<Textil> TexilList { get; set; }
        public Textil Texil { get; set; }
        public int TexilId { get; set; }

        [DisplayName("von x Millimeter bis xxx Millimeter")]
        public int RangeId { get; set; }

        [DisplayName("von x Millimeter bis xxx Millimeter")]
        public List<RangeSurfaceSize> RangeLogoList { get; set; }
        public RangeSurfaceSize RangeLogo { get; set; }


        [DisplayName("Preis")]
        public decimal Price { get; set; }

    }
}
