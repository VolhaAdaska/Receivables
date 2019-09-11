using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using NLog;
using Receivables.Bll.Dto;
using Receivables.Bll.Infrastructure;
using Receivables.Bll.Interfaces;
using Receivables.Dal.Interfaces;

namespace Receivables.Bll.Services
{
    public class DebtService : BaseService, IDebtService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public DebtService(IUnitOfWork unitOfWork, IMapper mapper)
           : base(unitOfWork, mapper)
        {
        }

        public Task<OperationDetails> AddDebtAsync(DebtDto debtDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<OperationDetails> DeleteDebtAsync(DebtDto debtDto)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<DebtDto> GetActiveDebt()
        {
            throw new System.NotImplementedException();
        }

        public Task<DebtDto> GetDebtByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<OperationDetails> UpdateDebtAsync(DebtDto debtDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
