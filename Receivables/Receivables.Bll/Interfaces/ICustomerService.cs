using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Receivables.Bll.Dto;
using Receivables.Bll.Infrastructure;

namespace Receivables.Bll.Interfaces
{
    public interface ICustomerService : IDisposable
    {
        Task<OperationDetails> AddCustomerAsync(CustomerDto customerDto);

        Task<OperationDetails> DeleteCustomerAsync(CustomerDto customerDto);

        Task<OperationDetails> UpdateCustomerAsync(CustomerDto customerDto);

        Task<CustomerDto> GetCustomerByIdAsync(int id);

        IEnumerable<CustomerDto> GetActiveCustomer(string userId);

        CustomerDto GetCustomerByName(string name);

        IList<CustomerDto> GetAllCustomer();
    }
}
