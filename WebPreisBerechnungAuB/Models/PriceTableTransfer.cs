namespace WebPreisBerechnungAuB.Models
{
    public class PriceTableTransfer
    {

        public int Id { get; set; }
        public Textil Texil { get; set; }

        public RangeSurfaceSize RangeLogo { get; set; }


        public double Price { get; set; }


    }
}
