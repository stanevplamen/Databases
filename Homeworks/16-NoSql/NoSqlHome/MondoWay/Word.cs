using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MondoWay
{
    public class Word
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string ActualWord { get; set; }
        public string Explanation { get; set; }


        public Word(string word, string explanation)
        {
            this.ActualWord = word;
            this.Explanation = explanation;
        }

        public override string ToString()
        {
            return String.Format("Word:{0,15} | Explanation: {1}", this.ActualWord,  this.Explanation); 
        }
    }
}
