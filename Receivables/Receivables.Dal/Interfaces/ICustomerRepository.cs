using System.Collections.Generic;
using Receivables.Dal.Models;

namespace Receivables.Dal.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Customer GetByINN(string INN);

        IEnumerable<Customer> GetActiveCustomer(string userId);
    }
}
