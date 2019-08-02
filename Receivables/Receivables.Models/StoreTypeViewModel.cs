using System.ComponentModel.DataAnnotations;

namespace Receivables.Models
{
    public class StoreTypeViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }
    }
}