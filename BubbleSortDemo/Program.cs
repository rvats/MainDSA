using MainDSA.Algorithms.Sort;
using System;

namespace BubbleSortDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] number = { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            BubbleSort bubbleSort = new BubbleSort();
            Console.WriteLine("Before Sorting: ");
            foreach (int num in number)
            {
                Console.Write("{0}\t", num);
            }
            Console.WriteLine();
            number = bubbleSort.Sort(number);
            Console.WriteLine("After Sorting: ");
            foreach (int num in number)
            {
                Console.Write("{0}\t", num);
            }
            Console.WriteLine();
            Console.Read();
        }
    }
}
