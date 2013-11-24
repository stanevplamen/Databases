using EntityFrameModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameModel;

namespace EntityFrameworkDemo00
{
    public static class Dao
    {
        public static int CreateNewProduct(string productName)
        {
            NorthwindEntities northwindEntities = new NorthwindEntities();
            Product newProduct = new Product
            {
                ProductName = productName,
                Discontinued = false
            };
            northwindEntities.Products.Add(newProduct);
            northwindEntities.SaveChanges();
            return newProduct.ProductID;
        }

        public static void ModifyProductName(int productId, string newName)
        {
            NorthwindEntities northwindEntities = new NorthwindEntities();
            Product product = GetProductById(northwindEntities, productId);
            product.ProductName = newName;
            northwindEntities.SaveChanges();
        }

        public static void DeleteProduct(int productId)
        {
            NorthwindEntities northwindEntities = new NorthwindEntities();
            Product product = GetProductById(northwindEntities, productId);
            northwindEntities.Products.Remove(product);
            northwindEntities.SaveChanges();
        }

        public static Product GetProductById(NorthwindEntities northwindEntities, int productId)
        {
            Product product = northwindEntities.Products.FirstOrDefault(
                p => p.ProductID == productId);
            return product;
        }
    }
}
