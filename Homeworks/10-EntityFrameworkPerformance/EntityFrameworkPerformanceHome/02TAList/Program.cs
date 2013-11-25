using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademyModel;

namespace TAList
{
    class Program
    {
        public static void Main()
        {
            SelectWithMultipleToList(); // Produces 645 queries.
            SelectWithOptimizedToList(); // Produces only one query.
        }

        private static void SelectWithMultipleToList()
        {
            using (var telerikAcademyDBContext = new TelerikAcademyEntities())
            {
                var result = telerikAcademyDBContext.Employees.ToList()
                    .Select(e => e.Addresses).ToList().Select(a => a.Towns).ToList()
                    .Where(t => t.Name == "Sofia").ToList();
            }
            Console.WriteLine("Method 1 finished");
        }

        private static void SelectWithOptimizedToList()
        {
            using (var telerikAcademyDBContext = new TelerikAcademyEntities())
            {
                var result = telerikAcademyDBContext.Employees
                    .Select(e => e.Addresses).Select(a => a.Towns)
                    .Where(t => t.Name == "Sofia").ToList();
            }
            Console.WriteLine("Method 2 finished");
        }
    }
}
