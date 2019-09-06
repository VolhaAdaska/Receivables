using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Receivables.Bll.Dto;
using Receivables.Bll.Infrastructure;
using Receivables.Bll.Interfaces;
using Receivables.Models;

namespace Receivables.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerService customerService;
        private readonly IAgreementService agreementService;
        private readonly IMapper mapper;
        
        public CustomerController(
            ICustomerService customerService,
            IAgreementService agreementService,
            IMapper mapper)
        {
            this.customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            this.agreementService = agreementService ?? throw new ArgumentNullException(nameof(agreementService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            var activeCustomers = customerService.GetActiveCustomer(userId);
            return View(activeCustomers.Select(customer => mapper.Map<CustomerDto, CustomerModel>(customer)));
        }

        [HttpPost]
        public ActionResult Index(string userId)
        {
            var activeCustomers = customerService.GetActiveCustomer(userId);
            return View(activeCustomers.Select(customer => mapper.Map<CustomerDto, CustomerModel>(customer)));
        }

        [HttpGet]
        public ActionResult AddCustomer()
        {
            CustomerModel customerViewModel = new CustomerModel();

            return View(customerViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> AddCustomer(CustomerModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            string userId = User.Identity.GetUserId();
            CustomerDto customerDto = mapper.Map<CustomerModel, CustomerDto>(model);
            customerDto.UserId = userId;
            customerDto.IsActive = true;
            customerDto.IsBlocked = false;
            OperationDetails operationDetails = await customerService.AddCustomerAsync(customerDto);
            if (operationDetails.Succedeed)
            {
                return RedirectToAction("Index", "Customer", userId);
            }
            ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            CustomerDto customerDto = new CustomerDto { Id = id };
            string userId = User.Identity.GetUserId();

            OperationDetails operationDetails = await customerService.DeleteCustomerAsync(customerDto);
            if (operationDetails.Succedeed)
            {
                return RedirectToAction("Index", "Customer", userId);
            }
            ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            return RedirectToAction("Index", "Customer", userId);
        }

        [HttpGet]
        public async Task<ActionResult> UpdateCustomer(int id)
        {
            CustomerDto customerDto = await customerService.GetCustomerByIdAsync(id);
            return View(mapper.Map<CustomerDto, CustomerModel>(customerDto));
        }

        [HttpPost]
        public async Task<ActionResult> UpdateCustomer(CustomerModel model)
        {
            CustomerDto customerDto = mapper.Map<CustomerModel, CustomerDto>(model);

            OperationDetails operationDetails = await customerService.UpdateCustomerAsync(customerDto);
                                  
            if (operationDetails.Succedeed)
            {
                return RedirectToAction("Index", "Customer");
            }
            ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            return RedirectToAction("Index", "Customer");
        }

        [HttpGet]
        public async Task<ActionResult> Profile(int id)
        {
            CustomerDto customerDto = await customerService.GetCustomerByIdAsync(id);
            var customer = mapper.Map<CustomerDto, CustomerModel>(customerDto);
            var agreements = agreementService.GetActiveAgreement(id);
            var agreementsView = agreements.Select(doc => mapper.Map<AgreementDto, AgreementModel>(doc));
            customer.Agreements = agreementsView;
            return View(customer);
        }
    }
}