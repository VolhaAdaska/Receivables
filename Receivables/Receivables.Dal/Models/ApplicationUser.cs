using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Receivables.Dal.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Customer> Customers { get; set; }
    }
}