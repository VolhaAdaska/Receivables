using System;
using System.Web.Mvc;
using AutoMapper;
using Receivables.Bll.Interfaces;

namespace Receivables.Controllers
{
    public class DebtPaidController : Controller
    {
        private readonly IDebtPaidService debtPaidService;
        private readonly IMapper mapper;

        public DebtPaidController(IDebtPaidService debtPaidService, IMapper mapper)
        {
            this.debtPaidService = debtPaidService ?? throw new ArgumentNullException(nameof(debtPaidService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: DebtPaid
        public ActionResult Index()
        {
            return View();
        }
    }
}