namespace WebPreisBerechnungAuB.Models
{
    public class OrderPositionLogo
    {
        public int Id { get; set; }
        public Order Order { get; set; }

        public ApplicationUser User { get; set; }

    }
}
