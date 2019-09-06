using System;
using System.Web.Mvc;
using AutoMapper;
using Receivables.Bll.Interfaces;

namespace Receivables.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            this.productService = productService ?? throw new ArgumentNullException(nameof(productService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
    }
}