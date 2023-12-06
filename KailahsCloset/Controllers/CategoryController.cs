using KailahsCloset.Data;
using KailahsCloset.Models;
using Microsoft.AspNetCore.Mvc;

namespace KailahsCloset.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;
        public CategoryController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var categoryList  = _db.Categories.ToList();
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
    }
}
