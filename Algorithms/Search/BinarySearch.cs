using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainDSA.Algorithms.Search
{
    public class BinarySearch
    {
        public int SearchIteratively(int[] nums, int target)
        {
            int first = 0;
            int last = nums.Length - 1;
            int mid = 0;
            while (first <= last)
            {
                mid = (first + last) / 2;
                if (nums[mid] == target) return mid;
                else if (nums[mid] < target) first = mid + 1;
                else last = mid - 1;
            }
            return -1;
        }

        public int SearchRecursively(int[] nums, int target)
        {
            int first = 0;
            int last = nums.Length - 1;
            return Search(nums, first, last, target);
        }

        private int Search(int[] nums, int first, int last, int target)
        {
            if (first > last)
            {
                return -1;
            }
            else
            {
                int mid = (first + last) / 2;
                if (target == nums[mid])
                {
                    return mid;
                }
                else if (target < nums[mid])
                {
                    return Search(nums, first, mid - 1, target);
                }
                else
                {
                    return Search(nums, mid + 1, last, target);
                }
            }
        }
    }
}
