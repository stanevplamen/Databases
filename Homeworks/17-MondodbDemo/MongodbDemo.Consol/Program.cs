using MondodbDemo.Data;
using MondodbDemo.Data.Library;
using MondodbDemo.WebApp;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongodbDemo.Consol
{
    class Program
    {
        static void Main()
        {
            //var dbSearch = LoadData<Book>().ToList();
        }

        //private static IQueryable<T> LoadData<T>()
        //{
        //    try
        //    {
        //        IQueryable<T> result = MongoDbProvider.db.GetCollection<T>(typeof(T).Name).AsQueryable();
        //        return result;
        //    }
        //    catch (MongoConnectionException ex)
        //    {
        //        throw new MongoCommandException("Cannot access database. Please try again later");
        //    }
        //}

    }
}
