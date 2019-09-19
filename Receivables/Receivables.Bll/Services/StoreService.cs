using AutoMapper;
using NLog;
using Receivables.Bll.Dto;
using Receivables.Bll.Infrastructure;
using Receivables.Bll.Interfaces;
using Receivables.Dal.Interfaces;
using Receivables.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Receivables.Bll.Services
{
    public class StoreService : BaseService, IStoreService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public StoreService(IUnitOfWork unitOfWork, IMapper mapper)
           : base(unitOfWork, mapper)
        {
        }

        public async Task<OperationDetails> AddStoreAsync(StoreDto storeDto)
        {
            if (storeDto == null)
            {
                Logger.Error("Something went wrong");
                return new OperationDetails(false, "Something went wrong", "Store");
            }

            Store store = mapper.Map<StoreDto, Store>(storeDto);
            try
            {
                if (unitOfWork.StoreRepository.GetByName(store.Name) != null)
                {
                    Logger.Error("A Store with this name already exists");
                    return new OperationDetails(false, "A Store with this name already exists", "Store");
                }
                await unitOfWork.StoreRepository.CreateAsync(store);
                await unitOfWork.SaveAsync();
                Logger.Info("Successfully added");
                return new OperationDetails(true);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return new OperationDetails(false, "Unfortunately, something went wrong....", "Store");
            }
        }

        public async Task<OperationDetails> DeleteStoreAsync(StoreDto storeDto)
        {
            if (storeDto == null)
            {
                Logger.Error("Something went wrong");
                return new OperationDetails(false, "Something went wrong", "Store");
            }

            Store store = await unitOfWork.StoreRepository.GetByIdAsync(storeDto.Id);
            if (store == null)
            {
                Logger.Error("Store not found");
                return new OperationDetails(false, "Store not found", "Store");
            }

            try
            {
                await unitOfWork.StoreRepository.DeleteAsync(store);
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

        public async Task<OperationDetails> UpdateStoreAsync(StoreDto storeDto)
        {
            if (storeDto == null)
            {
                Logger.Error("Something went wrong");
                return new OperationDetails(false, "Something went wrong", "Store");
            }

            Store store = mapper.Map<StoreDto, Store>(storeDto);

            try
            {
                await unitOfWork.StoreRepository.UpdateAsync(store);
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
        
        public async Task<StoreDto> GetStoreByIdAsync(int id)
        {
            Store store = await unitOfWork.StoreRepository.GetByIdAsync(id);
            return mapper.Map<Store, StoreDto>(store);
        }

        public IList<StoreDto> GetAllStore()
        {
            var stores = unitOfWork.StoreRepository.GetAll();
            return stores.Select(p => mapper.Map<Store, StoreDto>(p)).ToList();
        }
    }
}