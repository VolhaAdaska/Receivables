namespace Receivables.Dal.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public Store Store { get; set; }

        public int StoreId { get; set; }
    }
}
