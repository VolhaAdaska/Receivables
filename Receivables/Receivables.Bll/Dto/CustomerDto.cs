using System.Collections.Generic;
using Receivables.Dal.Models;

namespace Receivables.Bll.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public string INN { get; set; }

        public string Name { get; set; }

        public string FullName { get; set; }

        public bool IsActive { get; set; }

        public string UserId { get; set; }

        public bool IsBlocked { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public virtual IEnumerable<Contract> Contracts { get; set; }
    }
}