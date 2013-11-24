using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameModel;

namespace EntityFrameworkDemo01
{
    public static class Dao
    {
        public static string CreateNewCustomer(string customerID, string companyName, string contactName)
        {
            NorthwindEntities northwindEntities = new NorthwindEntities();
            Customer newCustomer = new Customer 
            {
                CustomerID = customerID,
                CompanyName = companyName,
                ContactName = contactName,
            };
            northwindEntities.Customers.Add(newCustomer);
            northwindEntities.SaveChanges();
            return newCustomer.CustomerID;
        }

        public static void ModifyCustomer(string customerId, string newCompany)
        {
            NorthwindEntities northwindEntities = new NorthwindEntities();
            Customer operatedCustomer = GetCustomerById(northwindEntities, customerId);
            operatedCustomer.CompanyName = newCompany;
            northwindEntities.SaveChanges();
        }

        public static void DeleteCustomer(string customerId)
        {
            NorthwindEntities northwindEntities = new NorthwindEntities();
            Customer operatedCustomer = GetCustomerById(northwindEntities, customerId);
            northwindEntities.Customers.Remove(operatedCustomer);
            northwindEntities.SaveChanges();
        }

        public static Customer GetCustomerById(NorthwindEntities northwindEntities, string customerId)
        {
            Customer operatedCustomer = northwindEntities.Customers.FirstOrDefault(
                p => p.CustomerID == customerId);
            return operatedCustomer;
        }
    }
}
