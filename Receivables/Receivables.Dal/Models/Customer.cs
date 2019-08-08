namespace Receivables.Dal.Models
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }

        public string FullName { get; set; }

        public string INN { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public bool IsBlocked { get; set; }
    }
}
