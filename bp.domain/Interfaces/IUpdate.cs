using bp.domain.Models;

namespace bp.domain.Interfaces
{
    public interface IUpdate<T> where T : BaseEntity
    {
        Task<T> EntityAsync(T entity);
    }
}