using System.Collections.Generic;
using Receivables.DAL.Models;

namespace Receivables.DAL.Interfaces.Repositories
{
    public interface IStoreTypeRepository : IBaseRepository<StoreType>
    {
        IList<StoreType> GetAllStoreType();

        StoreType GetByName(string storeTypeName);
    }
}