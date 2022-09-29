using System.Collections.Generic;
using System.Threading.Tasks;
using WebPreisBerechnungAuB.Models;

namespace WebPreisBerechnungAuB.Repo.Logo
{
    public interface IFileDB
    {
        Task addFile(File file);
        Task deleteFile(File file);
        Task<File> FileById(int id);
        Task<List<File>> loadAllFiles();
        Task updateFile(File file);
    }
}