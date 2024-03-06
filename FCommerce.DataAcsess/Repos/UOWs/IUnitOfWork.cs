using FCommerce.DataAcsess.Repos.Interfaces;

namespace FCommerce.DataAcsess.Repos.UOWs
{
    public interface IUnitOfWork
    {
        public ICategoryRepo CategoryRepo { get; }
        public IProductRepo ProductRepo { get; }
        void Save();
    }
}
