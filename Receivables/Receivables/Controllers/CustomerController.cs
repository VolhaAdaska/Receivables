using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Receivables.Bll.Dto;
using Receivables.Bll.Interfaces;
using Receivables.Models;

namespace Receivables.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerService customerService;
        private readonly IMapper mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            this.customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            var activeCustomers = customerService.GetActiveCustomer(userId);
            return View(activeCustomers.Select(customer => mapper.Map<CustomerDto, CustomerModel>(customer)));
        }
    }
}