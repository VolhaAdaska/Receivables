using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Receivables.Dal.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string PostCode { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}