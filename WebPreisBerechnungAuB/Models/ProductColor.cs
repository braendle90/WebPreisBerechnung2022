using System.ComponentModel.DataAnnotations;

namespace WebPreisBerechnungAuB.Models
{
    public class ProductColor
    {
        [Key]
        public int Id { get; set; }
        public string Color1 { get; set; }
        public string Color2 { get; set; }
        public string Color3 { get; set; }
        public string Color4 { get; set; }

        public string HexCol1 { get; set; }
        public string HexCol2 { get; set; }
        public string HexCol3 { get; set; }
        public string HexCol4 { get; set; }


    }
}


