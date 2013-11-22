using _04_NewProduct;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProduct
{
    class AddProduct
    {
        private static SqlConnection dbCon;

        static void Main()
        {
            try
            {
                ConnectToSql();
                Product yellowCheese = new Product(99, "Yellow Cheese", "1/kg", false, null, null, 34.23m, null, null, null);
                AddNewProduct(yellowCheese);
                Console.WriteLine("Operation completed, check the database");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Operation NOT completed: {0}", ex.Message);
            }
            finally
            {
                DisconnectFromDB();
            }

        }

        private static void ConnectToSql()
        {
            dbCon = new SqlConnection(ConString.Default.DBConnectionString);
            dbCon.Open();      
        }

        private static void AddNewProduct(Product passedProduct)
        {
            string queryString = "INSERT " +
                            "INTO Products(ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued)" +
                            " VALUES(" +
                            "@ProductName," +
                            "@SupplierID," +
                            "@CategoryID," +
                            "@QuantityPerUnit," +
                            "@UnitPrice," +
                            "@UnitsInStock," +
                            "@UnitsOnOrder," +
                            "@ReorderLevel," +
                            "@Discontinued)";


            SqlCommand cmd = new SqlCommand(queryString, dbCon);

            // using (dbCon) -> not needed in this case

            // Add Parameters
            cmd.Parameters.AddWithValue("@ProductName", passedProduct.ProductName);
            cmd.Parameters.AddWithValue("@QuantityPerUnit", passedProduct.QuantityPerUnit);
            cmd.Parameters.AddWithValue("@Discontinued", passedProduct.Discontinued == true ? 1 : 0);

            // Nullable params
            SqlParameter sqlParameterSupplierID = new SqlParameter("@SupplierID", passedProduct.SupplierID);
            if (passedProduct.SupplierID == null) sqlParameterSupplierID.Value = DBNull.Value;
            cmd.Parameters.Add(sqlParameterSupplierID);

            SqlParameter sqlParameterCategoryID = new SqlParameter("@CategoryID", passedProduct.CategoryID);
            if (passedProduct.CategoryID == null) sqlParameterCategoryID.Value = DBNull.Value;
            cmd.Parameters.Add(sqlParameterCategoryID);

            SqlParameter sqlParameterUnitPrice = new SqlParameter("@UnitPrice", passedProduct.UnitPrice);
            if (passedProduct.UnitPrice == null) sqlParameterUnitPrice.Value = DBNull.Value;
            cmd.Parameters.Add(sqlParameterUnitPrice);

            SqlParameter sqlParameterUnitsInStock = new SqlParameter("@UnitsInStock", passedProduct.UnitsInStock);
            if (passedProduct.UnitsInStock == null) sqlParameterUnitsInStock.Value = DBNull.Value;
            cmd.Parameters.Add(sqlParameterUnitsInStock);

            SqlParameter sqlParameterUnitsOnOrder = new SqlParameter("@UnitsOnOrder", passedProduct.UnitsOnOrder);
            if (passedProduct.UnitsOnOrder == null) sqlParameterUnitsOnOrder.Value = DBNull.Value;
            cmd.Parameters.Add(sqlParameterUnitsOnOrder);

            SqlParameter sqlParameterReorderLevel = new SqlParameter("@ReorderLevel", passedProduct.ReorderLevel);
            if (passedProduct.ReorderLevel == null) sqlParameterReorderLevel.Value = DBNull.Value;
            cmd.Parameters.Add(sqlParameterReorderLevel);

            cmd.ExecuteNonQuery();

            return;
        }

        private static void DisconnectFromDB()
        {
            if (dbCon != null)
            {
                dbCon.Close();
            }
        }
    }
}
