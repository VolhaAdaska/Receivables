using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using Receivables.Dal.Models;

namespace Receivables.Dal.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        RoleManager<ApplicationRole> RoleManager { get; }

        UserManager<ApplicationUser> UserManager { get; }

        IStoreRepository StoreRepository { get; }

        ICustomerRepository CustomerRepository { get; }

        IAgreementRepository AgreementRepository { get; }

        IProductRepository ProductRepository { get; }

        IDebtRepository DebtRepository { get; }

        Task SaveAsync();
    }
}