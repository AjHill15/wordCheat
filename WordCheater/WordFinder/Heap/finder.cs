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
            var possibleWords = heap.dictionary;
            var goodWords = new List<string>();

            foreach(var word in possibleWords)
            {
                //tests
                if (word.Length > letters.Length)
                    continue;
                //if (!containsAllLetters(letters, word))
                //    continue;
                if (!containsNoOtherLetters(letters, word))
                    continue;
                //if you get this far you past all the test, add word to output.
                goodWords.Add(word);
            }

            return goodWords;
        }

        private static bool containsAllLetters(string letters, string word)
        {
            for(int i = 0; i < letters.Length; i++)
            {
                if (!word.Contains(letters[i]))
                    return false;
            }
            return true; 
        }

        private static bool containsNoOtherLetters(string letters, string word)
        {
            for(int i = 0; i < word.Length; i++)
            {
                if (!letters.Contains(word[i]))
                    return false;
            }
            return true;
        }

    }
}
