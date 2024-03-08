using AspNetCoreHero.ToastNotification.Abstractions;
using FCommerce.DataAcsess.Repos.UOWs;
using FCommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace FCommerce.Website.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategorysController : Controller
    {
        #region Dependanceis
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotyfService _notyfService;
        #endregion

        #region Category Constructor
        public CategorysController(IUnitOfWork unitOfWork, INotyfService notyfService)
        {
            _unitOfWork = unitOfWork;
            _notyfService = notyfService;
        }
        #endregion

        #region Category List Method
        public IActionResult List()
        {
            var categoryInDb = _unitOfWork.CategoryRepo.GetAll();
            return View(categoryInDb);
        }
        #endregion

        #region Category Upsert Get Method
        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                return View("UpsertForm", new Category());
            }
            var editDataInDb = _unitOfWork.CategoryRepo.Get(c => c.Id == id,"");

            return View("UpsertForm", editDataInDb);
        }
        #endregion

        #region Category Upsert post Method
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
        #endregion

        #region Category Delete Method

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
        #endregion

    }
}
