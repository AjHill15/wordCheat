using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace WordCheater.Heap
{
    static class finder
    {
        public static List<string> findWords(string leters, LetterHeap heap)
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
            filteredList.Sort();
            return filteredList;
        }
    }
}
