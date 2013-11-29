using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisWay
{
    public class RedisDictionary
    {
        public void ListAllWords()
        {
            var dictionary = GetKeysAndValues();

            foreach (var word in dictionary)
            {
                Console.WriteLine(word);
            }
        }

        public void AddWord(string word, string translation)
        {
            StoreInHash(word, translation);
        }

        public void Translate(string wordCur)
        {
            Console.WriteLine("Translation: {0}", GetValue(wordCur));
        }

        private void StoreInHash(string key, string value)
        {
            using (IRedisClient client = new RedisClient())
            {
                var objClient = client.GetTypedClient<string>();

                var hash = objClient.GetHash<string>(MainDemo.keyPredicate + key.ToString());

                hash.Add(key, value);
            }
        }

        private string GetValue(string key)
        {
            string returnedValue;
            using (IRedisClient client = new RedisClient())
            {

                var objClient = client.GetTypedClient<string>();

                var hash = objClient.GetHash<string>(MainDemo.keyPredicate + key);
                returnedValue = hash[key];
            }

            return returnedValue;
        }

        private List<Word> GetKeysAndValues()
        {
            List<Word> result = new List<Word>();
            using (IRedisClient client = new RedisClient())
            {
                var objClient = client.GetTypedClient<string>();

                var keys = objClient.GetAllKeys().Where(x => x.StartsWith(MainDemo.keyPredicate));

                foreach (var key in keys)
                {
                    var hash = objClient.GetHash<string>(key);
                    var word = key.Substring(MainDemo.keyPredicate.Length);
                    var val = hash[word];
                    result.Add(new Word(word, val));
                }
            }

            return result;
        }
    }
}
