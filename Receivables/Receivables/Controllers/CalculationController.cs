using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Receivables.Bll.Interfaces;
using Receivables.Models;

namespace Receivables.Controllers
{
    [Authorize]
    public class CalculationController : Controller
    {
        private readonly IMapper mapper;
        private readonly ICustomerService customerService;

        public CalculationController(IMapper mapper, ICustomerService customerService)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var model = new CalculationModel();
            return View(model);
        }

        [HttpPost]
        public IList<AccountModel> Index(string customerName, DateTime? startDate, DateTime? endDate)
        {

            var customerId = customerService.GetCustomerByName(customerName).Id;

            return new List<AccountModel>();
        }
    }
}