using KailahsCloset.DataAccess.Services.Contracts;
using KailahsCloset.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KailahsCloset.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,
            IProductRepository productRepo)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //List<Product> products = _productRepo.GetAll().ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
