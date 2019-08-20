using System;
using System.Collections.Generic;
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
                }

                if(word.Length > 1)
                {
                    firstNode.addNodes(word.Substring(1));
                }
            }
        }

    }
}
