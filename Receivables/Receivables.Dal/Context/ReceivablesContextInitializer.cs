using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Receivables.Dal.Models;
using System.Data.Entity;

namespace Receivables.Dal.Context
{
    public class ReceivablesContextInitializer : DropCreateDatabaseAlways<ReceivablesContext>
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

            Store storeBook = new Store
            {
                Name = "oz.by"
            };

            Store storeFood = new Store
            {
                Name = "e-dostavka"
            };

            context.Stores.Add(storeBook);
            context.Stores.Add(storeFood);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
