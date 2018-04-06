namespace MainDSA.DataStructures.Lists
{
    /// <summary>
    /// Definition for singly-linked list.
    /// </summary>
    public class ListNode
    {
        private int value;
        private ListNode next;
        public ListNode (int x) { Value = x; }

        public ListNode Next { get => next; set => next = value; }
        public int Value { get => value; set => this.value = value; }
    }
}
