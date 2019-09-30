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
        private readonly IDebtPaidService debtPaid;
        private readonly IDebtStoreService debtStore;
        private readonly IDebtClaimService debtClaim;
        private readonly IMapper mapper;

        public DebtController(
            IDebtService debtService, 
            ICustomerService customerService,
            IAgreementService agreementService,
            IDebtStatusService debtStatus,
            IDebtPaidService debtPaid,
            IDebtStoreService debtStore,
            IDebtClaimService debtClaim,
            IMapper mapper)
        {
            this.debtService = debtService ?? throw new ArgumentNullException(nameof(debtService));
            this.customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            this.agreementService = agreementService ?? throw new ArgumentNullException(nameof(agreementService));
            this.debtStatus = debtStatus ?? throw new ArgumentNullException(nameof(debtStatus));
            this.debtPaid = debtPaid ?? throw new ArgumentNullException(nameof(debtPaid));
            this.debtStore = debtStore ?? throw new ArgumentNullException(nameof(debtStore));
            this.debtClaim = debtClaim ?? throw new ArgumentNullException(nameof(debtClaim));
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

            var debtPaidDto = debtPaid.GetDebtPaidByDebtId(debt.Id);
            debt.DebtPaid = GetDebtPaidModel(debtPaidDto.Sum, debt);

            var storesDto = debtStore.GetDebtStoreByDebtId(debt.Id);
            var stores = storesDto.Select(p => mapper.Map<DebtStoreDto, DebtStoreModel>(p)).ToList();
            debt.DebtStores = stores ?? new List<DebtStoreModel>();

            debt.DebtClaim = new DebtClaimModel
            {
                DebtId = 1,
                ClaimName = "ОД +%",
                DateClaimStart = DateTime.Now,
                DateClaimEnd = DateTime.Now,
                NumberClaim = "1",
                PenaltyRate = 0.15,
                RefinancingRate = 9.5
            };

            return debt;
        }

        private DebtPaidModel GetDebtPaidModel(decimal sum, DebtModel debt)
        {
            var stateDuty = (debt.StateDuty > sum) ? sum : debt.StateDuty;
            sum = sum - debt.StateDuty;

            var sumAmount = decimal.Zero;
            if (sum > 0)
            {
                sumAmount = debt.SumAmount > sum ? sum : debt.SumAmount;
                sum -= debt.SumAmount;
            }

            var fine = decimal.Zero;
            if (sum > 0)
            {
                var debtFine = debt.Penalties + debt.Fine + debt.InterestAmount;
                fine = debtFine > sum ? sum : debtFine;
            }

            return new DebtPaidModel
            {
                StateDuty = stateDuty,
                SumAmount = sumAmount,
                Fine = fine,
                DebtId = debt.Id,
                Total = stateDuty + sumAmount + fine
            };
        }
    }
}