namespace WebPreisBerechnungAuB.Models
{
    public class ExtraCharge
    {

        public int Id { get; set; }
        public string ChargeName { get; set; }

        public decimal ChargePrice { get; set; }


        public string ChargeTyp { get; set; }

        public bool isOneTimeCharge { get; set; }

        public bool IsSelected { get; set; }



    }
}
