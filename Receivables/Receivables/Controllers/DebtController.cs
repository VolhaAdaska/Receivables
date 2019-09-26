using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Receivables.Bll.Dto;
using Receivables.Bll.Infrastructure;
using Receivables.Bll.Interfaces;
using Receivables.Models;

namespace Receivables.Controllers
{
    [Authorize]
    public class DebtController : Controller
    {
        private readonly IDebtService debtService;
        private readonly ICustomerService customerService;
        private readonly IAgreementService agreementService;
        private readonly IDebtStatusService debtStatus;
        private readonly IMapper mapper;

        public DebtController(
            IDebtService debtService, 
            ICustomerService customerService,
            IAgreementService agreementService,
            IDebtStatusService debtStatus,
            IMapper mapper)
        {
            this.debtService = debtService ?? throw new ArgumentNullException(nameof(debtService));
            this.customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            this.agreementService = agreementService ?? throw new ArgumentNullException(nameof(agreementService));
            this.debtStatus = debtStatus ?? throw new ArgumentNullException(nameof(debtStatus));
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

        [HttpPost]
        public async Task<ActionResult> UpdateDebt(DebtModel model)
        {
            DebtDto debtDto = mapper.Map<DebtModel, DebtDto>(model);

            OperationDetails operationDetails = await debtService.UpdateDebtAsync(debtDto);

            if (operationDetails.Succedeed)
            {
                return RedirectToAction("Index", "Debt");
            }
            ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            return RedirectToAction("Index", "Debt");
        }

        [HttpGet]
        public async Task<ActionResult> CloseDebt(int id)
        {
            OperationDetails operationDetails = await debtService.CloseDebt(id);

            if (operationDetails.Succedeed)
            {
                return RedirectToAction("Index", "Debt");
            }
            ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            return RedirectToAction("Index", "Debt");
        }

        [HttpGet]
        public async Task<ActionResult> ProfileStatus(int id)
        {
            var debtDto = await debtService.GetDebtByIdAsync(id);
            var debt = mapper.Map<DebtDto, DebtModel>(debtDto);
            debt = await EnrichDebtModel(debt, debtDto);
            return PartialView(debt);
        }

        private async Task<DebtModel> EnrichDebtModel(DebtModel debt, DebtDto debtDto)
        {
            var customerDto = await customerService.GetCustomerByIdAsync(debtDto.CustomerId).ConfigureAwait(false);
            var agreemnetDto = await agreementService.GetAgreementByIdAsync(debtDto.AgreementId).ConfigureAwait(false);

            debt.CustomerINN = customerDto.INN;
            debt.CustomerName = customerDto.Name;
            debt.AgreementName = agreemnetDto.Name;
            debt.Postponement = agreemnetDto.Postponement;
            debt.Total = debt.StateDuty + debt.Fine + debt.StateDuty + debt.Penalties + debt.InterestAmount;
            debt.TotalExacted = debt.StateDutyExacted + debt.FineExacted + debt.StateDutyExacted + debt.PenaltiesExacted + debt.InterestAmountExacted;
            var statusDto = debtStatus.GetDebtStatusByDebtId(debt.Id);
            var status = statusDto.Select(p => mapper.Map<DebtStatusDto, DebtStatusModel>(p)).ToList();
            
            debt.DebtStatuses = status ?? new List<DebtStatusModel>();
            return debt;
        }
    }
}