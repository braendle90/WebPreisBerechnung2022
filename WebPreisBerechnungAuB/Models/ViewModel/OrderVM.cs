using System.Collections.Generic;
using System.ComponentModel;

namespace WebPreisBerechnungAuB.Models.ViewModel
{
    public class OrderVM
    {
        public int Id { get; set; }
        [DisplayName("Angebots Nummer")]
        public string OfferId { get; set; }
        [DisplayName("Stückzahl")]
        public int NumberOfPieces { get; set; }
        [DisplayName("Textil Farbe")]
        public int TextilColorId { get; set; }
        [DisplayName("Textilfarbe")]
        public string TextilColorName { get; set; }

        public List<TextilColor> TextilColorList { get; set; }
        [DisplayName("Textil Art")]
        public int TextilId { get; set; }
        [DisplayName("Textil Name")]
        public string TextilName { get; set; }
        public List<Textil> TextilList { get; set; }
    }
}
