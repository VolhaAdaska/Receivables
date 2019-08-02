using System.Collections.Generic;
using System.Linq;
using Receivables.DAL.Core.Context;
using Receivables.DAL.Interfaces.Repositories;
using Receivables.DAL.Models;
using System.Threading.Tasks;

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