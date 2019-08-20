using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace WordCheater
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dictSource;
            List<string> words = new List<string>();
            LetterTree tree = new LetterTree();
            using (StreamReader file = File.OpenText("dictionary.json"))
            {
                dictSource = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText("dictionary.json"));
            }

            Console.WriteLine("starting import");
            foreach (KeyValuePair<string, string> entry in dictSource)
            {
                tree.addWord(entry.Key);
            }
            Console.WriteLine("Import complete");
        }
    }
}
