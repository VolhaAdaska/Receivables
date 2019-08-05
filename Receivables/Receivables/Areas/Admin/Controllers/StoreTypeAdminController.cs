using AutoMapper;
using Receivables.BusinessLogic.Infrastructure;
using Receivables.BusinessLogic.Interfaces;
using Receivables.DAL.Core;
using Receivables.DTO;
using Receivables.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Receivables.Areas.Admin.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class StoreTypeAdminController : Controller
    {
        private readonly IStoreTypeService storeTypeService;
        private readonly IMapper mapper;

        public StoreTypeAdminController(IStoreTypeService storeTypeService, IMapper mapper)
        {
            this.storeTypeService = storeTypeService ?? throw new ArgumentNullException(nameof(storeTypeService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult StoreTypeList()
        {
            var result = storeTypeService.GetAllStoreType();
            var newModel = mapper.Map<IList<StoreTypeDto>, IList<StoreTypeViewModel>>(result);
            return View(newModel);
        }

        [HttpGet]
        public ActionResult AddStoreType()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddStoreType(StoreTypeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            StoreTypeDto storeTypeDto = mapper.Map<StoreTypeViewModel, StoreTypeDto>(model);
            OperationDetails operationDetails = await storeTypeService.AddStoreTypeAsync(storeTypeDto);
            if (operationDetails.Succedeed)
            {
                return View("SuccessAdd");
            }
            ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> DeleteStoreType(StoreTypeViewModel model)
        {
            StoreTypeDto storeTypeDto = mapper.Map<StoreTypeViewModel, StoreTypeDto>(model);

            OperationDetails operationDetails = await storeTypeService.DeleteStoreTypeAsync(storeTypeDto);
            if (operationDetails.Succedeed)
            {
                return RedirectToAction("StoreTypeList");
            }
            ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            return RedirectToAction("StoreTypeList");
        }

        [HttpGet]
        public async Task<ActionResult> UpdateStoreType(int id)
        {
            StoreTypeDto storeTypeDto = await storeTypeService.GetStoreTypeByIdAsync(id);
            return View(mapper.Map<StoreTypeDto, StoreTypeViewModel>(storeTypeDto));
        }

        [HttpPost]
        public async Task<ActionResult> UpdateStoreType(StoreTypeViewModel model)
        {
            StoreTypeDto storeTypeDto = mapper.Map<StoreTypeViewModel, StoreTypeDto>(model);

            OperationDetails operationDetails = await storeTypeService.UpdateStoreTypeAsync(storeTypeDto);
            if (operationDetails.Succedeed)
            {
                return RedirectToAction("StoreTypeList");
            }
            ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            return RedirectToAction("StoreTypeList");
        }
    }
}