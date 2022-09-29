using System.ComponentModel;

namespace WebPreisBerechnungAuB.Models
{
    public class RangeTable
    {

        public int Id { get; set; }

        [DisplayName("Stückzahl von bis")]
        public string RangeName { get; set; }

        public int RangeFrom { get; set; }
        public int RangeTo { get; set; }

    }
}
