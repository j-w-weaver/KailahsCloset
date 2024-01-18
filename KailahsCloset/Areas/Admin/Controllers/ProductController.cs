using KailahsCloset.DataAccess.Services;
using KailahsCloset.DataAccess.Services.Contracts;
using KailahsCloset.Models.Models;
using KailahsCloset.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KailahsCloset.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Product> products = _productRepository.GetAll(includeProperties:"Category").ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            var productVM = new ProductVM()
            {
                CategoryList = _categoryRepository.GetAll()
                .Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.CategoryId.ToString()
                }),
                Product = new Product()
            };
            if (id == null || id == 0)
            {
                // create
                return View(productVM);
            }
            else
            {
                // update
                productVM.Product = _productRepository.Get(p => p.ProductId == id);
                return View(productVM);
            }
            
        }

        [HttpPost]
        public IActionResult Upsert(ProductVM productVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRoot = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRoot, @"images\product");
                    if (!string.IsNullOrEmpty(productVM.Product.ImageURL))
                    {
                        // delete old image
                        var oldImagePath = Path.Combine(wwwRoot, productVM.Product.ImageURL.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    
                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    productVM.Product.ImageURL = @"\images\product\" + fileName;
                }
                if (productVM.Product.ProductId == 0)
                {
                    _productRepository.Add(productVM.Product);
                }
                else
                {
                    _productRepository.Update(productVM.Product);
                }

                _productRepository.Save();
                TempData["success"] = "Product Created Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                productVM.CategoryList = _categoryRepository.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.CategoryId.ToString()
                });
            }
            return View();
        }

        //[HttpGet]
        //public IActionResult Edit(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    var productToUpdate = _productRepository.Get(p => p.ProductId == id);

        //    if (productToUpdate == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(productToUpdate);
        //}

        //[HttpPost]
        //public IActionResult Edit(Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _productRepository.Update(product);
        //        _productRepository.Save();
        //        TempData["success"] = "Product Updated Successfully";
        //        return RedirectToAction("Index");
        //    }

        //    //TempData["error"] = "Error Updating Product";
        //    return View();
        //}

        //[HttpGet]
        //public IActionResult Delete(int? id)
        //{
        //    if (id == 0 || id == null)
        //    {
        //        return NotFound();
        //    }
        //    var categoryObject = _productRepository.Get(c => c.ProductId == id);

        //    if (categoryObject == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(categoryObject);
        //}

        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeletePOST(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }

        //    var product = _productRepository.Get(p => p.ProductId == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    _productRepository.Delete(product);
        //    _productRepository.Save();
        //    TempData["success"] = "Category Deleted Successfully";
        //    return RedirectToAction("Index");
        //}


        #region DATATABLE API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> productList = _productRepository.GetAll(includeProperties: "Category").ToList();
            return Json(new { data = productList });
        }

        public IActionResult Delete(int? id)
        {
            var productToBeDeleted = _productRepository.Get(p => p.ProductId == id);
            if (productToBeDeleted == null)
            {
                return Json( new{ success = false, message = "Error while deleting" });
            }

            // delete old image
            var oldImagePath =
                Path.Combine(_webHostEnvironment.WebRootPath,
                productToBeDeleted.ImageURL.TrimStart('\\'));

            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _productRepository.Delete(productToBeDeleted);
            _productRepository.Save();

            return Json(new { success = true, message = "Your product has been deleted." });
        }

        #endregion
    }
}
