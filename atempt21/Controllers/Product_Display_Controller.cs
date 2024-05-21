using Microsoft.AspNetCore.Mvc;
using atempt21.Models;

namespace CloudDevelopment.Controllers
{
    public class ProductDisplayController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var products = ProductDisplayModel.SelectProducts();
            return View(products);
        }
    }
}