using Receivables.Dal.Models;
using System.Threading.Tasks;

namespace Receivables.Dal.Interfaces
{
    public interface IBaseRepository<T>
        where T : BaseEntity
    {
        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<T> GetByIdAsync(int id);
    }
}