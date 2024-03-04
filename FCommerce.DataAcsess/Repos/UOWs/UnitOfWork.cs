using FCommerce.DataAcsess.Repos.Interfaces;

namespace FCommerce.DataAcsess.Repos.UOWs
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public ICategoryRepo CategoryRepo { get; private set; }

        public IProductRepo ProductRepo { get; private set; }

        public void Save()
        {
            _context.SaveChangesAsync();
        }
    }
}
