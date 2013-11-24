using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameModel;

namespace EntityFrameworkDemo02
{
    class Program
    {
        static void Main()
        {
            Find1997CanadaCustomers();
        }

        private static void Find1997CanadaCustomers()
        {
            NorthwindEntities northwindEntities = new NorthwindEntities();
            var customers = (from cus in northwindEntities.Customers
                             join ord in northwindEntities.Orders
                             on cus.CustomerID equals ord.CustomerID
                             where ord.OrderDate.Value.Year == 1997 &&
                             ord.ShipCountry == "Canada"
                             select new
                             {
                                 CustomerID = cus.CustomerID,
                                 ContactName = cus.ContactName,
                                 OrderID = ord.OrderID,
                                 OrderDate = ord.OrderDate
                             }
                            ).Distinct();

            Console.WriteLine("Customers who have orders made in 1997 and shipped to Canada:");
            foreach (var item in customers)
            {
                Console.WriteLine("{0} {1} - order ID:{2}, order Date: {3}",
                    item.CustomerID, item.ContactName, item.OrderID, item.OrderDate.Value.ToShortDateString());
            }
        }
    }
}

