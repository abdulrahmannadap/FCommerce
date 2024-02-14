using FCommerce.Models;

namespace FCommerce.DataAcsess.Repos.Interfaces
{
    public interface IProductRepo : IRepositoy<Product>
    {
        void Delete(int id);
        void Save();
    }
}
