using System.ComponentModel;

namespace WebPreisBerechnungAuB.Models
{
    public class Textil
    {
        public int Id { get; set; }
        [DisplayName("Textil Name")]
        public string TextilName { get; set; }
    }
}
