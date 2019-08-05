using Receivables.Dal.Context;
using Receivables.Dal.Interfaces;
using Receivables.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace Receivables.DAL.Repositories
{
    public class StoreRepository : BaseRepository<Store>, IStoreRepository
    {
        public StoreRepository(GodelBenefitContext context)
           : base(context)
        {
        }

        public IList<Store> GetAllByStoreTypeId(int storeTypeId)
        {
            var result = entities.Where(x => x.StoreTypeId == storeTypeId);
            return result.ToList();
        }

        public Store GetByName(string storeName)
        {
            return entities.FirstOrDefault(x => x.Name.Equals(storeName, System.StringComparison.InvariantCultureIgnoreCase));
        }
    }
}