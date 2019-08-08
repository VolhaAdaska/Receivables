using System;
using System.Web.Mvc;
using AutoMapper;
using System.Linq;
using Receivables.Dal;
using System.Threading.Tasks;
using System.Collections.Generic;
using Receivables.Bll.Dto;
using Receivables.Bll.Infrastructure;
using Receivables.Bll.Interfaces;
using Receivables.Models;

namespace Receivables.Areas.Admin.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class StoreAdminController : Controller
    {
        private readonly IStoreService storeService;
        private readonly IMapper mapper;

        public StoreAdminController(IStoreService storeService, IMapper mapper)
        {
            this.storeService = storeService ?? throw new ArgumentNullException(nameof(storeService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        
        [HttpGet]
        public ActionResult AddStore()
        {
            StoreViewModel storeViewModel = new StoreViewModel();

            return View(storeViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> AddStore(StoreViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            StoreDto storeDto = mapper.Map<StoreViewModel, StoreDto>(model);
            OperationDetails operationDetails = await storeService.AddStoreAsync(storeDto);
            if (operationDetails.Succedeed)
            {
                return View("SuccessAdd");
            }
            ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            return View(model);
        }

    

        [HttpGet]
        public async Task<ActionResult> DeleteStore(StoreViewModel model)
        {
            StoreDto storeDto = mapper.Map<StoreViewModel, StoreDto>(model);

            OperationDetails operationDetails = await storeService.DeleteStoreAsync(storeDto);
            if (operationDetails.Succedeed)
            {
                return View("StoreList");
            }
            ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            return View("StoreList");
        }

        [HttpGet]
        public async Task<ActionResult> UpdateStore(int id)
        {
            StoreDto storeDto = await storeService.GetStoreByIdAsync(id);
            return View(mapper.Map<StoreDto, StoreViewModel>(storeDto));
        }

        [HttpPost]
        public async Task<ActionResult> UpdateStore(StoreViewModel model)
        {
            StoreDto storeDto = mapper.Map<StoreViewModel, StoreDto>(model);

            OperationDetails operationDetails = await storeService.UpdateStoreAsync(storeDto);
            if (operationDetails.Succedeed)
            {
                return View("StoreList");
            }
            ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            return View("StoreList");
        }
    }
}

