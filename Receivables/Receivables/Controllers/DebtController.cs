using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Receivables.Bll.Interfaces;
using Receivables.Bll.Models;
using Receivables.Models;

namespace Receivables.Controllers
{
    public class DebtController : Controller
    {
        private readonly IDebtService debtService;
        private readonly IMapper mapper;

        public DebtController(IDebtService debtService, IMapper mapper)
        {
            this.debtService = debtService ?? throw new ArgumentNullException(nameof(debtService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult Index()
        {
            var debts = new List<DebtModel>();
            debts.Add(new DebtModel
            {
                Id = 1,
                CustomerId = 1,
                CustomerName = "Belagro",
                CustomerINN = "123456870",
                SumDebt = 4414,
                Status = StatusDebt.NewStatus
            });
            return View(debts);
        }
    }
}