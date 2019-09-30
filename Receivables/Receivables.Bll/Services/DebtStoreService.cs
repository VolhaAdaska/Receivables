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
using Receivables.Dal.Interfaces;
using Receivables.Dal.Models;

namespace Receivables.Bll.Services
{
    public class DebtStoreService : BaseService, IDebtStoreService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public DebtStoreService(IUnitOfWork unitOfWork, IMapper mapper)
           : base(unitOfWork, mapper)
        {
        }

        public async Task<OperationDetails> AddDebtStoreAsync(DebtStoreDto DebtStoreDto)
        {
            if (DebtStoreDto == null)
            {
                Logger.Error("Something went wrong");
                return new OperationDetails(false, "К сожалению, что-то пошло не так....", "DebtStore");
            }

            DebtStore DebtStore = mapper.Map<DebtStoreDto, DebtStore>(DebtStoreDto);
            try
            {
                //if (unitOfWork.DebtStoreRepository.GetByCode(DebtStore.Code) != null)
                //{
                //    Logger.Error("Номенклатура с таким артикулом уже существует");
                //    return new OperationDetails(false, "Номенклатура с таким артикулом уже существует", "DebtStore");
                //}
                await unitOfWork.DebtStoreRepository.CreateAsync(DebtStore);
                await unitOfWork.SaveAsync();
                Logger.Info("Successfully added");
                return new OperationDetails(true);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return new OperationDetails(false, "К сожалению, что-то пошло не так....", "DebtStore");
            }
        }

        public async Task<OperationDetails> DeleteDebtStoreAsync(DebtStoreDto DebtStoreDto)
        {
            if (DebtStoreDto == null)
            {
                Logger.Error("Something went wrong");
                return new OperationDetails(false, "К сожалению, что-то пошло не так....", "DebtStore");
            }

            DebtStore DebtStore = await unitOfWork.DebtStoreRepository.GetByIdAsync(DebtStoreDto.Id);
            if (DebtStore == null)
            {
                Logger.Error("Номенклатура не найдена");
                return new OperationDetails(false, "Номенклатура не найдена", "DebtStore");
            }

            try
            {
                await unitOfWork.DebtStoreRepository.DeleteAsync(DebtStore);
                await unitOfWork.SaveAsync();
                Logger.Info("Successfully deleted");
                return new OperationDetails(true);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return new OperationDetails(false, ex.Message);
            }
        }

        public IList<DebtStoreDto> GetDebtStoreByDebtId(int id)
        {
            var debtStore = unitOfWork.DebtStoreRepository.GetByDebtId(id);
            var debtStoreDto = debtStore.Select(p => mapper.Map<DebtStore, DebtStoreDto>(p)).ToList();
            foreach (var item in debtStoreDto)
            {
                item.DebtStoreName = (item.DebtStoreType == 1) ? StoreType.TTN : StoreType.Payment;
            }
            return debtStoreDto;
        }

        public async Task<DebtStoreDto> GetDebtStoreByIdAsync(int id)
        {
            DebtStore debtStore = await unitOfWork.DebtStoreRepository.GetByIdAsync(id);
            return mapper.Map<DebtStore, DebtStoreDto>(debtStore);
        }

        public async Task<OperationDetails> UpdateDebtStoreAsync(DebtStoreDto debtStoreDto)
        {
            if (debtStoreDto == null)
            {
                Logger.Error("Something went wrong");
                return new OperationDetails(false, "К сожалению, что-то пошло не так....", "DebtStore");
            }

            DebtStore debtStore = mapper.Map<DebtStoreDto, DebtStore>(debtStoreDto);

            try
            {
                await unitOfWork.DebtStoreRepository.UpdateAsync(debtStore);
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
