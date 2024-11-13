using bp.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bp.domain.Interfaces
{
    public interface ICreate<T> where T : BaseEntity
    {
        Task NewAsync(T entity);
    }
}