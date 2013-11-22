using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatchInDBNS
{
    class SeatchInDB
    {
        public static void Main()
        {
            Console.Write("Please enter your search string: ");
            string input = Console.ReadLine();
            // Define connection properties.
            SqlConnection dbCon = new SqlConnection("Server=localhost; " + "Database=Northwind; " + "Integrated Security=true");
            dbCon.Open();

            // Read and print all categories.
            using (dbCon)
            {
                // Sanitize input
                input = input.Replace("%", "[%]");
                input = input.Replace("_", "[_]");
                input = input.Replace("\\", "[\\]");
                input = input.Replace("[", "[[");
                input = input.Replace("]", "]] ");

                SqlCommand comFindProd = new SqlCommand("SELECT prod.ProductName FROM Products prod WHERE prod.ProductName LIKE '%" + @input + "%' ", dbCon);
                comFindProd.Parameters.AddWithValue("@input", input);

                SqlDataReader reader = comFindProd.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Find product: " + (string)reader["ProductName"]);
                    }
                }
            }
        }
    }
}
