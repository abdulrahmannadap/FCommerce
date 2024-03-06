using FCommerce.DataAcsess.Repos.Implimentations;
using System.ComponentModel.DataAnnotations;

namespace FCommerce.Models
{
    public class Category 
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
