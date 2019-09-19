using System.Collections.Generic;
using Receivables.Dal.Models;

namespace Receivables.Dal.Interfaces
{
    public interface IStoreRepository : IBaseRepository<Store>
    {
        Store GetByName(string storeName);

        IList<Store> GetAll();
    }
}