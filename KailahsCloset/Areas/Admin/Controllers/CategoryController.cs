using KailahsCloset.DataAccess.Data;
using KailahsCloset.DataAccess.Services.Contracts;
using KailahsCloset.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;

namespace KailahsCloset.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryController(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Category> categoryList = _categoryRepo.GetAll().ToList();
            return View(categoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category categoryObject)
        {
            if (ModelState.IsValid)
            {
                _categoryRepo.Add(categoryObject);
                _categoryRepo.Save();
                TempData["success"] = "Category Created Successfully";
                // If you want to redirect to an action method in another controller
                // add another parameter with the controller like below
                // return RedirectToAction("Index", "Category");
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var categoryObject = _categoryRepo.Get(c => c.CategoryId == id);

            if (categoryObject == null)
            {
                return NotFound();
            }
            return View(categoryObject);
        }

        [HttpPost]
        public IActionResult Edit(Category categoryObject)
        {
            if (ModelState.IsValid)
            {
                _categoryRepo.Update(categoryObject);
                _categoryRepo.Save();
                TempData["success"] = "Category Updated Successfully";
                // If you want to redirect to an action method in another controller
                // add another parameter with the controller like below
                // return RedirectToAction("Index", "Category");
                return RedirectToAction("Index");
            }
            return View();

        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var categoryObject = _categoryRepo.Get(c => c.CategoryId == id);

            if (categoryObject == null)
            {
                return NotFound();
            }
            return View(categoryObject);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            var categoryObject = _categoryRepo.Get(c => c.CategoryId == id);
            if (categoryObject == null)
            {
                return NotFound();
            }
            _categoryRepo.Delete(categoryObject);
            _categoryRepo.Save();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");

        }
    }
}