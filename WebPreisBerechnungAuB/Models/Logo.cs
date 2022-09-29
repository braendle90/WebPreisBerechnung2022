using System.Collections.Generic;
using System.ComponentModel;

namespace WebPreisBerechnungAuB.Models
{
    public class Logo
    {
        public int Id { get; set; }


        [DisplayName("Logo Name")] 
        public string LogoName { get; set; }
        [DisplayName("Breite in mm")]
        public double SurfaceWidht { get; set; }
        [DisplayName("Höhe in mm")]
        public double SurfaceHight { get; set; }
        [DisplayName("Quadratmillimeter")]
        public double LogoSurfaceSize { get; set; }

        [DisplayName("Angebots Nummer")]
        public string OfferId { get; set; }
        public ApplicationUser User { get; set; }

        public Color Color { get; set; }
        public bool isOld { get; set; }

        public decimal LogoPrice { get; set; }

        [DisplayName("Kosten pro Schablone")]
        public decimal PricePerScreen { get; set; }

        public decimal TotalPriceScreenPrint { get; set; }
        public decimal TotalPriceTransfer { get; set; }


        public decimal TransferLogoPrice { get; set; }

        [DisplayName("Logo Lagernd")]
        public bool isLogoStorage { get; set; }

        public File File { get; set; }





    }
}
