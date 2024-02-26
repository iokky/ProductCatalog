using ProductCatalog.Domain.Entity;
using ProductCatalog.Models;
using System.Data.Common;

namespace ProductCatalog.Dal.Repository
{
    public class UserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext context)
        {
            _appDbContext = context;
        }
        public User? GetUser(LoginModel model)
            => _appDbContext.product_catalog_users.FirstOrDefault(i =>
            i.Email == model.Email && i.Password == model.Password);

        public User? GetUserByEmail(string email)
            => _appDbContext.product_catalog_users.FirstOrDefault(i => i.Email == email);

        public void Create(User user)
        {
            _appDbContext.Add(user);
            try
            {
                _appDbContext.SaveChanges();
            }
            catch (DbException e)
            {
                _appDbContext.Remove(user);
                Console.WriteLine(e.Message);
            }
        }
    }
}
