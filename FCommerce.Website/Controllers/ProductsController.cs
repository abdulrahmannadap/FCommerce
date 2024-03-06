﻿using AspNetCoreHero.ToastNotification.Abstractions;
using FCommerce.DataAcsess.Repos.UOWs;
using FCommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FCommerce.Website.Controllers
{
    public class ProductsController : Controller
    {
        #region Dependanceis
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotyfService _notyfService;
        private readonly IWebHostEnvironment _webHostEnvironment;
       
        #endregion

        #region Product Custructor
        public ProductsController(IUnitOfWork unitOfWork, INotyfService notyfService, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _notyfService = notyfService;
            _webHostEnvironment = webHostEnvironment;
        }
        #endregion

        #region Product List 
        public IActionResult List()
        {
            var productInDb = _unitOfWork.ProductRepo.GetAllPro();
            return View(productInDb);
        }
        #endregion

        #region Product Upsert Get
        public IActionResult Upsert(int? id)
        {
            var categoryList = _unitOfWork.CategoryRepo.GetAll().ToList();
            // var categorylistobj = _productRepo.GetCategories();

            ViewBag.CategoryItem = categoryList.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });

            if (id == null || id == 0)
            {

                return View("UpsertForm", new Product());
            }
            var editDataInDb = _unitOfWork.ProductRepo.Get(c => c.Id == id);

            return View("UpsertForm", editDataInDb);
        }
        #endregion

        #region Product Upsert Post
        [HttpPost]
        public IActionResult Upsert(Product product,IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                if(file != null)
                {
                    //string fileExtensionName = Path.GetExtension(file.FileName);
                    string newFileName = "Image"+Guid.NewGuid().ToString().Substring(0,5)+Path.GetExtension(file.FileName);
                    string webRootpath = _webHostEnvironment.WebRootPath;
                    //string finalDestination = webRootpath + @"\images\products";
                    string finalDestination = Path.Combine(webRootpath,@"images\products");
                   //Using Block Background Call Dispos Method
                    using (FileStream fileStream = new FileStream(Path.Combine(finalDestination,newFileName),FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    //Reletive path
                    product.ImageUrl = @"\images\products" + newFileName;
                }







                if (product.Id == null || product.Id == 0)
                {
                    _unitOfWork.ProductRepo.Add(product);
                    _unitOfWork.Save();
                    _notyfService.Success("You have successfully Add the data.");
                }
                else
                {
                    _unitOfWork.ProductRepo.Edit(product);
                    _unitOfWork.Save();
                    _notyfService.Success("You have successfully Edit the data.");

                }

                return RedirectToAction("List", "Products");
            }

            return NotFound();
        }
        #endregion

        #region Product Delete Post/Get
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                var deleteIdInDbs = _unitOfWork.ProductRepo.Get(id);
                _unitOfWork.ProductRepo.DeleteNormal(deleteIdInDbs);
                _unitOfWork.Save();
                _notyfService.Error("Product To Bee Deleted...");
            }
            return RedirectToAction("List");
        }
        //[HttpPost]
        //public IActionResult DeleteConferm(int id)
        //{
        //    if(id==null)
        //        return BadRequest();

        //    _productRepo.DeleteNormal(id);
        //    TempData["Sucsess"] = "Product Edit Sucsessfully";

        //    _productRepo.Save();
        //    return RedirectToAction("List", "Products");
        //}
        #endregion
    }
}
