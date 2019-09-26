using System.Threading.Tasks;
using Receivables.Bll.Dto;
using Receivables.Bll.Infrastructure;

namespace Receivables.Bll.Interfaces
{
    public interface IDebtPaidService
    {
        Task<OperationDetails> AddDebtPaidAsync(DebtPaidDto DebtPaidDto);

        Task<OperationDetails> DeleteDebtPaidAsync(DebtPaidDto DebtPaidDto);

        Task<OperationDetails> UpdateDebtPaidAsync(DebtPaidDto DebtPaidDto);

        Task<DebtPaidDto> GetDebtPaidByIdAsync(int id);
    }
}
