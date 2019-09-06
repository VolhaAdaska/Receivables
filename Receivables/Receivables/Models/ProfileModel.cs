using System.Collections.Generic;
using Microsoft.AspNet.Identity;

namespace Receivables.Models
{
    public class ProfileModel
    {
        public bool HasPassword { get; set; }

        public IList<UserLoginInfo> Logins { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public bool TwoFactor { get; set; }

        public bool BrowserRemembered { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public string City { get; set; }

        public string Country { get; set; }

        public string Email { get; set; }

        public string PostCode { get; set; }
    }
}