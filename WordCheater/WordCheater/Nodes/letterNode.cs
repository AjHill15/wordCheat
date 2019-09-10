using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordCheater.Nodes
{
    class letterNode:baseNode
    {
        private string _letter;
        public List<letterNode> nodes;
        public EndNode end;

        public string letter
        {
            get
            {
                return _letter;
            }
            set
            {
                _letter = value;
            }
        }

        private void buildNewNode(string newLetter)
        {
            _letter = newLetter;
            nodes = new List<letterNode>();
            end = null;
        }

        public letterNode()
        {
            buildNewNode(null);
        }

        public letterNode(string letter)
        {
            buildNewNode(letter);
        }

        public letterNode contains(string nextLetter)
        {
            foreach(letterNode node in nodes)
            {
                if(node.letter == nextLetter)
                {
                    return node;
                }
            }
            return null; 
        }

        public void addNodes(string nextLetters, string word)
        {
            var nextNode =  this.contains(nextLetters[0].ToString());

            if(nextNode == null)
            {
                nextNode = new letterNode();
            }
            nextNode.letter = nextLetters[0].ToString();

            nodes.Add(nextNode);

            if(nextLetters.Length > 1)
            {
                nextNode.addNodes(nextLetters.Substring(1), word);
            }
            else
            {
                nextNode.addEndNode(word);
            }
        }

        public void addEndNode(string word)
        {
            end = new EndNode(word);
        }

    }
}
