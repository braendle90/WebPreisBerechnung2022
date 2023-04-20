using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebPreisBerechnungAuB.Data;
using WebPreisBerechnungAuB.Models;
using WebPreisBerechnungAuB.Services.Interface;

namespace WebPreisBerechnungAuB.Repository
{
    public class PositionLogoRepository : IRepository<PositionLogo, int>
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;

        public PositionLogoRepository(ApplicationDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }
        public async Task CreateAsync(PositionLogo model)
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var model = await _context.PositionLogos.FindAsync(id);
            _context.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PositionLogo>> GetAllAsync()
        {
            var user = await _userService.CurrentUser();
            return await _context.PositionLogos
                .Include(x => x.Logo)
                .Include(x => x.Position)
                .Include(x => x.OrderPositionLogo)
                .ToListAsync();
        }

        public async Task<PositionLogo> GetByIdAsync(int id)
        {
            return await _context.PositionLogos.FindAsync(id);
        }

        public async Task Update(PositionLogo model)
        {
            _context.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
