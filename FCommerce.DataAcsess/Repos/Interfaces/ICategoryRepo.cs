using FCommerce.Models;

namespace FCommerce.DataAcsess.Repos.Interfaces
{
    public interface ICategoryRepo : IRepositoy<Category>
    {
        //void Delete(int id);
        void Save();
    }
}
