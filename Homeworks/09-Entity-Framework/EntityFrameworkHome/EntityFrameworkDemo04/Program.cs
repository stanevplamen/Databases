using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameModel;

namespace EntityFrameworkDemo04
{
    public class Program
    {
        static void Main()
        {
            DateTime startdate = new DateTime(1996, 12, 12);
            DateTime enddate = new DateTime(1997, 12, 12);
            string spregion = "RJ";
            FindAllSales(startdate, enddate, spregion);
        }

        private static void FindAllSales(DateTime startdate, DateTime enddate, string spregion)
        {
            NorthwindEntities northwindEntities = new NorthwindEntities();
            var sales = (from invoice in northwindEntities.Invoices
                         where invoice.Region == spregion &&
                         invoice.OrderDate > startdate &&
                         invoice.OrderDate < enddate
                         select new
                         {
                             OrderID = invoice.OrderID,
                             OrderDate = invoice.OrderDate,
                             ProductName = invoice.ProductName,
                             ExtendedPrice = invoice.ExtendedPrice
                         }
                             );

            Console.WriteLine("The orders in {0} region between {1:yyyy-MM-dd} and {2:yyyy-MM-dd} are:", 
                spregion, startdate, enddate);

            foreach (var item in sales)
            {
                Console.WriteLine("ID:{0,6} OrderDate: {1}\nProduct Name: {2}, Price: {3}\n",
                    item.OrderID, item.OrderDate, item.ProductName, item.ExtendedPrice);
            }
        }
    }
}
