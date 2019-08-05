using Autofac;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Receivables.Dal.Context;
using Receivables.Dal.Interfaces;
using Receivables.DAL.Models.Identity;
using System;
using System.Threading.Tasks;

namespace Receivables.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GodelBenefitContext context;
        private readonly ILifetimeScope lifetimeScope;
        private UserManager<ApplicationUser> userManager;
        private RoleManager<ApplicationRole> roleManager;

        public UnitOfWork(GodelBenefitContext context, ILifetimeScope lifetimeScope)
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

        public IStoreTypeRepository StoreTypeRepository => GetRepository<IStoreTypeRepository>();


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