using Receivables.Dal.Models;

namespace Receivables.Dal.Interfaces
{
    public interface IStoreRepository : IBaseRepository<Store>
    {
        Store GetByName(string storeName);
    }
}