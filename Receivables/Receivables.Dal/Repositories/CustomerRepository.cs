using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Receivables.Dal.Context;
using Receivables.Dal.Interfaces;
using Receivables.Dal.Models;

namespace Receivables.Dal.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ReceivablesContext context)
          : base(context)
        {
        }

        public IEnumerable<Customer> GetActiveCustomer(string userId)
        {
            return entities.Where(x => x.UserId == userId && x.IsActive == true);
        }

        public IList<Customer> GetAll()
        {
            return entities.ToList();
        }

        public Customer GetByINN(string INN)
        {
            return entities.FirstOrDefault(x => x.INN.Equals(INN, System.StringComparison.InvariantCultureIgnoreCase));
        }

        public Customer GetCustomerByName(string name)
        {
            return entities.FirstOrDefault(x => x.Name.Equals(name, System.StringComparison.InvariantCultureIgnoreCase));
        }
    }
}