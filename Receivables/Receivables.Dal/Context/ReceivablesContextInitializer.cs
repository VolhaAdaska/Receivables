﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Receivables.Dal.Models;
using System.Data.Entity;

namespace Receivables.Dal.Context
{
    public class ReceivablesContextInitializer : CreateDatabaseIfNotExists<ReceivablesContext>
    {
        protected override void Seed(ReceivablesContext context)
        {
            var roleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(context));
            roleManager.Create(new ApplicationRole { Name = UserRoles.Admin });
            roleManager.Create(new ApplicationRole { Name = UserRoles.User });

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var user = new ApplicationUser { Email = "adaskoov@gmail.com", UserName = UserRoles.Admin };
            userManager.Create(user, "!13InsAdmin");
            
            var admin = userManager.FindByEmail(user.Email);
            userManager.AddToRole(admin.Id, UserRoles.Admin);
            userManager.AddToRole(admin.Id, UserRoles.User);

            var simpleUser = new ApplicationUser { Email = "v.adaska@godeltech.com", UserName = UserRoles.User };
            userManager.Create(simpleUser, "!13InsAdaska");
            var simpleUserRole = userManager.FindByEmail(simpleUser.Email);
            userManager.AddToRole(simpleUserRole.Id, UserRoles.User);

            context.SaveChanges();

            InitializeCustomer(context, simpleUser);

           // base.Seed(context);
        }

        private void InitializeCustomer(ReceivablesContext context, ApplicationUser user)
        {
            var belagro = new Customer
            {
                Name = "Belagro",
                INN = "1236547891023",
                FullName = "ООО Белагро Бел",
                User = user,
                UserId = user.Id,
                IsActive = true
            };

            var aptekar = new Customer
            {
                Name = "Аптекарь",
                INN = "qwer1234",
                FullName = "Группа компаний Аптекарь",
                User = user,
                UserId = user.Id,
                IsActive = true
            };

            var wikium = new Customer
            {
                Name = "Викиум",
                INN = "sst567",
                FullName = " Викиум.ру",
                User = user,
                UserId = user.Id,
                IsActive = true
            };

            context.Customers.Add(belagro);
            context.Customers.Add(aptekar);
            context.Customers.Add(wikium);
            context.SaveChanges();
        }
    }
}
