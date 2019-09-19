using Receivables.Dal.Context;
using Receivables.Dal.Interfaces;
using Receivables.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Receivables.Dal.Repositories
{
    public class StoreRepository : BaseRepository<Store>, IStoreRepository
    {
        public StoreRepository(ReceivablesContext context)
           : base(context)
        {
        }

        public IList<Store> GetAll()
        {
            return entities.ToList();
        }

        public Store GetByName(string storeName)
        {
            return entities.FirstOrDefault(x => x.Name.Equals(storeName, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}