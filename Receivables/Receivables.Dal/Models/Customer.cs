using System.Security.AccessControl;

namespace Receivables.Dal.Models
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }

        public string FullName { get; set; }

        public string INN { get; set; }
    }
}
