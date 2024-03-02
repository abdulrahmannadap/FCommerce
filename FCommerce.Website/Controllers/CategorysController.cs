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
            var categoryInDb = _categoryRepo.GetAll().Where(c => c.IsActive==true);
            return View(categoryInDb);
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            { 
            return View("UpsertForm");
            }
            var editDataInDb = _categoryRepo.Get(c => c.Id==id);
            
            return View("UpsertForm",editDataInDb);
        }
        [HttpPost]
        public IActionResult Upsert(Category category)
        {
            if(ModelState.IsValid)
            {
                if(category.Id == null || category.Id == 0)
                {
                    _categoryRepo.Add(category);
                    TempData["Sucsess"] = "Category Add Sucsessfully";
                    _categoryRepo.Save();
                }
                else
                {
                    _categoryRepo.Edit(category);
                    TempData["Sucsess"] = "Category Edit Sucsessfully";
                    _categoryRepo.Save();
                }
              
                return RedirectToAction("List", "Categorys");
            }
            return BadRequest("Fir Se Galat Code Bhai To Chod De Coding ");
        }

        public IActionResult Delete(int id)
        {
            var DeleteIdInDb = _categoryRepo.Get(id);

            return View(DeleteIdInDb);
        }
        [HttpPost]
        public IActionResult DeleteConferm(int id)
        { 
            _categoryRepo.Delete(id);
            TempData["Sucsess"] = "Category Deleted Sucsessfully";
            _categoryRepo.Save();
            return RedirectToAction("List","Categorys");
        }

    }
}
