using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Receivables.Dal.Models;
using System;
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

            var simpleUser = new ApplicationUser
            {
                Email = "v.adaska@godeltech.com",
                UserName = UserRoles.User,
                FirstName = "Екатерина",
                LastName = "Дёмина",
                Country = "Беларусь",
                City = "Минск",
                Address = "проспект Победителей, 15",
                PhoneNumber = "375296741282",
                PhoneNumberConfirmed = true
            };
            userManager.Create(simpleUser, "!13InsAdaska");
            var simpleUserRole = userManager.FindByEmail(simpleUser.Email);
            userManager.AddToRole(simpleUserRole.Id, UserRoles.User);

            context.SaveChanges();

            InitializeCustomer(context, simpleUser);
            InitializeAgreement(context);
            InitializeStore(context);
            InitializeProduct(context);
            InitializeAccount(context);

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

        private void InitializeAgreement(ReceivablesContext context)
        {
            context.Agreements.Add(new Agreement
            {
                CustomerId = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Name = "Договор №263",
                Number = 263,
                IsClosed = false,
                Postponement = 3
            });

            context.Agreements.Add(new Agreement
            {
                CustomerId = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Name = "Договор №74",
                Number = 74,
                IsClosed = false,
                Postponement = 0
            });

            context.Agreements.Add(new Agreement
            {
                CustomerId = 2,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Name = "Договор №1",
                Number = 1,
                IsClosed = false,
                Postponement = 0
            });

            context.Agreements.Add(new Agreement
            {
                CustomerId = 2,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Name = "Договор №56",
                Number = 56,
                IsClosed = false,
                Postponement = 0
            });

            context.SaveChanges();
        }

        private void InitializeStore(ReceivablesContext context)
        {
            context.Stores.Add(new Store
            {
                Name = "Реализация товаров №1 от " + DateTime.Now.ToString(),
                Number = 1,
                CurrencyCode = 933,
                AgreementId = 1
            });

            context.Stores.Add(new Store
            {
                Name = "Реализация товаров №1 от " + DateTime.Now.ToString(),
                Number = 1,
                CurrencyCode = 933,
                AgreementId = 2
            });

            context.Stores.Add(new Store
            {
                Name = "Реализация товаров №1 от " + DateTime.Now.ToString(),
                Number = 1,
                CurrencyCode = 933,
                AgreementId = 3
            });

            context.SaveChanges();
        }

        private void InitializeProduct(ReceivablesContext context)
        {
            context.Products.Add(new Product
            {
                Code = "Д243-91М",
                Name = "Двигатель МТЗ-80, МТЗ-82 81 л.с.,со стартером, с комплектом ЗИП, ТНВД MOTORPAL, БЕЛАРУСЬ"
                //StoreId = 1,
                //Number = 1,
                //Sum = 8154.66m
            });

            context.Products.Add(new Product
            {
                Code = "81FK0010RU",
                Name = "Lenovo IdeaPad 330-15ICH"
                //StoreId = 2,
                //Number = 1,
                //Sum = 1499.99m
            });

            context.Products.Add(new Product
            {
                Code = "MR7F2",
                Name = "Apple iPad 2018 32GB"
                //StoreId = 2,
                //Number = 2,
                //Sum = 1527.88m
            });

            context.Products.Add(new Product
            {
                Code = "C605XL",
                Name = "МФУ Xerox VersaLink"
                //StoreId = 3,
                //Number = 1,
                //Sum = 204435.06m
            });

            context.SaveChanges();
        }

        private void InitializeAccount(ReceivablesContext context)
        {
            context.Accounts.Add(new Account
            {
                Date = DateTime.Parse("02/09/2019"),
                Sum = 2000m
            });

            context.Accounts.Add(new Account
            {
                StoreId = 1,
                ProductId = 1,
                Number = 1,
                Date = DateTime.Parse("10/09/2019"),
                Sum = -8154.66m
            });

            context.Accounts.Add(new Account
            {
                Date = DateTime.Parse("16/09/2019"),
                Sum = 1500m
            });

            context.SaveChanges();
        }
    }
}