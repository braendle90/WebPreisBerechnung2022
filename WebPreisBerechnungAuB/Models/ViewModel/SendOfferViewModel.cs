using System.Collections.Generic;

namespace WebPreisBerechnungAuB.Models.ViewModel
{
    public class SendOfferViewModel
    {
        public int Id { get; set; }

        public List<CalculationVM> CalculationVMList { get; set; }

        public MailContent MailContent { get; set; }

    }
}
