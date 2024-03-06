using FCommerce.DataAcsess.Repos.Interfaces;
using FCommerce.Models;

namespace FCommerce.DataAcsess.Repos.Implimentations
{
    public class CategoryRepo : Repositoy<Category>, ICategoryRepo
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepo(ApplicationDbContext context) : base(context)
        {
           _context = context;
        }
        ////public void Delete(int id)
        ////{
        ////    var categoryToBeeDeleted = _context.Categories.Find(id);
        ////    categoryToBeeDeleted.IsActive = false;
        //}

        

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
