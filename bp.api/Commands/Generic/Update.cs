using Microsoft.EntityFrameworkCore;
using bp.domain.Interfaces;
using bp.domain.Models;
using bp.efc;

namespace bp.api.Commands.Generic
{
    public class Update<T>(bpContext context) : IUpdate<T> where T : BaseEntity
    {
        private readonly bpContext context = context;

        public async Task<T> EntityAsync(T entity)
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}