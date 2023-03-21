using System.Collections.Generic;
using System.ComponentModel;

namespace WebPreisBerechnungAuB.Models.ViewModel
{
    public class PriceTableVM
    {



        public int Id { get; set; }

        public PriceTable PriceTable{ get; set; }
        public List<PriceTable> PriceTableList { get; set; }

        public int TexilId { get; set; }
        public List<Textil> TexilList { get; set; }

        public decimal PriceUpdatePercent { get; set; }
        public int NumberColorsId { get; set; }

        public List<Color> NumberColorList { get; set; }


        public decimal Price { get; set; }

        public int RangeId { get; set; }

        public List<RangeTable> RangeTableList { get; set; }


        public int RangeFrom { get; set; }
        public int RangeTo { get; set; }


    }
}
