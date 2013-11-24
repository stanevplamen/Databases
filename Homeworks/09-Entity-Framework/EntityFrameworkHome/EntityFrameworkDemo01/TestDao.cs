using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameModel;

namespace EntityFrameworkDemo01
{
    public class TestDao
    {
        static void Main()
        {
            Console.WriteLine("Program started.");
            PrintLastFiveCustomers();

            string newCustomerId = Dao.CreateNewCustomer("ZNC03", "Hamali AD", "Ivan Milionera");
            Console.WriteLine("Created new customer.");
            PrintLastFiveCustomers();

            Dao.ModifyCustomer(newCustomerId, "Moem Kurtim EOOD");
            Console.WriteLine("Modified the customer {0}.", newCustomerId);
            PrintLastFiveCustomers();

            Console.WriteLine("Delete the customer {0}.", newCustomerId);
            Dao.DeleteCustomer(newCustomerId);
            PrintLastFiveCustomers();
        }

        static void PrintLastFiveCustomers()
        {
            NorthwindEntities northwindEntities = new NorthwindEntities();
            var lastFiveCustomers =
                (from p in northwindEntities.Customers
                 orderby p.CustomerID descending
                 select p).Take(5);
            Console.WriteLine("Last 5 customers:");
            foreach (var customer in lastFiveCustomers)
            {
                Console.WriteLine("id:{0} | company: {1} | name: {2}", customer.CustomerID, customer.CompanyName, customer.ContactName);
            }
            Console.WriteLine();
        }
    }
}
