namespace CS.Business.Shared.Dto.Product
{
    public class ProductDto : IEntityDto
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? CategoryID { get; set; }
        public int QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public bool Discontinued { get; set; }
    }
}
