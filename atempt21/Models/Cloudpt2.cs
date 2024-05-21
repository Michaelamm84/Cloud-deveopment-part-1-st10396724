using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
namespace atempt21.Models
{
    public class Cloudpt2 : Controller
    {
        public static string con_string = "Server=tcp:st10396724.database.windows.net,1433;Initial Catalog=st1096724;Persist Security Info=False;User ID=MichaelAmm12;Password=Scott12!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;\r\n";
        public static SqlConnection con = new SqlConnection(con_string);    
        public IActionResult Index()
        {
            return View();
        }
    }
}
