using MainDSA.Quizes;
using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 0, 1, 0, 3, 12 };
            ArrayExtensions.MoveZeroes(nums);
            foreach(int num in nums)
            {
                Console.Write(num);
                Console.Write(" ");
            }
        }
    }
}
