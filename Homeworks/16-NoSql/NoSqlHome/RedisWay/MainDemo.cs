using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisWay
{
    class MainDemo
    {
        public static string keyPredicate = "word:";
        public static RedisDictionary demoDic; 

        static void Main()
        {
            demoDic = new RedisDictionary();
            AddWords();
            Console.WriteLine("List All Words");
            demoDic.ListAllWords();
            TranslateSomeWords(new List<string>() { "Bird", "Fish", "Woman", "Man" });
        }

        private static void AddWords()
        {
            demoDic.AddWord("Bird", "Any of various warm-blooded, egg-laying, feathered vertebrates of the class Aves, having forelimbs modified to form wings.");
            demoDic.AddWord("Fish", "Any of the class Osteichthyes, having a bony skeleton.");
            demoDic.AddWord("Human", "A member of the genus Homo and especially of the species H. sapiens");
            demoDic.AddWord("Woman", "An adult female human.");
            demoDic.AddWord("Idiot", "A foolish or stupid person.");
            demoDic.AddWord("Developer", "One that develops");
            demoDic.AddWord("Bulgarian", "A native or inhabitant of Bulgaria. Also called Bulgar.");
            demoDic.AddWord("Father", "A male parent of an animal or human.");
        }

        private static void TranslateSomeWords(List<string> list)
        {
            foreach (var word in list)
            {
                demoDic.Translate(word);
            }
        }
    }
}
