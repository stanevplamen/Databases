using EntityFrameModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo06
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Starting the first command!");
            using (var northwindDbContext = new NorthwindEntities())
            {
                using (var secondNorthwindDbContext = new NorthwindEntities())
                {
                    var order = northwindDbContext.Orders.Find(10248);
                    var sameOrder = secondNorthwindDbContext.Orders.Find(10248);

                    // Mark for delete
                    northwindDbContext.Orders.Remove(order);

                    // Update some stuff
                    sameOrder.ShipCountry = "Bulgaria";

                    // Make update
                    try
                    {
                        secondNorthwindDbContext.SaveChanges();
                        Console.WriteLine("Updating complete!");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Updating failed!");
                    }


                    // Delete -> Produces an exception because of data integrity.
                    try
                    {
                        northwindDbContext.SaveChanges();
                        Console.WriteLine("Deleting complete!");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Delete cannot be executed!");
                    }

                }
            }

            Console.WriteLine("First Operation Finished!");
            Console.WriteLine("Starting the second command!");

            using (NorthwindEntities northwindEntities1 = new NorthwindEntities())
            {
                using (NorthwindEntities northwindEntities2 = new NorthwindEntities())
                {
                    Customer customerByFirstDataContext = northwindEntities1.Customers.Find("CHOPS");
                    customerByFirstDataContext.Region = "SW";

                    Customer customerBySecondDataContext = northwindEntities2.Customers.Find("CHOPS");
                    customerBySecondDataContext.Region = "SSWW";

                    northwindEntities1.SaveChanges();
                    northwindEntities2.SaveChanges();
                }
            }

            Console.WriteLine("Changes successfully made!");
        }
    }
}
