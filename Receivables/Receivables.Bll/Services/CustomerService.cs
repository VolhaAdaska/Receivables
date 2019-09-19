using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NLog;
using Receivables.Bll.Dto;
using Receivables.Bll.Infrastructure;
using Receivables.Bll.Interfaces;
using Receivables.Dal.Interfaces;
using Receivables.Dal.Models;

namespace Receivables.Bll.Services
{
    public class CustomerService : BaseService, ICustomerService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
           : base(unitOfWork, mapper)
        {
        }

        public async Task<OperationDetails> AddCustomerAsync(CustomerDto customerDto)
        {
            if (customerDto == null)
            {
                Logger.Error("Something went wrong");
                return new OperationDetails(false, "Something went wrong", "Customer");
            }

            Customer customer = mapper.Map<CustomerDto, Customer>(customerDto);

            try
            {
                if (unitOfWork.CustomerRepository.GetByINN(customerDto.INN) != null)
                {
                    Logger.Error("A Customer with this name already exists");
                    return new OperationDetails(false, "Контрагент с таким ИНН уже существует", "Customer");
                }
                await unitOfWork.CustomerRepository.CreateAsync(customer);
                await unitOfWork.SaveAsync();
                Logger.Info("Successfully added");
                return new OperationDetails(true);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return new OperationDetails(false, "Unfortunately, something went wrong....", "Customer");
            }
        }

        public async Task<OperationDetails> DeleteCustomerAsync(CustomerDto customerDto)
        {
            if (customerDto == null)
            {
                Logger.Error("Customer is null");
                return new OperationDetails(false, "Something went wrong", "Customer");
            }

            Customer customer = await unitOfWork.CustomerRepository.GetByIdAsync(customerDto.Id);
            if (customer == null)
            {
                Logger.Error("Контрагент не найден");
                return new OperationDetails(false, "Контрагент не найден", "Customer");
            }

            try
            {
                await unitOfWork.CustomerRepository.DeleteAsync(customer);
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

        public IEnumerable<CustomerDto> GetActiveCustomer(string userId)
        {
            var customers = unitOfWork.CustomerRepository.GetActiveCustomer(userId);
            return customers.Select(p => mapper.Map<Customer, CustomerDto>(p)).ToList();
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(int id)
        {
            Customer customer = await unitOfWork.CustomerRepository.GetByIdAsync(id);
            return mapper.Map<Customer, CustomerDto>(customer);
        }

        public CustomerDto GetCustomerByName(string name)
        {
            Customer customer = unitOfWork.CustomerRepository.GetCustomerByName(name);
            return mapper.Map<Customer, CustomerDto>(customer);
        }

        public async Task<OperationDetails> UpdateCustomerAsync(CustomerDto customerDto)
        {
            if (customerDto == null)
            {
                Logger.Error("Customer is null");
                return new OperationDetails(false, "Something went wrong", "Customer");
            }

            Customer customer = mapper.Map<CustomerDto, Customer>(customerDto);
            
            try
            {
                await unitOfWork.CustomerRepository.UpdateAsync(customer);
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
