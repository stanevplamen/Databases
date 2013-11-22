using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProduct
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }
        public int? UnitsOnOrder { get; set; }
        public int? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        public Product(
                        int productId,
                        string productName,
                        string quantityPerUnit,
                        bool discontinued,
                        int? supplierID = null,
                        int? categoryID = null,
                        decimal? unitPrice = null,
                        int? unitsInStock = null,
                        int? unitsOnOrder = null,
                        int? reorderLevel = null
                        )
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.SupplierID = supplierID;
            this.CategoryID = categoryID;
            this.QuantityPerUnit = quantityPerUnit;
            this.UnitPrice = unitPrice;
            this.UnitsInStock = unitsInStock;
            this.UnitsOnOrder = unitsOnOrder;
            this.ReorderLevel = reorderLevel;
            this.Discontinued = discontinued;
        }
    }
}
