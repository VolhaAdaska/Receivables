using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NLog;
using Receivables.Bll.Dto;
using Receivables.Bll.Infrastructure;
using Receivables.Bll.Interfaces;
using Receivables.Bll.Models;
using Receivables.Dal.Interfaces;
using Receivables.Dal.Models;

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
            var debts = unitOfWork.DebtRepository.GetActiveDebt(StatusDebt.Closed);
            return debts.Select(p => mapper.Map<Debt, DebtDto>(p)).ToList();
        }

        public IList<DebtDto> GetAll()
        {
            var debts = unitOfWork.DebtRepository.GetAll();
            return debts.Select(p => mapper.Map<Debt, DebtDto>(p)).ToList();
        }

        public async Task<DebtDto> GetDebtByIdAsync(int id)
        {
            Debt debt = await unitOfWork.DebtRepository.GetByIdAsync(id);
            return mapper.Map<Debt, DebtDto>(debt);
        }

        public Task<OperationDetails> UpdateDebtAsync(DebtDto debtDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
