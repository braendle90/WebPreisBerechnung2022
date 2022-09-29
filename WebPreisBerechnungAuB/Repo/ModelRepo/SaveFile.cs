using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebPreisBerechnungAuB.Models;
using WebPreisBerechnungAuB.Models.ViewModel;

namespace WebPreisBerechnungAuB.Repo.Logo
{
    public class SaveFile : ISaveFile
    {


        public SaveFile()
        {
   
          
        }

        public async Task SaveFileToDB(LogoVM logo)
        {

            var file = new File();

            file = logo.Logo.File;
            file.Name = logo.Logo.LogoName;

           

        }
    }
}
