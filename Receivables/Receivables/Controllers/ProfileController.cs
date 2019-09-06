using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Receivables.Bll.Dto;
using Receivables.Bll.Infrastructure;
using Receivables.Bll.Interfaces;
using Receivables.Models;

namespace Receivables.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public ProfileController(IUserService userService, IAuthenticationManager authManager, IMapper mapper)
        {
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var userId = User.Identity.GetUserId();
            var userDto = await userService.GetUserByIdAsync(userId);

            if (userDto == null)
            {
                throw new ArgumentNullException("Пользователь с таким id не найден");
            }
            else
            {
                var model = new ProfileModel
                {
                    HasPassword = userDto.Password != null,
                    PhoneNumber = userDto.PhoneNumber,
                    Address = userDto.Address,
                    //BrowserRemembered = await AuthenticationManager.TwoFactorBrowserRememberedAsync(userId),
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    City = userDto.City,
                    Country = userDto.Country,
                    Email = userDto.Email,
                    PostCode = userDto.PostCode
                };
                return View(model);
            }          
        }

        [HttpPost]
        public async Task<ActionResult> Index(ProfileModel profileModel)
        {
            if (!ModelState.IsValid)
            {
                return View(profileModel);
            }

            string userId = User.Identity.GetUserId();

            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new ValidationException("User claim value not found");
            }

            UserDto userDto = mapper.Map<ProfileModel, UserDto>(profileModel);
            userDto.Id = User.Identity.GetUserId();
            OperationDetails operationDetails = await userService.UpdateProfileAsync(userDto);

            if (!operationDetails.Succedeed)
            {
                ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }

            return View(profileModel);
        }
    }
}