namespace Receivables.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public int Number { get; set; }

        public int StoreId { get; set; }

        public decimal Sum { get; set; }
    }
}