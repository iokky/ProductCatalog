namespace ProductCatalog.Domain.Entity
{
    public class ProductPage
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int ProductGroupId { get; set; }
        public ProductGroup ProductGroup { get; set; }
        public string Ecom { get; set; }
        public string ContentType { get; set; }
    }

}
