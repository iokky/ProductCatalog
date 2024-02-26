using Microsoft.EntityFrameworkCore;
using ProductCatalog.Domain.Entity;
using System.Data.Common;

namespace ProductCatalog.Dal.Repository
{
    public class ProductPageRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductPageRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<ProductCategory> GetAllCategory() => _appDbContext
            .product_category
            .Include(i => i.ProductGroup)
                .ThenInclude(c => c.ProductPages)
            .ToList();

        public void CreateProductCategory(ProductCategory category)
        {
            _appDbContext.Add(category);
            try
            {
                _appDbContext.SaveChanges();
            }
            catch (DbException e)
            {
                _appDbContext.Remove(category);
                Console.WriteLine(e.Message);
            }
        }
        public List<ProductGroup> GetProductGroup() => _appDbContext
            .product_group
            .Include(i => i.ProductPages)
            .ToList();

        public void CreateProductGroup(ProductGroup group)
        {
            _appDbContext.Add(group);
            try
            {
                _appDbContext.SaveChanges();
            }
            catch (DbException e)
            {
                _appDbContext.Remove(group);
                Console.WriteLine(e.Message);
            }
        }

        public List<ProductPage> GetAllPages() => _appDbContext
            .product_page
            .Include(i => i.ProductGroup)
            .ToList();

        public ProductPage? GetPageById(int id) => _appDbContext.product_page.FirstOrDefault(i => i.Id == id);

        public void EditProductPage(ProductPage page)
        {
            var productPage = _appDbContext.product_page.FirstOrDefault(p => p.Id == page.Id);
            if (productPage != null)
            {
                try
                {
                    productPage.ProductGroupId = page.ProductGroupId;
                    productPage.Url = page.Url;
                    productPage.Ecom = page.Ecom;
                    productPage.ContentType = page.ContentType;
                    
                    _appDbContext.SaveChanges();
                }
                catch (DbException e)
                {
                    _appDbContext.Remove(productPage);
                    Console.WriteLine(e.Message);
                }
            }

        }
        public void DeletePage(ProductPage page) 
        {
            _appDbContext.product_page.Remove(page);
            _appDbContext.SaveChanges();
        } 

        public ProductCategory? GetCategoryById(int id) => _appDbContext
            .product_category
            .Where(i => i.Id == id)
            .Include(i => i.ProductGroup)
                .ThenInclude(c => c.ProductPages)
            .FirstOrDefault();

        public void CreateProductPage(ProductPage page)
        {
            _appDbContext.product_page.Add(page);
            try
            {
                _appDbContext.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                _appDbContext.Remove(page);
                Console.WriteLine(e.Message);
            }
        }
    }
}
