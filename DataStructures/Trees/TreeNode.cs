namespace MainDSA.DataStructures.Trees
{
    public class TreeNode
    {
        private int value;
        private TreeNode left;
        private TreeNode right;

        public int Value { get => value; set => this.value = value; }
        public TreeNode Left { get => left; set => left = value; }
        public TreeNode Right { get => right; set => right = value; }

        public TreeNode(int x) { Value = x; }
    }
}
