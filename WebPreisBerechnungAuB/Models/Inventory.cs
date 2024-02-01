using System.ComponentModel.DataAnnotations;

namespace WebPreisBerechnungAuB.Models
{
    public class Inventory
    {

        [Key]
        public string article { get; set; }
        public int stock { get; set; }
    }
}
