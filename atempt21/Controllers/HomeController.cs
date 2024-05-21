
using atempt21.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;


namespace atempt21.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAcccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAcccessor;
        }

        public IActionResult Index()
        {
            // Retrieve all products from the database
            List<productTable> products = productTable.GetAllProducts();

            //Retrieve user ID from session
            int? userID = _httpContextAccessor.HttpContext.Session.GetInt32("UserID");

            // Pass products and userID to the view
            ViewData["Products"] = products;
            ViewData["UserID"] = userID;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult MyWork()
        {
            return View();
        }

        public IActionResult TestView()
        {

            return View();
        }

        public IActionResult TestAgain()
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