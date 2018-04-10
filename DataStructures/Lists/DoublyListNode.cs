using System.Collections.Generic;

namespace MainDSA.DataStructures.Lists
{
    public class DoublyListNode
    {
        public KeyValuePair<int, int> KeyValue { get; set; }

        public DoublyListNode Next { get; set; }

        public DoublyListNode Previous { get; set; }

        public DoublyListNode(int key, int value)
        {
            this.KeyValue = new KeyValuePair<int, int>(key, value);
            Next = null;
            Previous = null;
        }
    }
}
