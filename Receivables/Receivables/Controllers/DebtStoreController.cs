using System;
using System.Web.Mvc;
using AutoMapper;
using Receivables.Bll.Interfaces;

namespace Receivables.Controllers
{
    public class DebtStoreController : Controller
    {
        private readonly IDebtStoreService debtStoreService;
        private readonly IMapper mapper;

        public DebtStoreController(IDebtStoreService debtStoreService, IMapper mapper)
        {
            this.debtStoreService = debtStoreService ?? throw new ArgumentNullException(nameof(debtStoreService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: DebtStore
        public ActionResult Index()
        {
            return View();
        }
    }
}