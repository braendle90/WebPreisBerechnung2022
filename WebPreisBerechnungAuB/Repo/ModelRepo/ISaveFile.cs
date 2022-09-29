using System.Threading.Tasks;
using WebPreisBerechnungAuB.Models.ViewModel;

namespace WebPreisBerechnungAuB.Repo.Logo
{
    public interface ISaveFile
    {
        Task SaveFileToDB(LogoVM logo);
    }
}