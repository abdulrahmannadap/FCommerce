using FCommerce.DataAcsess.Repos.Implimentations;

namespace FCommerce.Models
{
    public class Product : BaseModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double ProductPrice { get; set; }

    }
}
