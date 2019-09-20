using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using NLog;
using Receivables.Bll.Dto;
using Receivables.Bll.Interfaces;
using Receivables.Dal.Interfaces;
using Receivables.Dal.Models;

namespace Receivables.Bll.Services
{
    public class CalculationService : BaseService, ICalculationService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public CalculationService(IUnitOfWork unitOfWork, IMapper mapper)
           : base(unitOfWork, mapper)
        {
        }

        public IList<AccountDto> GetAccountsByCustomerId(int customerId, DateTime? startDate, DateTime? endDate)
        {
            var accounts = unitOfWork.AccountRepository.GetAccountByCustomerId(customerId, startDate, endDate);
            return accounts.Select(p => mapper.Map<Account, AccountDto>(p)).ToList();
        }
    }
}