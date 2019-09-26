using System.Collections.Generic;
using System.Threading.Tasks;
using Receivables.Bll.Dto;
using Receivables.Bll.Infrastructure;

namespace Receivables.Bll.Interfaces
{
    public interface IDebtService
    {
        Task<OperationDetails> AddDebtAsync(DebtDto debtDto);

        Task<OperationDetails> DeleteDebtAsync(DebtDto debtDto);

        Task<OperationDetails> UpdateDebtAsync(DebtDto debtDto);

        Task<OperationDetails> CloseDebt(int id);

        Task<DebtDto> GetDebtByIdAsync(int id);

        IEnumerable<DebtDto> GetActiveDebt();

        IList<DebtDto> GetAll();
    }
}