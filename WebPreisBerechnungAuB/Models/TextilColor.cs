using System.ComponentModel;

namespace WebPreisBerechnungAuB.Models
{
    public class TextilColor
    {

        public int Id { get; set; }
        [DisplayName("Textil Farbe")]
        public string TextilColorName { get; set; }

        public bool IsPriceHigher { get; set; }
    }
}
