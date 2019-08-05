using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Receivables.Bll.Dto;
using Receivables.Bll.Infrastructure;

namespace Receivables.Bll.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> AddUserAsync(UserDto userDto);

        Task<ClaimsIdentity> CheckUserCredentialsAsync(UserDto userDto);
    }
}