using FCommerce.DataAcsess.Repos.Implimentations;
using Microsoft.AspNetCore.Mvc;

namespace FCommerce.Website.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductRepo _productRepo;
        public ProductsController(ProductRepo productRepo)
        {
            _productRepo = productRepo;
        }
        public IActionResult List()
        {
            var productInDb = _productRepo.GetAll().Where(p => p.IsActive==true);
            return View(productInDb);
        }
    }
}
