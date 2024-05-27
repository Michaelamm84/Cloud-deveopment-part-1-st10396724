
using atempt21.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;


namespace atempt21.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public userTable usrtbl = new userTable();

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
            //int? userID = _httpContextAccessor.HttpContext.Session.GetInt32("UserID");
            int? userID = HttpContext.Session.GetInt32("UserID");

            // Pass products and userID to the view
            ViewData["Products"] = products;
            ViewData["UserID"] = userID;

            return View();
        }

        public IActionResult Privacy(userTable Users)
        {
            if ( HttpContext.Request.Method == "POST") {
                //string successMessage = TempData["SuccessMessage"] as string;
                //ViewBag.SuccessMessage = successMessage;
                if (usrtbl.CheckUser(Users.Email, Users.Password))
                {
                    // Login successful
                    // Add your login logic here
                    int UserID = usrtbl.GetUserID(Users.Email, Users.Password);

                    HttpContext.Session.SetInt32("UserID", UserID);

                    TempData["SuccessMessage"] = "Login successful!";
                    
                    return RedirectToAction("Index", "home");
                }
                else
                {
                    // Login failed
                    ModelState.AddModelError("", "Invalid login attempt.");
                    //return View(Users);
                    ViewBag.ErrorMessage = "Incorrect username or password";
                    return View();
                }
            }
            

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

       public IActionResult Orders()
        {
            int? userID = HttpContext.Session.GetInt32("UserID");

    if (userID.HasValue)
    {
        List<TransactionTable> transactions = TransactionTable.GetTransactionsByUser((int)userID.Value);
        return View(transactions);
    }
    else
    {
        // User is not logged in
        // Redirect to the login page or show an error message
        return RedirectToAction("Privacy");
    }
            return View();
        }   

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}