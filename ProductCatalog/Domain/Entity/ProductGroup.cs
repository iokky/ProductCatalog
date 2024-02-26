namespace ProductCatalog.Domain.Entity
{
    public class ProductGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public List<ProductPage> ProductPages { get; set; } = new();
    }
}
