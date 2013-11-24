﻿using EntityFrameModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;

namespace EntityFrameworkDemo09_Incomes
{
    class Program
    {
        static void Main(string[] args)
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                var totalIncome = GetTotalIncomes("Tokyo Traders", new DateTime(1990, 1, 1), new DateTime(2000, 1, 1));

                Console.WriteLine(totalIncome);
            }
        }

        static decimal? GetTotalIncomes(string supplierName, DateTime? startDate, DateTime? endDate)
        {
            using (NorthwindEntities northwindEntites = new NorthwindEntities())
            {
                //var totalIncomeSet = northwindEntites.usp_GetTotalIncome(supplierName, startDate, endDate);

                //foreach (var totalIncome in totalIncomeSet)
                //{
                //    return totalIncome;
                //}
            }

            return null;
        }
    }
}
