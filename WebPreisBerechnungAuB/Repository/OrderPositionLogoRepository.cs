using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPreisBerechnungAuB.Data;
using WebPreisBerechnungAuB.Models;
using WebPreisBerechnungAuB.Services.Interface;

namespace WebPreisBerechnungAuB.Repository
{
    public class OrderPositionLogoRepository : IRepository<OrderPositionLogo, int>
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;

        public OrderPositionLogoRepository(ApplicationDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }
        public async Task CreateAsync(OrderPositionLogo model)
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var model = await _context.OrderPositionLogos.FindAsync(id);
            _context.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderPositionLogo>> GetAllAsync()
        {
            var user = await _userService.CurrentUser();
            return await _context.OrderPositionLogos
                .Include(x => x.Order)
                .Include(x => x.Order.Textil)
                .Include(x => x.Order.TextilColor)
                .Include(x => x.User)
                .Where(x => x.User == user)
                .ToListAsync();
        }

        public async Task<OrderPositionLogo> GetByIdAsync(int id)
        {
            return await _context.OrderPositionLogos.FindAsync(id);
        }

        public async Task Update(OrderPositionLogo model)
        {
            _context.OrderPositionLogos.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
