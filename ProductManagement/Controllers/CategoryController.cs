using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Entity;
using ProductManagement.Interface;
using ProductManagement.ViewModels;

namespace ProductManagement.Controllers
{
    public class CategoryController : Controller
    {
        
        private ICategoryRepo _categoryRepo;
        
        static string ResponseMessage = "";
        CategoryVM categoryViewModel = new CategoryVM();
        public CategoryController(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
            
        }
        [Authorize(Roles="Admin")]
        public IActionResult Index()
        {

            categoryViewModel.Categories = _categoryRepo.GetCategories();
            categoryViewModel.PageTitle = "Category Details";
            

            if (ResponseMessage.Length > 0)
            {
                ViewBag.Message = ResponseMessage;
                ResponseMessage = "";
            }
            else
            {
                ViewBag.Message = "";
            }
            return View(categoryViewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {

            CategoryVM categoryViewModel = new CategoryVM();

            categoryViewModel.PageTitle = "Create Category";

            return View(categoryViewModel);

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                ResponseMessage = _categoryRepo.CreateCategory(category);
                return RedirectToAction("Index");
            }
            categoryViewModel.Category = category;
            categoryViewModel.PageTitle = "Create Category";
            return View(categoryViewModel);

        }
        [HttpGet]
        public ActionResult Update(int Id)
        {
            
            CategoryVM categoryViewModel = new CategoryVM()
            {
                Category = _categoryRepo.GetCategory(Id),
                categoryOptions = _categoryRepo.GetCategoryOptions(Id),
                PageTitle = "Edit Category"
            };

           
            return View(categoryViewModel);

        }

        [HttpPost]
        public ActionResult Update(Category category)
        {            
            if (ModelState.IsValid)
            {
                ResponseMessage = _categoryRepo.UpdateCategory(category);
                return RedirectToAction("Index");
            }
            categoryViewModel.Category = category;
            categoryViewModel.PageTitle = "Edit Category";
            return View(categoryViewModel);

        }

        
        public ActionResult Delete(int CategoryId)
        {
            ResponseMessage = _categoryRepo.DeleteCategory(CategoryId);
            
            return RedirectToAction("Index");

        }

        
    }
}