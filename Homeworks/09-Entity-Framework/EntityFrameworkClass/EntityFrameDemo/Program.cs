using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameModel;
using System.Data.Entity.Infrastructure;

namespace EntityFrameDemo
{
    class Program
    {
        static void Main()
        {
            using (var db = new NorthwindEntities())
            {
                foreach (var customer in db.Customers.Where(x => x.Country == "UK"))
                {
                    Console.WriteLine(customer.ContactName);
                }
            }
        }
    }
}
