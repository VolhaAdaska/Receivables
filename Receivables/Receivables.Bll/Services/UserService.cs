using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Receivables.Bll.Dto;
using Receivables.Bll.Infrastructure;
using Receivables.Bll.Interfaces;
using Receivables.Dal.Interfaces;
using Receivables.Dal.Models;

namespace Receivables.Bll.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {
        }

        public async Task<OperationDetails> AddUserAsync(UserDto userDto)
        {
            if (userDto == null)
            {
                throw new ArgumentNullException(nameof(userDto));
            }

            ApplicationUser user = await unitOfWork.UserManager.FindByEmailAsync(userDto.Email);

            if (user != null)
            {
                return new OperationDetails(false, "A user with this e-mail already exists", "Email");
            }

            user = mapper.Map<UserDto, ApplicationUser>(userDto);

            await unitOfWork.UserManager.CreateAsync(user, userDto.Password);
            await unitOfWork.UserManager.AddToRoleAsync(user.Id, userDto.Role);
            await unitOfWork.SaveAsync();

            return new OperationDetails(true, "Registration successful");
        }

        public async Task<ClaimsIdentity> CheckUserCredentialsAsync(UserDto userDto)
        {
            if (userDto == null)
            {
                throw new ArgumentNullException(nameof(userDto));
            }

            ClaimsIdentity claim = null;

            ApplicationUser user = await unitOfWork.UserManager.FindByEmailAsync(userDto.Email);

            if (user != null && await unitOfWork.UserManager.CheckPasswordAsync(user, userDto.Password))
            {
                claim = await unitOfWork.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            }
            return claim;
        }

        public async Task<UserDto> GetUserByIdAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new ValidationException($"userId {userId} is not valid");
            }

            ApplicationUser user = await unitOfWork.UserManager.FindByIdAsync(userId);

            if (user == null)
            {
                return null;
            }

            var result = mapper.Map<ApplicationUser, UserDto>(user);

            result.Password = user.PasswordHash;

            return result;
        }

        public async Task<OperationDetails> UpdateProfileAsync(UserDto userDto)
        {
            if (userDto == null)
            {
                throw new ArgumentNullException(nameof(userDto));
            }

            var user = await unitOfWork.UserManager.FindByIdAsync(userDto.Id);

            if (user == null)
            {
                return new OperationDetails(false, "Такой пользователь не существует", "User");
            }

            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.PhoneNumber = userDto.PhoneNumber;
            user.Address = userDto.Address;
            user.City = userDto.City;
            user.Country = userDto.Country;
            user.PostCode = userDto.PostCode;

            var identityResult = await unitOfWork.UserManager.UpdateAsync(user);

            if (!identityResult.Succeeded)
            {
                return new OperationDetails(false, "К сожалению, что-то пошло не так", "User");
            }

            return new OperationDetails(true, "Update successful");
        }
    }
}