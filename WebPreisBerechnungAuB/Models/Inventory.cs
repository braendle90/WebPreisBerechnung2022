using System.ComponentModel.DataAnnotations;

namespace WebPreisBerechnungAuB.Models
{
    public class Inventory
    {

        [Key]
        public int Article { get; set; }
        public int Stock { get; set; }
        [MaxLength(50)]
        public string Catalog { get; set; } = string.Empty;

    }
}
