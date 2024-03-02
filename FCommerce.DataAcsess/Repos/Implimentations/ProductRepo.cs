using FCommerce.DataAcsess.Repos.Interfaces;
using FCommerce.Models;

namespace FCommerce.DataAcsess.Repos.Implimentations
{
    public class ProductRepo : Repositoy<Product>,IProductRepo
    {
        private readonly ApplicationDbContext _context;

        public ProductRepo(ApplicationDbContext context): base(context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var productInDb = _context.Products.Find(id);
            productInDb.IsActive = false;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
