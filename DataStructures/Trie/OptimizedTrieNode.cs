namespace MainDSA.DataStructures.Trie
{
    public class OptimizedTrieNode
    {
        public OptimizedTrieNode[] ArrayTrieNode;
        public bool IsEnd;
        // Initialize your data structure here.
        public OptimizedTrieNode()
        {
            ArrayTrieNode = new OptimizedTrieNode[26];
        }
    }
}
