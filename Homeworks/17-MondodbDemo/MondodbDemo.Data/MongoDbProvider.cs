using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MondodbDemo.Data
{
    public static class MongoDbProvider
    {
        public static string ConnectionString = "mongodb://localhost";
        public static string DatabaseNameGHard = "BookStoreDemo2";
        // public static string ConnectionString = "mongodb://127.0.0.1/BookStoreDemo";

        public static MongoDatabase db
        {
            get
            {
                var connectionstring = ConnectionString; // dbSetting.Default.MONGOLAB_URI;
                string dbName = DatabaseNameGHard;
                MongoServer dbServer = MongoServer.Create(connectionstring);
                MongoDatabase dbConnection = dbServer.GetDatabase(dbName, SafeMode.True);
                return dbConnection;
            }
        }

        //public static void SaveData<T>(T value) // (this MongoDatabase source, T value)
        //{
        //    try
        //    {
        //        var result = db.GetCollection<T>(typeof(T).Name).Save(value, SafeMode.True);
        //    }
        //    catch (MongoConnectionException ex)
        //    {
        //        throw new MongoCommandException("Cannot access database. Please try again later");
        //    }
        //}
     
    }
}
