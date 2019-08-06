﻿using Microsoft.AspNet.Identity.EntityFramework;
using Receivables.Dal.Context.Configurations;
using Receivables.Dal.Models;
using System;
using System.Data.Entity;

namespace Receivables.Dal.Context
{
    public class ReceivablesContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreType> StoreTypes { get; set; }

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
            modelBuilder.Configurations.Add(new StoreConfigurations());
            modelBuilder.Configurations.Add(new StoreTypeConfigurations());
            modelBuilder.Configurations.Add(new AgreementConfigurations());
            modelBuilder.Configurations.Add(new CustomerConfigurations());

            base.OnModelCreating(modelBuilder);
        }
    }
}
