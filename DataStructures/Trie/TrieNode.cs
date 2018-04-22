using System.Collections.Generic;

namespace MainDSA.DataStructures.Trie
{
    public class TrieNode
    {
        char c;
        public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
        public bool isLeaf;

        public TrieNode() { }

        public TrieNode(char c)
        {
            this.c = c;
        }
    }
}
