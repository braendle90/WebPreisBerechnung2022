using Microsoft.AspNetCore.Hosting;
using System.IO;
using WebPreisBerechnungAuB.Models.ViewModel;

namespace WebPreisBerechnungAuB.Helpers
{
    public class TemplateReader : ITemplateReader
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TemplateReader(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public SendOfferViewModel ReadSendContingenteEmailFile(SendOfferViewModel model)
        {

            var separator = Path.DirectorySeparatorChar.ToString();
            var PathToFile = _webHostEnvironment.WebRootPath + separator + "EmailTemplate" + separator + "SendOfferViewModelEMailTemplate.html";
            using (StreamReader reader = File.OpenText(PathToFile))
            {
                model.MailContent.Content = reader.ReadToEnd();
                model = EmailHelper.ReplaceStrings(model);
            }
            return model;
        }
    }
}
