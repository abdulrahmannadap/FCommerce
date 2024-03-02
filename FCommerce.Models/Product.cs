using FCommerce.DataAcsess.Repos.Implimentations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCommerce.Models
{
    public class Product : BaseModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Product Name Is Required")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Product Description Is  Required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Product Price Is Required")]
        public double ProductPrice { get; set; }
       

        [ValidateNever]
        [Required(ErrorMessage = "Please Select category")]
        public Category Category { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

    }
}
