using Coravel;
using Microsoft.Extensions.DependencyInjection;
using WebPreisBerechnungAuB.Models;
using WebPreisBerechnungAuB.Repository;
using WebPreisBerechnungAuB.Services;

namespace WebPreisBerechnungAuB.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<Services.IUserService, UserService>();
            services.AddScoped<IRepositoryNew<StockFileHistory, int>, StockFileRepository>();
            services.AddScheduler();
            return services;
        }
    }
}
