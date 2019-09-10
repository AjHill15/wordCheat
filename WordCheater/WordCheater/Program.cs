using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using WordCheater.Heap;

namespace WordCheater
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dictSource;
            List<string> words = new List<string>();
            LetterHeap tree = new LetterHeap();
            using (StreamReader file = File.OpenText("dictionary.json"))
            {
                dictSource = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText("dictionary.json"));
            }

            Console.WriteLine("***starting import***");
            importDictionary(tree, dictSource);
            Console.WriteLine("***Import complete***");

            Console.WriteLine("***Testing dictionary completeness***");

            int missingWordCount = 0;

            foreach (KeyValuePair<string, string> entry in dictSource)
            {
                if (!tree.Contains(entry.Key))
                {
                    missingWordCount++;
                    Console.WriteLine(string.Format("Error {0}: Heap does not contain {1}.", missingWordCount, entry.Key));
                }
            }

            if (missingWordCount > 0)
            {
                Console.WriteLine(string.Format("ERROR: {0} of {1} words missing from heap.", missingWordCount, dictSource.Count));
            }
            else
            {
                Console.WriteLine(string.Format("No errors: all {0} words included.", dictSource.Count));
            }

            Console.WriteLine("***Testing finding all words***");
            string testWord = "chocolate";
            Console.WriteLine(string.Format("Testing word: {0}", testWord));
            var wordResults = finder.findWords(testWord, tree);
            if(wordResults.Count > 0)
            {
                Console.WriteLine(string.Format("{0} results found!", wordResults.Count));
                foreach(var result in wordResults)
                {
                    Console.WriteLine(result);
                }
            }
            else
            {
                Console.WriteLine("No words found.");
            }

        }

        private static void importDictionary(LetterHeap heap, Dictionary<string, string> source)
        {
            foreach (KeyValuePair<string, string> entry in source)
            {
                heap.addWord(entry.Key);
            }
        }

    }
}
