using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace FindAndStoreImages
{
    class DownloadOperations
    {
        private const string DB_CONNECTION_STRING = @"Server=USER-PC; Database=Northwind; Integrated Security=true";
        private const int fileOffset = 78;

        static void Main()
        {
            try
            {
                SqlConnection dbCon = new SqlConnection(DB_CONNECTION_STRING);
                dbCon.Open();

                ExtractImageFromDB(dbCon);
                Console.WriteLine("Images from the DB extracted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Operation NOT completed: {0}", ex.Message);
            }
        }

        private static void ExtractImageFromDB(SqlConnection dbCon)
        {
            using (dbCon)
            {
                SqlCommand command = new SqlCommand("SELECT cat.Picture, cat.CategoryName FROM Categories cat", dbCon);
                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        string categoryName = ((string)reader["CategoryName"]);
                        if (categoryName.Contains('/') == true)
                        {
                            categoryName = categoryName.Replace('/', ' ');
                        }
                        byte[] pictureBytes = reader["Picture"] as byte[];

                        MemoryStream stream = new MemoryStream(pictureBytes, fileOffset, pictureBytes.Length - fileOffset);

                        Image image = Image.FromStream(stream);
                        using (image)
                        {
                            image.Save("..\\..\\Images\\" + categoryName + ".jpg", ImageFormat.Jpeg);
                        }
                    }
                }
            }
        }
    }
}
