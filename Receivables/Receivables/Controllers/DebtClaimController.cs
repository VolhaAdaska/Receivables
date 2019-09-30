using System;
using System.Web.Mvc;
using AutoMapper;
using Receivables.Bll.Interfaces;

namespace Receivables.Controllers
{
    public class DebtClaimController : Controller
    {
        private readonly IDebtClaimService debtClaimService;
        private readonly IMapper mapper;

        public DebtClaimController(IDebtClaimService debtClaimService, IMapper mapper)
        {
            this.debtClaimService = debtClaimService ?? throw new ArgumentNullException(nameof(debtClaimService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: DebtClaim
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CalculateClaim()
        {
            return PartialView();
        }
    }
}