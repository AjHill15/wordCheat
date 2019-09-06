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

            Console.WriteLine("***starting import***");
            foreach (KeyValuePair<string, string> entry in dictSource)
            {
                tree.addWord(entry.Key);
            }
            Console.WriteLine("***Import complete***");

            Console.WriteLine("***Testing***");

            int missingWordCount = 0;

            foreach(KeyValuePair<string,string> entry in dictSource)
            {
                if(!tree.Contains(entry.Key))
                {
                    missingWordCount++;
                    Console.WriteLine(string.Format("Error {0}: Heap does not contain {1}.", missingWordCount, entry.Key));
                }
            }

            if(missingWordCount > 0)
            {
                Console.WriteLine(string.Format("ERROR: {0} of {1} words missing from heap.",missingWordCount, dictSource.Count));
            }
            else
            {
                Console.WriteLine(string.Format("No errors: all {0} words included.", dictSource.Count));
            }

        }
    }
}
