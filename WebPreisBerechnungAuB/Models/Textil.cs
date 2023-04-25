using System.ComponentModel;

namespace WebPreisBerechnungAuB.Models
{
    public class Textil
    {
        public int Id { get; set; }
        [DisplayName("Textil:")]
        public string TextilName { get; set; }
    }
}
