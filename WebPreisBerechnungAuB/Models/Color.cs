using System.ComponentModel;

namespace WebPreisBerechnungAuB.Models
{
    public class Color
    {
        public int Id { get; set; }

        [DisplayName("Farbanzahl")]
        public string ColorName { get; set; }
        public int NumberOfColors { get; set; }
    }
}
