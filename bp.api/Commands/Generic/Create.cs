using bp.domain.Interfaces;
using bp.domain.Models;
using bp.efc;

namespace bp.api.Commands.Generic
{
    /// <summary>
    /// Create a new entity in the database
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="context"></param>
    public class Create<T>(bpContext context) : ICreate<T> where T : BaseEntity
    {
        private readonly bpContext context = context;

        /// <summary>
        /// Create a new entity in the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task NewAsync(T entity)
        {
            context.Add(entity);
            await context.SaveChangesAsync();
        }
    }
}