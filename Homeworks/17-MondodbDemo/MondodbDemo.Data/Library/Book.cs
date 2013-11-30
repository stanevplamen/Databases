using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MondodbDemo.Data.Library
{
    public class Book
    {
        public ObjectId _id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public BsonDateTime PublishDate { get; set; }
    }
}
