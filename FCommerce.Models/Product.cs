using FCommerce.DataAcsess.Repos.Implimentations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCommerce.Models
{
    public class Product 
    {
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double ProductPrice { get; set; }
        [ValidateNever]
        public string? ImageUrl { get; set; }


        
        [Required]
        [ValidateNever]
        public Category Category { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

    }
}
