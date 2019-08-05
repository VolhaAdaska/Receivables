using System.Collections.Generic;
using Receivables.DAL.Models;

namespace Receivables.Dal.Interfaces
{
    public interface IStoreTypeRepository : IBaseRepository<StoreType>
    {
        IList<StoreType> GetAllStoreType();

        StoreType GetByName(string storeTypeName);
    }
}