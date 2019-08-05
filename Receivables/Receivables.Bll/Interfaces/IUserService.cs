using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Receivables.BusinessLogic.Infrastructure;
using Receivables.DTO;

namespace Receivables.Bll.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> AddUserAsync(UserDto userDto);

        Task<ClaimsIdentity> CheckUserCredentialsAsync(UserDto userDto);
    }
}