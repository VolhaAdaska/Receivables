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
                    return new OperationDetails(false, "Контрагент с таким ИНН уже существует", "Контрагенты");
                }
                await unitOfWork.CustomerRepository.CreateAsync(customer);
                await unitOfWork.SaveAsync();
                Logger.Info("Successfully added");
                return new OperationDetails(true);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return new OperationDetails(false, "Unfortunately, something went wrong....", "Контрагенты");
            }
        }

        public Task<OperationDetails> DeleteCustomerAsync(CustomerDto customerDto)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CustomerDto> GetActiveCustomer(string userId)
        {
            var customers = unitOfWork.CustomerRepository.GetActiveCustomer(userId);
            return customers.Select(p => mapper.Map<Customer, CustomerDto>(p)).ToList();
        }

        public Task<CustomerDto> GetCustomerByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<OperationDetails> UpdateCustomerAsync(CustomerDto customerDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
