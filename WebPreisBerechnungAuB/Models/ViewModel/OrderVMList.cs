using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebPreisBerechnungAuB.Models.ViewModel
{
    public class OrderVMList
    {

        public int Id { get; set; }

        [Required]
        [DisplayName("Stückzahl")]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int NumberOfPieces { get; set; }

        [DisplayName("Angebots Nummer")]
        public string OfferId { get; set; }

        public int TextilColorId { get; set; }

        [DisplayName("Textilfarbe")]
        public string TextilColorName { get; set; }
        public List<TextilColor> TextilColorList { get; set; }

        [DisplayName("Textil Art")]
        public int TextilId { get; set; }

        [DisplayName("Textil")]
        public string TextilName { get; set; }
        public List<Textil> TextilList { get; set; }
        public Offer Offer { get; set; }

        public List<OrderPositionLogo> OrderPositionLogos { get; set; }
    }
}
