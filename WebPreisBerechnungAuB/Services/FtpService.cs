using Coravel.Invocable;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebPreisBerechnungAuB.Data;
using WebPreisBerechnungAuB.Models;
using WebPreisBerechnungAuB.Repository;
using WebPreisBerechnungAuB.Services.Interface;

namespace WebPreisBerechnungAuB.Services
{
    public class FtpService : IFtpService, IInvocable
    {
        private readonly IRepositoryNew<StockFileHistory, int> _stockFileHistoryRepo;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<FtpService> _logger;

        public FtpService(IRepositoryNew<StockFileHistory, int> stockFileHistoryRepo, IServiceScopeFactory scopeFactory, ApplicationDbContext context, ILogger<FtpService> logger)
        {
            _stockFileHistoryRepo = stockFileHistoryRepo;
            _scopeFactory = scopeFactory;
            _context = context;
            _logger = logger;
        }
        public async Task GetFileAsync()
        {
            var canDownloadFile = await CompareToStockFileHistory();
            if (canDownloadFile)
            {
                var user = "AT_10140024_LB";
                var password = "Ke47hd9hCZFCRE";
                var uri = "ftp://edi.l-shop-team.net";
                var fileName = "stockfile.csv";
                try
                {
                    var lastModified = LastModifiedAsync();
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"{uri}/{fileName}");
                    request.Method = WebRequestMethods.Ftp.DownloadFile;
                    request.Credentials = new NetworkCredential(user, password);

                    using FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    using Stream responseStream = response.GetResponseStream();
                    using MemoryStream memoryStream = new MemoryStream();
                    responseStream.CopyTo(memoryStream);
                    var bytes = memoryStream.ToArray();
                    var fileString = Encoding.UTF8.GetString(bytes);
                    await SaveToFile(fileString, lastModified);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error while loading data from ftp server");
                }
            }
        }

        public Task Invoke()
        {
            GetFileAsync();

            return Task.CompletedTask;

        }

        public DateTime LastModifiedAsync()
        {
            var user = "AT_10140024_LB";
            var password = "Ke47hd9hCZFCRE";
            var uri = "ftp://edi.l-shop-team.net";
            var fileName = "stockfile.csv";
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"{uri}/{fileName}");
                request.Method = WebRequestMethods.Ftp.GetDateTimestamp;
                request.Credentials = new NetworkCredential(user, password);

                using FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                return response.LastModified;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while loading data from ftp server");
            }
            return DateTime.Now;
        }

        private async Task<bool> CompareToStockFileHistory()
        {
            var lastModified = LastModifiedAsync();
            List<StockFileHistory> lastModifiedList;

            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                lastModifiedList = await dbContext.StockFileHistories.ToListAsync();


            }


            //var lastModifiedList = await _context.StockFileHistories.ToListAsync();
            //var lastModifiedList = _stockFileHistoryRepo.LoadAsync();
            if (lastModifiedList.Count == 0)
            {
                return true;
            }
            var maxModified = lastModifiedList.Max(x => x.LastModified);
            if (maxModified < lastModified)
            {
                return true;
            }
            return false;
        }
        private async Task SaveToFile(string fileString, DateTime lastModified)
        {
            string docPath = Path.Combine(Environment.CurrentDirectory, "wwwroot", "inventory");
            string filePath = Path.Combine(docPath, "stockfile.csv"); // Specific file path

            // Ensure the directory exists
            if (!Directory.Exists(docPath))
            {
                Directory.CreateDirectory(docPath);
            }

            // Check if the file exists before trying to delete
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
                _logger.LogDebug("File was deleted.");
            }

            try
            {
                // Write the fileString to a new file asynchronously
                await System.IO.File.WriteAllTextAsync(filePath, fileString);
                _logger.LogDebug("File was written successfully.");

                // Asynchronously add a new StockFileHistory and save changes to the database



                using (var scope = _scopeFactory.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();


                    dbContext.Add(new StockFileHistory
                    {
                        LastModified = lastModified
                    });
                    dbContext.SaveChanges();
                }

                //_context.Add(new StockFileHistory
                //{
                //    LastModified = lastModified
                //});
                //_context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while writing to file or updating database");
            }
        }

    }
}
