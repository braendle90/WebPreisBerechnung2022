using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebPreisBerechnungAuB.Data;
using WebPreisBerechnungAuB.Models;

namespace WebPreisBerechnungAuB.Repository
{
    public class StockFileRepository : IRepositoryNew<StockFileHistory, int>
    {
        private readonly ApplicationDbContext _context;

        public StockFileRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<StockFileHistory> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<StockFileHistory>> LoadAsync(Expression<Func<StockFileHistory, bool>> filter = null)
        {
            if (filter == null)
            {
                try
                {
                    var listNofilter = await _context.StockFileHistories.ToListAsync();
                    if (listNofilter == null)
                    {
                        return new List<StockFileHistory>();
                    }
                    return listNofilter;
                }
                catch (Exception ex)
                {
                    var test = ex.Message;
                    return new List<StockFileHistory>();
                }
            }
            var list = await _context.StockFileHistories.Where(filter).ToListAsync();
            if (list == null)
            {
                return new List<StockFileHistory>();
            }
            return list;
        }

        public async Task Save(StockFileHistory entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}
