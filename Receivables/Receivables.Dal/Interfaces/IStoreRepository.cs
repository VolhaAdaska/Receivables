using Receivables.Dal.Models;
using System.Collections.Generic;

namespace Receivables.Dal.Interfaces
{
    public interface IStoreRepository : IBaseRepository<Store>
    {
        IList<Store> GetAllByStoreTypeId(int storeTypeId);

        Store GetByName(string storeName);
    }
}