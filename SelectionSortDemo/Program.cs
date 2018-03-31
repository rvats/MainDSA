using MainDSA.Algorithms.Sort;
using System;

namespace SelectionSortDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] number = { 9, 1, 2, 3, 4, 5, 6, 7, 8 };
            SelectionSort selectionSort = new SelectionSort();
            Console.WriteLine("Before Sorting: ");
            foreach (int num in number)
            {
                Console.Write("{0}\t", num);
            }
            Console.WriteLine();
            number = selectionSort.Sort(number);
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
