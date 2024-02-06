using System;
using System.Threading.Tasks;

namespace WebPreisBerechnungAuB.Services.Interface
{
    public interface IFtpService
    {
        Task GetFileAsync();
        DateTime LastModifiedAsync();
    }
}
