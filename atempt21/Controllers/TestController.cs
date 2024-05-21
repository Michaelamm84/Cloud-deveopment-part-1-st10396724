using Microsoft.AspNetCore.Mvc;
using atempt21.Models;
namespace atempt21.Controllers
{
    public class TestController : Controller
    {

        [HttpPost]
        public IActionResult TestView()
        {

            return View();
        }
    }
}
