using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordFinder.Nodes;

namespace WordFinder.Heap
{
    public class LetterHeap
    {
        private List<letterNode> topLevelNodes;
        private Dictionary<string, string> fullDictionary;

        private dictionaryMode _mode;
        public dictionaryMode mode
        {
            get
            {
                return _mode;
            }
            private set
            {
                _mode = value;
            }
        }

        public List<string> dictionary
        {
            get
            {
                return fullDictionary.Keys.ToList<string>();
            }
        }

        public LetterHeap()
        {
            constructor(dictionaryMode.dictionary);
        }

        //public LetterHeap(dictionaryMode runMode)
        //{
        //    constructor(runMode);
        //}

        private void constructor(dictionaryMode runMode)
        {
            mode = runMode;
            if (mode == dictionaryMode.dictionary)
            {
                fullDictionary = new Dictionary<string, string>();
            }
            if (mode == dictionaryMode.heap)
            {
                topLevelNodes = new List<letterNode>();
            }
        }

        public bool Contains(string word)
        {
            if(mode == dictionaryMode.heap)
            {
                var startingNode = topLevelNodes.Where(n => n.letter.Contains(word.Substring(0, 1))).FirstOrDefault();
                if (startingNode == null)
                    return false; //how the hell
                var currentNode = startingNode;
                if (word.Length <= 1)
                    return true; //1 letter word, "a"
                for (int i = 1; i < word.Length; i++)
                {
                    string nextLetter = word.Substring(i, 1);
                    currentNode = currentNode.contains(nextLetter);
                    if (currentNode == null)
                        return false;
                    if ((i + 1) == word.Length)
                    {
                        var endNode = currentNode.end;
                        if (endNode != null)
                            return true;
                        return false;
                    }
                }
            }
            if(mode == dictionaryMode.dictionary)
            {
                return fullDictionary.ContainsKey(word);
            }
            return false; //you should never get here.
        }

        public void addWord(string word)
        {
            if(mode == dictionaryMode.heap)
            {
                addWordToHeap(word);
            }
            if(mode == dictionaryMode.dictionary)
            {
                addWordToDictionary(word);
            }
        }

        public void addWord(KeyValuePair<string,string> entry)
        {
            if(mode == dictionaryMode.dictionary)
            {
                addEntryToDictionary(entry);
            }
            if(mode == dictionaryMode.heap)
            {
                addWordToHeap(entry.Key);
            }
        }

        private void addWordToDictionary(string word)
        {
            if(!fullDictionary.ContainsKey(word))
            {
                fullDictionary.Add(word, "");
            }
        }

        private void addEntryToDictionary(KeyValuePair<string,string> entry)
        {
            if(!fullDictionary.ContainsKey(entry.Key))
            {
                fullDictionary.Add(entry.Key, entry.Value);
            }
            else
            {
                if(string.IsNullOrWhiteSpace(fullDictionary[entry.Key]))
                {
                    fullDictionary[entry.Key] = entry.Value;
                }
                else if(!string.IsNullOrWhiteSpace(entry.Value))
                {
                    fullDictionary[entry.Key] += string.Format("; {0}", entry.Value);
                }
            }
        }

        private void addWordToHeap(string word)
        {
            if (!string.IsNullOrWhiteSpace(word))
            {
                letterNode firstNode = null;
                string firstLetter = word[0].ToString();

                foreach (var topNode in topLevelNodes)
                {
                    if (topNode.letter == firstLetter)
                    {
                        firstNode = topNode;
                        break;
                    }
                }

                if (firstNode == null)
                {
                    firstNode = new letterNode(firstLetter);
                    topLevelNodes.Add(firstNode);
                }

                if (word.Length > 1)
                {
                    firstNode.addNodes(word.Substring(1), word);
                }
                else
                {
                    firstNode.addEndNode(word);
                }
            }
        }
    }
}
