using FCommerce.DataAcsess;
using FCommerce.DataAcsess.Repos.Interfaces;
using FCommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace FCommerce.Website.Controllers
{
    public class CategorysController : Controller
    {
        private readonly ICategoryRepo _categoryRepo;
        public CategorysController(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public IActionResult List()
        {
           var categoryInDb = _categoryRepo.GetAll;
            return View(categoryInDb);
        }
    }
}
