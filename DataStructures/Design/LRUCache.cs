using MainDSA.DataStructures.Lists;
using System.Collections.Generic;

namespace MainDSA.DataStructures.Design
{
    public class LRUCache
    {
        private readonly int capacity;

        private int count;
        private readonly DoublyListNode head;
        private readonly Dictionary<int, DoublyListNode> myDictionary;
        public LRUCache(int capacity)
        {
            head = new DoublyListNode(-1, -1);
            head.Next = head;
            head.Previous = head;
            this.capacity = capacity;
            myDictionary = new Dictionary<int, DoublyListNode>();
        }

        public int Get(int key)
        {
            DoublyListNode node;
            myDictionary.TryGetValue(key, out node);
            if (node == null)
            {
                return -1;
            }

            this.MoveItToFirstElementAfterHead(node);

            return node.KeyValue.Value;
        }

        public void Put(int key, int value)
        {
            DoublyListNode node;
            myDictionary.TryGetValue(key, out node);
            if (node == null)
            {
                if (this.count == this.capacity)
                {
                    // remove the last element
                    myDictionary.Remove(head.Previous.KeyValue.Key);
                    head.Previous = head.Previous.Previous;
                    head.Previous.Next = head;

                    count--;
                }

                // create new node and add to dictionary
                var newNode = new DoublyListNode(key, value);
                myDictionary[key] = newNode;

                this.InsertAfterTheHead(newNode);

                // increase count
                count++;
            }
            else
            {
                node.KeyValue = new KeyValuePair<int, int>(key, value);
                this.MoveItToFirstElementAfterHead(node);
            }
        }

        private void MoveItToFirstElementAfterHead(DoublyListNode node)
        {
            RemoveCurrentNode(node);

            this.InsertAfterTheHead(node);
        }

        private void InsertAfterTheHead(DoublyListNode node)
        {
            // insert after the head
            node.Next = this.head.Next;
            node.Previous = this.head;
            this.head.Next.Previous = node;
            this.head.Next = node;
        }

        private static void RemoveCurrentNode(DoublyListNode node)
        {
            // remove current node
            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;
        }
    }
}
