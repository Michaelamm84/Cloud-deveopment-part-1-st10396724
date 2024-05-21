using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace atempt21.Models;

public class productTable
{
    //public static string con_string = "Server=tcp:clouddev-sql-server.database.windows.net,1433;Initial Catalog=CLDVDatabase;Persist Security Info=False;User ID=Byron;Password=RockeyM12345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
    public static string con_string = "Server=tcp:st10396724.database.windows.net,1433;Initial Catalog=st1096724;Persist Security Info=False;User ID=MichaelAmm12;Password=Scott12!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;\r\n";

    public static SqlConnection con = new SqlConnection(con_string);


    public int ProductID { get; set; }

    public string Name { get; set; }

    public string Price { get; set; }

    public string Category { get; set; }

    public string Availability { get; set; }



    public int insert_product(productTable p)
    {

        try
        {
            string sql = "INSERT INTO ProductTable (Name, Price, Category, Availability) VALUES (@Name, @Price, @Category, @Availability)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Name", p.Name);
            cmd.Parameters.AddWithValue("@Price", p.Price);
            cmd.Parameters.AddWithValue("@Category", p.Category);
            cmd.Parameters.AddWithValue("@Availability", p.Availability);
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


    // Method to retrieve all products from the database
    public static List<productTable> GetAllProducts()
    {
        List<productTable> products = new List<productTable>();

        using (SqlConnection con = new SqlConnection(con_string))
        {
            string sql = "SELECT * FROM productTable";
            SqlCommand cmd = new SqlCommand(sql, con);

            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                productTable product = new productTable();
                product.ProductID = Convert.ToInt32(rdr["Product_id"]);
                product.Name = rdr["Name"].ToString();
                product.Price = rdr["Price"].ToString();
                product.Category = rdr["Category"].ToString();
                product.Availability = rdr["Availability"].ToString();

                products.Add(product);
            }
        }

        return products;
    }

}