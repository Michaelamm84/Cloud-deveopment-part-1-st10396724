using atempt21.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace atempt21.Controllers
{
    public class TransactionController : Controller
    {

        private readonly ILogger<TransactionController> _logger;

        public TransactionController(ILogger<TransactionController> logger)
        {
            _logger = logger;
        }


        [HttpPost]
        public ActionResult PlaceOrder(int userID, int productID)
        {
            try
            {
                TransactionTable transaction = new TransactionTable
                {
                    ProductID = productID,
                    UserID = userID
                };

                transaction.insert_transaction(transaction);
                return RedirectToAction("Index", "Home"); 

                
            }
            catch (Exception ex)
            {
               
                return View("Error");
            }
        }
    }
}