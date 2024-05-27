using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
namespace atempt21.Models
{
    public class TransactionTable
    {
        public static string con_string = "Server=tcp:st10396724.database.windows.net,1433;Initial Catalog=st1096724;Persist Security Info=False;User ID=MichaelAmm12;Password=Scott12!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;\r\n";
        public static SqlConnection con = new SqlConnection(con_string);

        public Decimal TransactionID { get ; set; }
        public int ProductID { get; set; }
        public int UserID { get; set; }
       
        public int insert_transaction(TransactionTable t)
        {
            try
            {
                string sql = "INSERT INTO TransactionTable (ProductID, UserID) VALUES (@ProductID, @UserID)";
                SqlCommand cmd = new SqlCommand(sql, con);
                
                cmd.Parameters.AddWithValue("@ProductID", t.ProductID);
                cmd.Parameters.AddWithValue("@UserID", t.UserID);
                 
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

        public static List<TransactionTable> GetTransactionsByUser(int userID)
        {
            List<TransactionTable> transactions = new List<TransactionTable>();

            try
            {
                string sql = "SELECT * FROM TransactionTable WHERE UserID = @UserID";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@UserID", userID);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TransactionTable transaction = new TransactionTable
                    {
                        TransactionID = reader.GetDecimal(0),
                        ProductID = (int)reader.GetDecimal(1),
                        UserID = (int)reader.GetDecimal(2)
                    };

                    transactions.Add(transaction);
                }

                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
               
                throw ex;
            }

            return transactions;
        }
    }   
    
}
