 using System.Collections.Generic;

 namespace Receivables.Dal.Models
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }

        public string FullName { get; set; }

        public string INN { get; set; }

        public bool IsActive { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public bool IsBlocked { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Agreement> Agreements { get; set; }
    }
}
