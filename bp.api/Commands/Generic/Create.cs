using bp.domain.Interfaces;
using bp.domain.Models;
using bp.efc;

namespace bp.api.Commands.Generic
{
    public class Create<T>(bpContext context) : ICreate<T> where T : BaseEntity
    {
        private readonly bpContext context = context;

        public async Task NewAsync(T entity)
        {
            context.Add(entity);
            await context.SaveChangesAsync();
        }
    }
}