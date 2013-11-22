using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetrieveName
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

            Console.WriteLine("Name and description of all categories:");
            SqlCommand cmdAllCategories = new SqlCommand("SELECT c.CategoryName, c.Description FROM Categories c", dbCon);
            SqlDataReader reader = cmdAllCategories.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string catName = (string)reader["CategoryName"];
                    string catDesc = (string)reader["Description"];
                    Console.WriteLine("Category: {0} - {1}", catName.PadLeft(15), catDesc);
                }
            }
        }
    }
}
