using Receivables.Dal.Context;
using Receivables.Dal.Interfaces;
using Receivables.Dal.Models;
using System.Collections.Generic;
using System.Linq;

namespace Receivables.Dal.Repositories
{
    public class StoreTypeReposiroty : BaseRepository<StoreType>, IStoreTypeRepository
    {
        public StoreTypeReposiroty(ReceivablesContext context)
            : base(context)
        {
        }

        public IList<StoreType> GetAllStoreType()
        {
            return entities.ToList();
        }

        public StoreType GetByName(string storeTypeName)
        {
            return entities.FirstOrDefault(x => x.Name.Equals(storeTypeName, System.StringComparison.InvariantCultureIgnoreCase));
        }
    }
}