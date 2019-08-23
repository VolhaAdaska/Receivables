using Autofac;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Receivables.Dal.Context;
using Receivables.Dal.Interfaces;
using System;
using System.Threading.Tasks;
using Receivables.Dal.Models;

namespace Receivables.Dal.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ReceivablesContext context;
        private readonly ILifetimeScope lifetimeScope;
        private UserManager<ApplicationUser> userManager;
        private RoleManager<ApplicationRole> roleManager;

        public UnitOfWork(ReceivablesContext context, ILifetimeScope lifetimeScope)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.lifetimeScope = lifetimeScope ?? throw new ArgumentNullException(nameof(lifetimeScope));
        }

        public RoleManager<ApplicationRole> RoleManager
        {
            get => roleManager ??
                   (roleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(context)));
        }

        public UserManager<ApplicationUser> UserManager
        {
            get => userManager ??
                   (userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)));
        }

        public IStoreRepository StoreRepository => GetRepository<IStoreRepository>();

        public ICustomerRepository CustomerRepository => GetRepository<ICustomerRepository>();

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
        private T GetRepository<T>() where T : class
        {
            T repository = lifetimeScope.Resolve<T>();
            return repository;
        }
        private bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                context.Dispose();
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}