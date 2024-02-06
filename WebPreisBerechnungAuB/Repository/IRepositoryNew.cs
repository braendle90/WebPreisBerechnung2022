using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebPreisBerechnungAuB.Models;

namespace WebPreisBerechnungAuB.Repository
{
    public interface IRepositoryNew<T1, T2> where T1 : class
    {
        Task<List<StockFileHistory>> LoadAsync(Expression<Func<T1, bool>>? filter = null);
        Task Delete(T2 id);
        Task<T1> GetById(T2 id);
        Task Save(T1 entity);
    }
}
