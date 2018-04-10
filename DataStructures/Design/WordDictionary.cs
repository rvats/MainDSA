using System;
using System.Collections.Generic;

namespace MainDSA.DataStructures.Design
{
    public class WordDictionary
    {
        private TrieNode root;

        public WordDictionary()
        {
            root = new TrieNode();
        }

        // Adds a word into the data structure.
        public void AddWord(String word)
        {
            Dictionary<char, TrieNode> children = root.children;

            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];

                TrieNode t = null;
                if (children.ContainsKey(c))
                {
                    t = children[c];
                }
                else
                {
                    t = new TrieNode(c);
                    children.Add(c, t);
                }

                children = t.children;

                if (i == word.Length - 1)
                {
                    t.isLeaf = true;
                }
            }
        }

        // Returns if the word is in the data structure. A word could
        // contain the dot character '.' to represent any one letter.
        public bool Search(String word)
        {
            return DfsSearch(root.children, word, 0);

        }

        public bool DfsSearch(Dictionary<char, TrieNode> children, String word, int start)
        {
            if (start == word.Length)
            {
                if (children.Count == 0)
                    return true;
                else
                    return false;
            }

            char c = word[start];

            if (children.ContainsKey(c))
            {
                if (start == word.Length - 1 && children[c].isLeaf)
                {
                    return true;
                }

                return DfsSearch(children[c].children, word, start + 1);
            }
            else if (c == '.')
            {
                bool result = false;
                foreach (var child in children)
                {
                    if (start == word.Length - 1 && child.Value.isLeaf)
                    {
                        return true;
                    }

                    //if any path is true, set result to be true; 
                    if (DfsSearch(child.Value.children, word, start + 1))
                    {
                        result = true;
                    }
                }

                return result;
            }
            else
            {
                return false;
            }
        }
    }
}
