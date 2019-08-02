using Receivables.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Receivables.DAL.Interfaces.Repositories
{
    public interface IStoreRepository : IBaseRepository<Store>
    {
        IList<Store> GetAllByStoreTypeId(int storeTypeId);

        Store GetByName(string storeName);
    }
}