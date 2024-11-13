using bp.domain.Models;

namespace bp.domain.Interfaces
{
    public interface IGet<T> where T : BaseEntity
    {
        Task<T?> ByIdAsync(int id);

        Task<List<T>> AllAsync();
    }
}