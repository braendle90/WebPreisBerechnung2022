using Coravel;
using Coravel.Scheduling.Schedule;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using WebPreisBerechnungAuB.Data;
using WebPreisBerechnungAuB.Extensions;
using WebPreisBerechnungAuB.Helpers;
using WebPreisBerechnungAuB.Models;
using WebPreisBerechnungAuB.Repository;
using WebPreisBerechnungAuB.Services;
using WebPreisBerechnungAuB.Services.Interface;

namespace WebPreisBerechnungAuB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            var emailConfig = Configuration
                .GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailSender, EmailSender>();

            services.AddScheduler();

            //var ftpConnection = Configuration
            //    .GetSection("FtpConnection")
            //    .Get<FtpConnection>();
            //services.AddSingleton(ftpConnection);
            //services.Configure<FtpConnection>(Configuration.GetSection("FtpConnection"));

            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });

            services.AddControllers();

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddScoped<Services.IUserService, UserService>();
            services.AddScoped<ICalculationService, CalculationService>();
            services.AddScoped<ITemplateReader, TemplateReader>();
            services.AddScoped<ILoadAndModifyImage, LoadAndModifyImage>();
            services.AddScoped<IFtpService, FtpService>();
            services.RegisterServices();

            services.AddScoped<FtpService>();
            //services.AdAddTransientdScoped<IFtpService, FtpService>(); // oder .AddSingleton oder .AddTransient, je nach gewünschter Lebensdauer



            //Authorization
            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("Administrator", policy => policy.RequireRole("Admin"));

            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IFtpService ftpService)
        {

            // context.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            // in production the next 2 lines delete
            app.UseDeveloperExceptionPage();
            app.UseMigrationsEndPoint();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=OrderTextil}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });


            var provider = app.ApplicationServices;
            provider.UseScheduler(scheduler =>
            {
                scheduler.Schedule<FtpService>()
                .EveryThirtyMinutes()
                .RunOnceAtStart();



            });




            //var schedulerProvider = app.ApplicationServices;
            //schedulerProvider.UseScheduler(s =>
            //{
            //    s.Schedule(
            //        async () => await ftpService.GetFileAsync()
            //        //() => Console.WriteLine("Every minute during the week.")
            //        ).EveryThirtySeconds();
            //});
        }
    }
}
