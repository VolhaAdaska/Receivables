using System.Threading.Tasks;
using Receivables.Bll.Dto;
using Receivables.Bll.Infrastructure;

namespace Receivables.Bll.Interfaces
{
    public interface IDebtStatusService
    {
        Task<OperationDetails> AddDebtStatusAsync(DebtStatusDto DebtStatusDto);

        Task<OperationDetails> DeleteDebtStatusAsync(DebtStatusDto DebtStatusDto);

        Task<OperationDetails> UpdateDebtStatusAsync(DebtStatusDto DebtStatusDto);

        Task<DebtStatusDto> GetDebtStatusByIdAsync(int id);
    }
}
