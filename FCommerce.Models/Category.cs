using FCommerce.DataAcsess.Repos.Implimentations;
using System.ComponentModel.DataAnnotations;

namespace FCommerce.Models
{
    public class Category : BaseModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
    }
}
