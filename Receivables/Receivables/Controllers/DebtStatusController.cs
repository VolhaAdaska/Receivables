using System;
using System.Web.Mvc;
using AutoMapper;
using Receivables.Bll.Interfaces;

namespace Receivables.Controllers
{
    public class DebtStatusController : Controller
    {
        private readonly IDebtStatusService debtStatusService;
        private readonly IMapper mapper;

        public DebtStatusController(IDebtStatusService debtStatusService, IMapper mapper)
        {
            this.debtStatusService = debtStatusService ?? throw new ArgumentNullException(nameof(debtStatusService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: DebtStatus
        public ActionResult Index()
        {
            return View();
        }
    }
}