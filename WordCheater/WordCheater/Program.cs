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

            int dictIndex = 0;
            foreach (KeyValuePair<string, string> entry in dictSource)
            {
                dictIndex++;
                Console.WriteLine(string.Format("Adding word: {0} {1} / {2}", entry.Key, dictIndex, dictSource.Count));
                tree.addWord(entry.Key);
            }
        }
    }
}
