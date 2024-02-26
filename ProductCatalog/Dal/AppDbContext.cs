using Microsoft.EntityFrameworkCore;
using ProductCatalog.Domain.Entity;

namespace ProductCatalog.Dal
{
    public class AppDbContext : DbContext
    {
        public DbSet<ProductCategory> product_category { get; set; }
        public DbSet<ProductGroup> product_group { get; set; }
        public DbSet<ProductPage> product_page { get; set; }

        public DbSet<User> product_catalog_users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) 
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ProductCategory>()
                .HasData(
                    new ProductCategory { Id = 1, Product = "ECOM"},
                    new ProductCategory { Id = 2, Product = "VPN" }
                );

            modelBuilder
                .Entity<ProductGroup>()
                .HasData(
                    new ProductGroup { Id = 1, ProductCategoryId = 1, Name = "Корзина" },
                    new ProductGroup { Id = 2, ProductCategoryId = 2, Name = "VPN" },
                    new ProductGroup { Id = 3, ProductCategoryId = 2, Name = "Разводная виртуальной инфраструктуры" }
                );

            modelBuilder
                .Entity<ProductPage>()
                .HasData(
                    new ProductPage { 
                        Id = 1, 
                        Url = "/shop/cart", 
                        Ecom = "yes", 
                        ContentType = "sale",
                        ProductGroupId = 1,
                    },
                    new ProductPage
                    {
                        Id = 2,
                        Url = "/products/gost-vpn_1",
                        Ecom = "yes",
                        ContentType = "sale",
                        ProductGroupId = 2,
                    },
                    new ProductPage
                    {
                        Id = 3,
                        Url = "/shop/products/kanal-svyazi-l2-vpn",
                        Ecom = "yes",
                        ContentType = "sale",
                        ProductGroupId = 2,
                    },
                    new ProductPage
                    {
                        Id = 4,
                        Url = "/services/setevaya-infrastruktura",
                        Ecom = "yes",
                        ContentType = "sale",
                        ProductGroupId = 3,
                    }
            );
            modelBuilder.Entity<User>()
                .HasData(
                    new User 
                    { 
                        Id = 1,
                        Email = "domeniqueflo@gmail.com",
                        Password = "12"
                    }
                );

        }

    }
}
