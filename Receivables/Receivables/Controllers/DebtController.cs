using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Receivables.Bll.Dto;
using Receivables.Bll.Interfaces;
using Receivables.Models;

namespace Receivables.Controllers
{
    public class DebtController : Controller
    {
        private readonly IDebtService debtService;
        private readonly ICustomerService customerService;
        private readonly IAgreementService agreementService;
        private readonly IMapper mapper;

        public DebtController(
            IDebtService debtService, 
            ICustomerService customerService,
            IAgreementService agreementService,
            IMapper mapper)
        {
            this.debtService = debtService ?? throw new ArgumentNullException(nameof(debtService));
            this.customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            this.agreementService = agreementService ?? throw new ArgumentNullException(nameof(agreementService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var activeDebts = debtService.GetActiveDebt();
            foreach (var item in activeDebts)
            {
                CustomerDto customerDto = await customerService.GetCustomerByIdAsync(item.CustomerId).ConfigureAwait(false);
                item.CustomerINN = customerDto.INN;
                item.CustomerName = customerDto.Name;
            }
            return View(activeDebts.Select(p => mapper.Map<DebtDto, DebtModel>(p)));
        }

        [HttpGet]
        public async Task<ActionResult> ProfileDebt(int id)
        {
            var debtDto = await debtService.GetDebtByIdAsync(id);
            var debt = mapper.Map<DebtDto, DebtModel>(debtDto);
            debt = await EnrichDebtModel(debt, debtDto);
            return View(debt);
        }

        private async Task<DebtModel> EnrichDebtModel(DebtModel debt, DebtDto debtDto)
        {
            var customerDto = await customerService.GetCustomerByIdAsync(debtDto.CustomerId).ConfigureAwait(false);
            var agreemnetDto = await agreementService.GetAgreementByIdAsync(debtDto.AgreementId).ConfigureAwait(false);

            debt.CustomerINN = customerDto.INN;
            debt.CustomerName = customerDto.Name;
            debt.AgreementName = agreemnetDto.Name;
            debt.Postponement = agreemnetDto.Postponement;

            return debt;
        }
    }
}