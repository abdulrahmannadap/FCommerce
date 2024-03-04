using FCommerce.DataAcsess.Repos.Interfaces;
using FCommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace FCommerce.DataAcsess.Repos.Implimentations
{
    public class ProductRepo : Repositoy<Product>, IProductRepo
    {
        private readonly ApplicationDbContext _context;

        public ProductRepo(ApplicationDbContext context): base(context)
        {
            _context = context;
        }

        //public void Delete(int id)
        //{
        //    var productInDb = _context.Products.Find(id);
        //    productInDb.IsActive = false;
        //}

        public void Save()
        {
            _context.SaveChanges();
        }
        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public IEnumerable<Product> GetAllPro()
        {
            return _context.Products.Include(c => c.Category).ToList();
        }
    }
}
