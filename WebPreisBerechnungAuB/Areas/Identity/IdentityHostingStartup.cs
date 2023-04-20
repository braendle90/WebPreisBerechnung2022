using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(WebPreisBerechnungAuB.Areas.Identity.IdentityHostingStartup))]
namespace WebPreisBerechnungAuB.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}