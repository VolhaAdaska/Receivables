using Receivables.Dal.Models;
using System.Collections.Generic;

namespace Receivables.Dal.Interfaces
{
    public interface IStoreRepository : IBaseRepository<Store>
    {
        Store GetByName(string storeName);
    }
}