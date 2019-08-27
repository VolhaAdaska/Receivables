using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Receivables.Dal.Models;

namespace Receivables.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }

        [Required]
        public string INN { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(256)]
        public string FullName { get; set; }


        public bool IsActive { get; set; }


        public bool IsBlocked { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(256)]
        public string Address { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public IEnumerable<ContractModel> Contracts { get; set; }
    }
}