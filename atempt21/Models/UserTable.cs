using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using System.Collections.Generic;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Xml.Linq;

namespace atempt21.Models
{
    public class userTable
    {


        //public static string con_string = "Server=tcp:clouddev-sql-server.database.windows.net,1433;Initial Catalog=CLDVDatabase;Persist Security Info=False;User ID=Byron;Password=RockeyM12345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static string con_string = "Server=tcp:st10396724.database.windows.net,1433;Initial Catalog=st1096724;Persist Security Info=False;User ID=MichaelAmm12;Password=Scott12!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;\r\n";

        public static SqlConnection con = new SqlConnection(con_string);



        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }





        public int insert_User(userTable m)
        {

            try
            {
                string sql = "INSERT INTO userTable (Name, Surname, Password, Email) VALUES (@Name, @Surname, @Password, @Email )";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", m.Name);
                cmd.Parameters.AddWithValue("@Surname", m.Surname);
                cmd.Parameters.AddWithValue("@Password", m.Password);
                cmd.Parameters.AddWithValue("@Email", m.Email);
                
                
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                // For now, rethrow the exception
                throw ex;
            }


        }

        
    }
}