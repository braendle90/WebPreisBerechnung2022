using WebPreisBerechnungAuB.Models.ViewModel;

namespace WebPreisBerechnungAuB.Helpers
{
    public interface ITemplateReader
    {
        SendOfferViewModel ReadSendContingenteEmailFile(SendOfferViewModel model);
    }
}

