using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectProducts
{
    class RetrieveInfo
    {
        static void Main()
        {          
            ConnectToSql();
        }

        private static void ConnectToSql()
        {
            SqlConnection dbCon = new SqlConnection("Server=USER-PC; " + "Database=Northwind; Integrated Security=true");
            dbCon.Open();

            Console.WriteLine("Name and description of all products and categories:");
            SqlCommand cmdAllProducts = new SqlCommand("SELECT c.CategoryName, p.ProductName FROM Categories c JOIN Products p ON p.CategoryID = c.CategoryID", dbCon);
            SqlDataReader reader = cmdAllProducts.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string catName = (string)reader["CategoryName"];
                    string proName = (string)reader["ProductName"];
                    Console.WriteLine("Product: {0} | Category: {1}",proName.PadLeft(35), catName);
                }
            }
        }
    }
}
