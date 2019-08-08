using AutoMapper;
using Receivables.Bll.Interfaces;
using System;
using System.Web.Mvc;

namespace Receivables.Controllers
{
    [Authorize]
    public class StoreController : Controller
    {
        private readonly IStoreService storeService;
        private readonly IMapper mapper;

        public StoreController(IStoreService storeService, IMapper mapper)
        {
            this.storeService = storeService ?? throw new ArgumentNullException(nameof(storeService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult StoreList(int id)
        {
            return View();
        }
    }
}