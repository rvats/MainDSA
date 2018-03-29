using DataStructures.Search;
using System;

namespace BinarySearchDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearch binarySearch = new BinarySearch();
            
            for (int data = 0; data <= 42; data++)
            {
                if (binarySearch.Exists(data))
                {
                    Console.WriteLine("Searching for {0} in the given Array. Index of {1} in the array: {2}", data, data, binarySearch.FindIndex(data));
                }
            }
        }
    }
}
