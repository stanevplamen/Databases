using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Builders;

namespace MondoWay
{
    public class MongoDictionary
    {
        private MongoClient client;
        private MongoServer mongoServer ;
        private MongoDatabase dictionaryDB;
        private MongoCollection<Word> mongoCollection;

        public MongoDictionary() // (string database, string collection)
        {
            this.client = new MongoClient(MainDemo.ConnectionString);
            this.mongoServer = client.GetServer();
            this.dictionaryDB = mongoServer.GetDatabase(MainDemo.ConnectionDatabase); // will asign "Dictionary"
            this.mongoCollection = dictionaryDB.GetCollection<Word>(MainDemo.ConnectionCollection); // will asign "Words"
        }


        public void ListAllWords()
        {
            var dictionary = mongoCollection.FindAllAs<Word>();
            foreach (var word in dictionary)
            {
                Console.WriteLine(word);
            }
        }

        public void AddWord(string word, string translation)
        {
            Word newWord = new Word(word.ToLower(), translation.ToLower());

            int countWords = mongoCollection.AsQueryable<Word>().Where(w => w.ActualWord == newWord.ActualWord).Count();
            if (countWords == 0)
            {
                mongoCollection.Insert<Word>(newWord);
            }
            else
            {
                Console.WriteLine("Error! The world already exists!");
            }
        }

        public void Translate(string word)
        {
            var searchedWord = mongoCollection.AsQueryable<Word>().FirstOrDefault(w => w.ActualWord == word.ToLower());
            if (searchedWord != null)
            {
                Console.WriteLine("Word: {0}\nTranslation: {1}", searchedWord.ActualWord, searchedWord.Explanation);
            }
            else
            {
                Console.WriteLine("The word {0} not exists", word);
            }
        }

        public void RemoveWord(string word)
        {
            var removedWord = mongoCollection.AsQueryable<Word>().FirstOrDefault(w => w.ActualWord == word.ToLower());
            if (removedWord != null)
            {
                try
                {
                    var query = Query.EQ("_id", removedWord.Id);
                    mongoCollection.Remove(query);
                    Console.WriteLine("The word {0} has been removed", word);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while remowing word {0}, with message {1}", word, ex.Message);
                }
            }
            else
            {
                Console.WriteLine("The word {0} not exists", word);
            }
        }

        //public bool ContainsKey(string key)
        //{
        //    int countOccurences = this.collectionQuery.Where(x => x.ActualWord == key).ToList().Count;

        //    if (countOccurences > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
