using Receivables.DAL.Models;
using System.Threading.Tasks;

namespace Receivables.DAL.Interfaces.Repositories
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