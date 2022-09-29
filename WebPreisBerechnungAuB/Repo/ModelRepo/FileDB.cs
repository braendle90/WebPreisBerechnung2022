using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebPreisBerechnungAuB.Data;
using WebPreisBerechnungAuB.Models;

namespace WebPreisBerechnungAuB.Repo.Logo
{
    public class FileDB : IFileDB
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public FileDB(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            this._userManager = userManager;
        }

        public async Task addFile(File file)
        {

            await _context.Files.AddAsync(file);
        }

        public async Task<List<File>> loadAllFiles()
        {

            var allFiles = await _context.Files.ToListAsync();

            return allFiles;
        }

        public async Task<File> FileById(int id)
        {

            var FileByID = await _context.Files.FindAsync(id);

            return FileByID;
        }
        public async Task updateFile(File file)
        {
            _context.Files.Update(file);
            await _context.SaveChangesAsync();
        }

        public async Task deleteFile(File file)
        {
            _context.Files.Remove(file);
            await _context.SaveChangesAsync();
        }
    }
}
