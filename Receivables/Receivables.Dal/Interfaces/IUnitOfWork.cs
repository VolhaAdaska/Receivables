using Microsoft.AspNet.Identity;
using Receivables.DAL.Models.Identity;
using System;
using System.Threading.Tasks;

namespace Receivables.Dal.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        RoleManager<ApplicationRole> RoleManager { get; }

        UserManager<ApplicationUser> UserManager { get; }

        IStoreRepository StoreRepository { get; }

        IStoreTypeRepository StoreTypeRepository { get; }

        Task SaveAsync();
    }
}