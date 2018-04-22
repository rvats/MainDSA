namespace MainDSA.DataStructures.Trie
{
    /// <summary>
    /// LeetCode: 208. Implement Trie (Prefix Tree)
    /// Implement a trie with insert, search, and startsWith methods. Note:
    /// You may assume that all inputs are consist of lowercase letters a-z.
    /// </summary>
    public class Trie
    {
        private OptimizedTrieNode root;

        /** Initialize your data structure here. */
        public Trie()
        {
            root = new OptimizedTrieNode();
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            OptimizedTrieNode pointer = root;
            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                int index = c - 'a';
                if (pointer.ArrayTrieNode[index] == null)
                {
                    OptimizedTrieNode temp = new OptimizedTrieNode();
                    pointer.ArrayTrieNode[index] = temp;
                    pointer = temp;
                }
                else
                {
                    pointer = pointer.ArrayTrieNode[index];
                }
            }
            pointer.IsEnd = true;
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            OptimizedTrieNode pointer = SearchNode(word);
            if (pointer == null)
            {
                return false;
            }
            else
            {
                if (pointer.IsEnd)
                    return true;
            }

            return false;
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            OptimizedTrieNode pointer = SearchNode(prefix);
            if (pointer == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public OptimizedTrieNode SearchNode(string searchWord)
        {
            OptimizedTrieNode pointer = root;
            for (int i = 0; i < searchWord.Length; i++)
            {
                char c = searchWord[i];
                int index = c - 'a';
                if (pointer.ArrayTrieNode[index] != null)
                {
                    pointer = pointer.ArrayTrieNode[index];
                }
                else
                {
                    return null;
                }
            }

            if (pointer == root)
                return null;

            return pointer;
        }
    }

}
