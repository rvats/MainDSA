using System;
using MainDSA.Quizes;

namespace SubsetSumDemo
{
    class Program
    {
        // Driver program
        public static void Main()
        {
            int n = 5;
            int size = 100;
            int[] arr = new int[size];

            Console.WriteLine("Different compositions formed"
                        + " by 1, 2 and 3 of " + n + " are");
            ArrayExtensions.PrintCompositions(arr, n, 0, 5);
        }
    }
}
