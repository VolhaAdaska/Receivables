﻿using Microsoft.AspNet.Identity.EntityFramework;
using Receivables.Dal.Context.Configurations;
using Receivables.Dal.Models;
using System;
using System.Data.Entity;

namespace Receivables.Dal.Context
{
    public class ReceivablesContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Agreement> Agreements { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Debt> Debts { get; set; }

        public DbSet<DebtClaim> DebtClaims { get; set; }

        public DbSet<DebtPaid> DebtPaids { get; set; }

        public DbSet<DebtStatus> DebtStatuses { get; set; }

        public DbSet<DebtStore> DebtStores { get; set; }

        public ReceivablesContext()
            : base("ReceivablesDatabase")
        {
            Database.SetInitializer(new ReceivablesContextInitializer());
            Database.Initialize(false);

            Type providerService = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        }

        public static ReceivablesContext Create()
        {
            return new ReceivablesContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ApplicationUserConfiguration());
            modelBuilder.Configurations.Add(new StoreConfigurations());
            modelBuilder.Configurations.Add(new AgreementConfigurations());
            modelBuilder.Configurations.Add(new CustomerConfigurations());
            modelBuilder.Configurations.Add(new ProductConfigurations());
            modelBuilder.Configurations.Add(new AccountConfigurations());
            modelBuilder.Configurations.Add(new DebtConfigurations());
            modelBuilder.Configurations.Add(new DebtClaimConfigurations());
            modelBuilder.Configurations.Add(new DebtPaidConfigurations());
            modelBuilder.Configurations.Add(new DebtStatusConfigurations());
            modelBuilder.Configurations.Add(new DebtStoreConfigurations());
        }
    }
}
