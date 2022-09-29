namespace WebPreisBerechnungAuB.Models
{
    public class ExtraChargeList
    {

        public int Id { get; set; }

        public ExtraCharge ExtraCharge{ get; set; }

        public bool IsSelected { get; set; }

        public string GroupName { get; set; }

        public Logo Logo { get; set; }

        public string idForToggle { get; set; }
    }
}
