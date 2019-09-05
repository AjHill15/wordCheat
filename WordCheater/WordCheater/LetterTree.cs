using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordCheater
{
    class LetterTree
    {

        private List<letterNode> topLevelNodes;

        public LetterTree()
        {
            topLevelNodes = new List<letterNode>();
        }

        public bool Contains(string word)
        {
            var startingNode = topLevelNodes.Where(n => n.letter.Contains(word.Substring(0,1))).FirstOrDefault();
            if (startingNode == null)
                return false; //how the hell
            var currentNode = startingNode;
            if (word.Length <= 1)
                return true; //1 letter word, "a"
            for(int i = 1; i < word.Length; i++)
            {
                string nextLetter = word.Substring(i, 1);
                currentNode = currentNode.contains(nextLetter);
                if (currentNode == null)
                    return false;
                if((i + 1) == word.Length)
                {
                    var endNode = currentNode.end;
                    if (endNode != null)
                        return true;
                    return false;
                }
            }
            return false; //you should never get here.
        }

        public void addWord(string word)
        {
            if (!string.IsNullOrWhiteSpace(word))
            {
                letterNode firstNode = null;
                string firstLetter = word[0].ToString();

                foreach(var topNode in topLevelNodes)
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

                if(word.Length > 1)
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
