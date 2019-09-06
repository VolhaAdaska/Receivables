using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Receivables.Bll.Dto;
using Receivables.Bll.Interfaces;
using Receivables.Models;

namespace Receivables.Controllers
{
    [Authorize]
    public class AgreementController : Controller
    {
        private readonly IAgreementService agreementService;
        private readonly IMapper mapper;

        public AgreementController(IAgreementService agreementService, IMapper mapper)
        {
            this.agreementService = agreementService ?? throw new ArgumentNullException(nameof(agreementService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult> Index(int id)
        {
            AgreementDto agreementDto = await agreementService.GetAgreementByIdAsync(id);
            return View(mapper.Map<AgreementDto, AgreementModel>(agreementDto));
        }
    }
}