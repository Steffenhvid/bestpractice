using bp.domain.Interfaces;
using bp.domain.Models;
using bp.efc;
using Microsoft.EntityFrameworkCore;

namespace bp.api.Commands.Generic
{
    /// <summary>
    /// get an entity from the database
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="context"></param>
    public class Get<T>(bpContext context) : IGet<T> where T : BaseEntity
    {
        private readonly DbSet<T> dbSet = context.Set<T>();

        /// <summary>
        /// get an entity by id from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T?> ByIdAsync(int id)
        {
            return await dbSet.FirstOrDefaultAsync(e => e.Id == id);
        }

        /// <summary>
        /// get all entities from the database
        /// </summary>
        /// <returns></returns>
        public Task<List<T>> AllAsync()
        {
            return dbSet.ToListAsync();
        }
    }
}