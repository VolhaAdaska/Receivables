using System.Security.Claims;
using System.Threading.Tasks;
using Receivables.DTO;
using Receivables.BusinessLogic.Infrastructure;
using System;

namespace Receivables.BusinessLogic.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> AddUserAsync(UserDto userDto);

        Task<ClaimsIdentity> CheckUserCredentialsAsync(UserDto userDto);
    }
}