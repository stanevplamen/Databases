using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelRead
{
    class Program
    {
        static void Main()
        {
            string path = @"scoretable.xlsx";
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0;";
            try
            {
                ConnectExcel(connectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Operation NOT completed: {0}", ex.Message);
            }
            
        }

        private static void ConnectExcel(string connectionString)
        {
            OleDbConnection excelConnection = new OleDbConnection(connectionString);
            excelConnection.Open();

            using (excelConnection)
            {
                OleDbCommand command = new OleDbCommand(@"SELECT * FROM [List1$]", excelConnection);
                OleDbDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    Console.WriteLine("All players:");
                    Console.WriteLine();
                    while (reader.Read())
                    {
                        string name = (string)reader["Name"];
                        double score = (double)reader["Score"];

                        Console.WriteLine("Name: {0} | Score: {1}", name.PadRight(15), score);
                    }
                }
            }
            return;
        }
    }
}
