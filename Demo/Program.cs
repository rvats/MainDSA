using MainDSA.Quizes;
using System;

namespace Demo
{
    class Program
    {
        

        static void Main(string[] args)
        {
            int[] nums1 = new int[] { 1, 2, 1, 2 };
            int[] nums2 = new int[] { 2, 2 };
            var intersect = ArrayExtensions.IntersectNoSortingAllowed(nums1, nums2);
            foreach(var num in intersect)
            {
                Console.WriteLine(num);
            }
            
        }
    }
}
