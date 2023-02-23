using System.ComponentModel;

namespace WebPreisBerechnungAuB.Models
{
    public class EMail
    {

        public int Id { get; set; }
        [DisplayName("E-Mail Nummer")]
        public string emailAdressTo { get; set; }
        [DisplayName("Empfänger Adresse")]
        public string subject { get; set; }
        [DisplayName("Betreff")]
        public string htmlMessage { get; set; }


    }
}
