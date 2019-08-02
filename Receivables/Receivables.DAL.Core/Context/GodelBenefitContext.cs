using System;
using System.Data.Entity;
using Receivables.DAL.Core.Context.Configurations;
using Receivables.DAL.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Receivables.DAL.Models.Identity;

namespace Receivables.DAL.Core.Context
{
    public class GodelBenefitContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreType> StoreTypes { get; set; }

        public GodelBenefitContext()
            : base("GodelBenefitDatabase")
        {
            Database.SetInitializer(new GodelBenefitContextInitializer());
            Database.Initialize(false);

            Type providerService = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        }

        public static GodelBenefitContext Create()
        {
            return new GodelBenefitContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StoreConfigurations());
            modelBuilder.Configurations.Add(new StoreTypeConfigurations());

            base.OnModelCreating(modelBuilder);
        }
    }
}
