using FCommerce.DataAcsess.Repos.Interfaces;
using FCommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FCommerce.Website.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepo _productRepo;
        private readonly ICategoryRepo _categoryRepo;

        public ProductsController(IProductRepo productRepo,ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
            _productRepo = productRepo;
            
        }
        public IActionResult List()
        {
            var productInDb = _productRepo.GetAllPro().Where(p => p.IsActive == true);
            return View(productInDb);
        }
        public IActionResult Upsert(int? id)
        {
            var categoryList = _categoryRepo.GetAll().ToList();
           // var categorylistobj = _productRepo.GetCategories();

            ViewBag.CategoryItem = categoryList.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });

            if (id == null || id == 0)
            {

                return View("UpsertForm");
            }
            var editDataInDb = _productRepo.Get(c => c.Id == id);

            return View("UpsertForm", editDataInDb);
        }
        [HttpPost]
        public IActionResult Upsert(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.Id == null || product.Id == 0)
                {
                    _productRepo.Add(product);
                    _productRepo.Save();
                    TempData["Sucsess"] = "Product Add Sucsessfully";
                }
                else
                {
                    _productRepo.Edit(product);
                    _productRepo.Save();
                    TempData["Sucsess"] = "Product Edit Sucsessfully";

                }

                return RedirectToAction("List", "Products");
            }
          
            return NotFound();
        }

        public IActionResult Delete(int id)
        {
            if (id == null)
                return BadRequest();

            var categoryListss = _categoryRepo.Get(id);
            ViewBag.CategoryListData = categoryListss.Name;
            var DeleteIdInDb = _productRepo.Get(id);

            return View(DeleteIdInDb);
        }
        [HttpPost]
        public IActionResult DeleteConferm(int id)
        {
            if(id==null)
                return BadRequest();

            _productRepo.Delete(id);
            TempData["Sucsess"] = "Product Edit Sucsessfully";

            _productRepo.Save();
            return RedirectToAction("List", "Products");
        }
    }
}
