namespace Receivables.Bll.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public int StoreId { get; set; }

        public int Number { get; set; }

        public decimal Sum { get; set; }
    }
}
