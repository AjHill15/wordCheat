using System;
using System.Collections.Generic;
using System.Text;

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
            var filteredList = new List<string>();
            foreach(var word in sourceList)
            {
                if (!string.IsNullOrWhiteSpace(word))
                {
                    if (filteredList.IndexOf(word) == -1)
                    {
                        filteredList.Add(word);
                    }
                }
            }
            filteredList.Sort();
            return filteredList;
        }
    }
}
