using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebPreisBerechnungAuB.Services.Interface
{
    public interface IRepository<T1, T2> where T1 : class
    {
        /// <summary>
        /// Is returning a IEnumerable of the class provided
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T1>> GetAllAsync();
        /// <summary>
        /// Is returning a object by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T1> GetByIdAsync(T2 id);
        /// <summary>
        /// Create a new object 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task CreateAsync(T1 model);
        /// <summary>
        /// Update the provided object
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task Update(T1 model);
        /// <summary>
        /// Delete the object by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(T2 id);
    }
}
