using System;
using System.Collections.Generic;
using System.Text;

namespace WordFinder.Nodes
{
    class EndNode: baseNode
    {
        public string word { get; set; }
        public EndNode(string word)
        {
            this.word = word;
        }
    }
}
