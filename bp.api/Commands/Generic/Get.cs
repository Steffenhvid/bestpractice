using Microsoft.EntityFrameworkCore;
using bp.domain.Interfaces;
using bp.domain.Models;
using bp.efc;

namespace bp.api.Commands.Generic
{
    public class Get<T>(bpContext context) : IGet<T> where T : BaseEntity
    {
        private readonly DbSet<T> dbSet = context.Set<T>();

        public async Task<T?> ByIdAsync(int id)
        {
            return await dbSet.FirstOrDefaultAsync(e => e.Id == id);
        }

        public Task<List<T>> AllAsync()
        {
            return dbSet.ToListAsync();
        }
    }
}