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
        private List<CustomerSearchModel> customerSearchModels;

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
        public ActionResult Index()
        {
            var model = new CalculationModel();
            var customers = customerService.GetAllCustomer();
            customerSearchModels = customers.Select(p => mapper.Map<CustomerDto, CustomerSearchModel>(p)).ToList();
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

        public ActionResult AutocompleteSearch(string term)
        {
            if (customerSearchModels == null)
            {
                var customers = customerService.GetAllCustomer();
                customerSearchModels = customers.Select(p => mapper.Map<CustomerDto, CustomerSearchModel>(p)).ToList();
            }

            var models = customerSearchModels.Where(a => a.Name.Contains(term))
                            .Select(a => new { value = a.Name })
                            .Distinct();

            return Json(models, JsonRequestBehavior.AllowGet);
        }
    }
}