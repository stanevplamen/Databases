using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelWrite
{
    class Program
    {
        static void Main()
        {
            string path = @"scoretable.xlsx";
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0;";

            foreach (var player in players)
            {
                try
                {
                    ConnectExcel(connectionString, player);
                    Console.WriteLine("Row successfully written");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Operation NOT completed: {0}", ex.Message);
                }
            }
        }

        private static void ConnectExcel(string connectionString, KeyValuePair<string, string> player)
        {
            OleDbConnection excelConnection = new OleDbConnection(connectionString);
            excelConnection.Open();

            using (excelConnection)
            {
                OleDbCommand command = new OleDbCommand("INSERT INTO [List1$](Name, Score) VALUES(@Name, @Score)", excelConnection);
                command.Parameters.AddWithValue("@Name", player.Key);
                command.Parameters.AddWithValue("@Score", player.Value);

                command.ExecuteNonQuery();
            }
            return;
        }

        private static Dictionary<string, string> players = new Dictionary<string, string>() 
        { 
            {"Ivaylo Kenov", "20"},
            {"Vasil Dininski", "20"},
            {"Velko Nikolov", "20"},
        };
    }
}

