using KailahsCloset.Data;
using KailahsCloset.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace KailahsCloset.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;
        public CategoryController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var categoryList = _db.Categories.ToList();
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
                _db.Categories.Add(categoryObject);
                _db.SaveChanges();
                // If you want to redirect to an action method in another controller
                // add another parameter with the controller like below
                // return RedirectToAction("Index", "Category");
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var categoryObject = _db.Categories.Find(id);

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
                _db.Categories.Update(categoryObject);
                _db.SaveChanges();
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
            var categoryObject = _db.Categories.Find(id);

            if (categoryObject == null)
            {
                return NotFound();
            }
            return View(categoryObject);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            var categoryObject = _db.Categories.Find(id);
            if (categoryObject == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(categoryObject);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}