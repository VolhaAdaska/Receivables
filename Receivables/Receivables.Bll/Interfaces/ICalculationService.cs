using System.Collections.Generic;
using Receivables.Bll.Dto;

namespace Receivables.Bll.Interfaces
{
    public interface ICalculationService
    {
        IList<AccountDto> GetAccountsByCustomerId(int customerId);
    }
}