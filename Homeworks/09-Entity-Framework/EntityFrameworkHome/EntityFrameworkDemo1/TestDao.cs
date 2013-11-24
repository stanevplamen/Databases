using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameModel;
using System.Data.Entity.Infrastructure;

namespace EntityFrameworkDemo00
{
    public class TestDao
    {
        static void Main()
        {
            Console.WriteLine("Program started.");
            PrintLastFiveProducts();

            int newProductId = Dao.CreateNewProduct("newProduct");
            Console.WriteLine("Created new product.");
            PrintLastFiveProducts();

            Dao.ModifyProductName(newProductId, "new name " + DateTime.Now.Ticks);
            Console.WriteLine("Modified the product {0}.", newProductId);
            PrintLastFiveProducts();

            Console.WriteLine("Deleted the product {0}.", newProductId);
            Dao.DeleteProduct(newProductId);
            PrintLastFiveProducts();
        }

        static void PrintLastFiveProducts()
        {
            NorthwindEntities northwindEntities = new NorthwindEntities();
            var lastFiveProducts =
                (from p in northwindEntities.Products
                 orderby p.ProductID descending
                 select p).Take(5);
            Console.WriteLine("Last 5 products:");
            foreach (var product in lastFiveProducts)
            {
                Console.WriteLine("{0}. {1}", product.ProductID, product.ProductName);
            }
            Console.WriteLine();
        }
    }
}
