using System.Linq;
using WebPreisBerechnungAuB.Models.ViewModel;

namespace WebPreisBerechnungAuB.Helpers
{
    public static class EmailHelper
    {
        public static SendOfferViewModel ReplaceStrings(SendOfferViewModel model)
        {

            model.MailContent.Content = model.MailContent.Content
                //.Replace("@Model.Time", model.TimeStamp.ToString("dd.MMM.yyyy HH:mm:ss"))
                .Replace("@Model.UserName", model.CalculationVMList.Select(x => x.OrderPositionLogo.User.LastName).FirstOrDefault())
                .Replace("@Model.UserEmail", model.CalculationVMList.Select(x => x.OrderPositionLogo.User.Email).FirstOrDefault());
            //.Replace("@Model.UserSalutation", model.UserSalutation)
            //.Replace("@Model.UserCompany", model.UserCompany)
            //.Replace("@Model.UserTelefon", model.UserTelefon)
            //.Replace("@Model.ClientId", model.ClientCustomerId)
            //.Replace("@Model.ClientPrefix", model.UserPrefix)
            //.Replace("@Model.Name", model.ClientName)
            //.Replace("@Model.Salutation", model.ClientSalutation)
            //.Replace("@Model.Company", model.UserCompany)
            //.Replace("@Model.CreditBeforeUse", model.CreditBeforeUse.ToString("C", CultureInfo.CurrentCulture))
            //.Replace("@Model.CreditUsed", model.CreditUsed.ToString("C", CultureInfo.CurrentCulture))
            //.Replace("@Model.CreditAfterUse", model.CreditAfterUse.ToString("C", CultureInfo.CurrentCulture))
            //.Replace("@Model.TransactionsId", model.TransactionsId)
            //.Replace("@Model.isDeposit", IsDepositValue(model.isDeposit))
            //.Replace("@Model.CreditTitle", ConfirmationText(model.isDeposit));

            return model;
        }
        private static string IsDepositValue(bool isDeposit)
        {
            string text = "";
            if (isDeposit == true)
            {
                text = "Ihr Guthaben wurde Ihnen gutgeschrieben";
            }
            else
            {
                text = "Ihr Guthaben wurde abgebucht";
            }
            return text;
        }
        private static string ConfirmationText(bool isDeposit)
        {
            string text = "";
            if (isDeposit == true)
            {
                text = "Buchungsbestätigung";
            }
            else
            {
                text = "Abbuchungsbestätigung";
            }
            return text;
        }
    }
}
