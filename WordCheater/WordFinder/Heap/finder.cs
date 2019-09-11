using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace WordFinder.Heap
{
    public static class finder
    {

        public static List<string> findWords(string letters, LetterHeap heap)
        {
            List<string> goodResults = new List<string> { string.Empty};
            foreach(var letter in letters)
            {
                var newCombinations = new List<string>();
                foreach(var perm in goodResults)
                {
                   for(var i = 0; i <= perm.Length; i++)
                    {
                        newCombinations.Add(
                            perm.Substring(0, i) +
                            letter +
                            perm.Substring(i));
                    }
                }
                foreach(var combo in newCombinations)
                {
                    if (heap.Contains(combo))
                        goodResults.Add(combo);
                }
            }
            return goodResults;
        }

        public static List<string> findWordsOld(string leters, LetterHeap heap)
        {
            List<string> output = new List<string>();
            var possibleWords = getPermutations(leters);
            foreach (var word in possibleWords)
            {
                if (heap.Contains(word))
                {
                    output.Add(word);
                }
            }
            output.Sort();
            return output;
        }

        private static List<string> getPermutations(string letters)
        {
            List<string> combinations = new List<string> { string.Empty };
            foreach(var letter in letters)
            {
                var newCombinations = new List<string>();
                foreach(var combination in combinations)
                {
                    for(var i = 0; i <= combination.Length; i++)
                    {
                        newCombinations.Add(
                            combination.Substring(0, i) +
                            letter +
                            combination.Substring(i));
                    }
                }
                combinations.AddRange(newCombinations);
            }
            return filterList(combinations);
        }

        private static List<string> filterList(List<string> sourceList)
        {
            var wordHash = new HashSet<string>();
            foreach(var word in sourceList)
            {
                if (!string.IsNullOrWhiteSpace(word))
                {
                    wordHash.Add(word);
                }
            }
            var filteredList = wordHash.ToList<string>();
            return filteredList;
        }
    }
}
