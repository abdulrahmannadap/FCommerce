using AspNetCoreHero.ToastNotification.Abstractions;
using FCommerce.DataAcsess.Repos.UOWs;
using FCommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace FCommerce.Website.Controllers
{
    public class CategorysController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotyfService _notyfService;
        public CategorysController(IUnitOfWork unitOfWork, INotyfService notyfService)
        {
            _unitOfWork = unitOfWork;
            _notyfService = notyfService;
        }
        public IActionResult List()
        {

            var categoryInDb = _unitOfWork.CategoryRepo.GetAll();
            return View(categoryInDb);
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                return View("UpsertForm");
            }
            var editDataInDb = _unitOfWork.CategoryRepo.Get(c => c.Id == id);

            return View("UpsertForm", editDataInDb);
        }
        [HttpPost]
        public IActionResult Upsert(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.Id == null || category.Id == 0)
                {
                    _unitOfWork.CategoryRepo.Add(category);
                    _unitOfWork.Save();
                    _notyfService.Success("You have successfully Add the data.");

                }
                else
                {
                    _unitOfWork.CategoryRepo.Edit(category);
                    _unitOfWork.Save();
                    _notyfService.Success("You have successfully Edit the data.");

                }

                return RedirectToAction("List", "Categorys");
            }
            return NotFound();
        }

        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                var DeleteIdInDb = _unitOfWork.CategoryRepo.Get(id);
                _unitOfWork.CategoryRepo.DeleteNormal(DeleteIdInDb);
                _unitOfWork.Save();
                _notyfService.Error("Category To Bee Deleted...");
            }
            return RedirectToAction("List");
        }

        //[HttpPost]
        //public IActionResult DeleteConferm(int id)
        //{ 
        //    _categoryRepo.Delete(id);
        //    TempData["Sucsess"] = "Category Deleted Sucsessfully";
        //    _categoryRepo.Save();
        //    return RedirectToAction("List","Categorys");
        //}

    }
}
