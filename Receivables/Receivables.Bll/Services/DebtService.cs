using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NLog;
using Receivables.Bll.Dto;
using Receivables.Bll.Enum;
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

        public async Task<OperationDetails> CloseDebt(int id)
        {
            DebtDto debtDto = await GetDebtByIdAsync(id);
            if (debtDto == null)
            {
                Logger.Error("Debt is null");
                return new OperationDetails(false, "Something went wrong", "Debt");
            }

            debtDto.Status = StatusDebt.Closed;

            Debt debt = mapper.Map<DebtDto, Debt>(debtDto);

            try
            {
                await unitOfWork.DebtRepository.UpdateAsync(debt);
                await unitOfWork.SaveAsync();
                Logger.Info("Successfully updated");
                return new OperationDetails(true);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return new OperationDetails(false, ex.Message);
            }
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
            var debtDto = mapper.Map<Debt, DebtDto>(debt);
            debtDto.Currency = ((Currency)debt.Currency).ToString();
            return debtDto;
        }

        public async Task<OperationDetails> UpdateDebtAsync(DebtDto debtDto)
        {
            if (debtDto == null)
            {
                Logger.Error("Debt is null");
                return new OperationDetails(false, "Something went wrong", "Debt");
            }

            Debt debt = mapper.Map<DebtDto, Debt>(debtDto);

            try
            {
                await unitOfWork.DebtRepository.UpdateAsync(debt);
                await unitOfWork.SaveAsync();
                Logger.Info("Successfully updated");
                return new OperationDetails(true);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return new OperationDetails(false, ex.Message);
            }
        }
    }
}
