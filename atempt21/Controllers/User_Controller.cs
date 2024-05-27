using Microsoft.AspNetCore.Mvc;
using atempt21.Models;
namespace atempt21.Controllers
{
    public class UserController : Controller
    {
        public userTable usrtbl = new userTable();



        [HttpPost]
        public ActionResult About(userTable Users)
        {

            if (HttpContext.Request.Method == "POST")
            {
                if (ModelState.IsValid)
                {
                    int rowsAffected = usrtbl.insert_User(Users);
                    if (rowsAffected > 0)
                    {
                        TempData["SuccessMessage"] = "Sign up successful!";
                        return View();
                    }
                    else
                    {
                        
                        ViewBag.ErrorMessage = "Failed to sign up. Please try again.";
                    }
                }


            }
           

            return View(Users);
            
             
        }

        

        [HttpGet]
        public ActionResult About()
        {
            return View(usrtbl);
        }
        
       

    }
}