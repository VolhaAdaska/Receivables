using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Receivables.Bll.Dto;
using Receivables.Bll.Interfaces;
using Receivables.Models;

namespace Receivables.Controllers
{
    [Authorize]
    public class CalculationController : Controller
    {
        private readonly IMapper mapper;
        private readonly ICustomerService customerService;
        private readonly ICalculationService calculationService;

        public CalculationController(
            IMapper mapper, 
            ICustomerService customerService,
            ICalculationService calculationService)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            this.calculationService = calculationService ?? throw new ArgumentNullException(nameof(calculationService));
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var model = new CalculationModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult AccountSearch(string name, DateTime? startDate, DateTime? endDate)
        {
            var model = new List<AccountModel>();

            if (string.IsNullOrEmpty(name))
            {
                return PartialView(model);
            }

            var customerId = customerService.GetCustomerByName(name)?.Id;

            if (string.IsNullOrEmpty(name))
            {
                return PartialView(model);
            }

            var accounts = calculationService.GetAccountsByCustomerId(customerId.Value, startDate, endDate);
            model = accounts.Select(p => mapper.Map<AccountDto, AccountModel>(p)).ToList();

            var result = from account in model
                         orderby account.AgreementName, account.Date
                         select account;

            return PartialView(result);
        }
    }
}