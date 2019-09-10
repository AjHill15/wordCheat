using System;
using System.Collections.Generic;
using System.Text;

namespace WordCheater.Nodes
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
