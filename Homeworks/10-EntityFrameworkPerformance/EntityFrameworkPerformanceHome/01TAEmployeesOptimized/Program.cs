using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TelerikAcademyModel;

namespace TAEmployees
{
    class Program
    {
        static void Main()
        {
            GetEmployeesFast();
            GetEmployeesSlow();
        }

        private static void GetEmployeesSlow()
        {
            TelerikAcademyEntities telerikEntity = new TelerikAcademyEntities();

            foreach (var employee in telerikEntity.Employees)
            {
                Console.WriteLine("{0} {1}", employee.FirstName, employee.LastName);
                Console.WriteLine("{0}", employee.Departments1.Name);
                Console.WriteLine("{0}", employee.Addresses.Towns.Name);
                Console.WriteLine();
            }
            Console.WriteLine(telerikEntity.Employees.Count());
        }

        private static void GetEmployeesFast()
        {
            TelerikAcademyEntities telerikEntity = new TelerikAcademyEntities();

            foreach (var employee in telerikEntity.Employees.Include("Addresses.Towns").Include("Departments"))
            {
                Console.WriteLine("{0} {1}", employee.FirstName, employee.LastName);
                Console.WriteLine("{0}", employee.Departments1.Name);
                Console.WriteLine("{0}", employee.Addresses.Towns.Name);
                Console.WriteLine();
            }
        }
    }
}
