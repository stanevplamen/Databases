using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOfRows
{
    class RowsExtract
    {
        static void Main()
        {
            ConnectToSql();
        }

        private static void ConnectToSql()
        {
            SqlConnection dbCon = new SqlConnection("Server=USER-PC; " + "Database=Northwind; Integrated Security=true");
            dbCon.Open();

            using (dbCon)
            {
                SqlCommand cmdCount = new SqlCommand("SELECT COUNT(*) FROM Categories", dbCon);
                int categoriesCount = (int)cmdCount.ExecuteScalar();
                Console.WriteLine("Categories count: {0} ", categoriesCount);
            }
        }
    }
}