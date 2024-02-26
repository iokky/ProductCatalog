namespace ProductCatalog.Domain.Entity
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public List<ProductGroup> ProductGroup { get; set; } = new ();
    }
}
