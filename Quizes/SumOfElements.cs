using System.Collections.Generic;

namespace MainDSA.Quizes
{
    public static class SumOfElements
    {
        /// <summary>
        /// 167. Two Sum II - Input array is sorted
        /// Given an array of integers that is already sorted in ascending order, find two numbers such that they add up to a specific target number.
        /// The function twoSum should return indices of the two numbers such that they add up to the target, where index1 must be less than index2.Please note that your returned answers(both index1 and index2) are not zero-based.
        /// You may assume that each input would have exactly one solution and you may not use the same element twice.
        /// Input: numbers={ 2, 7, 11, 15}, target=9 Output: index1=1, index2=2
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum(int[] nums, int target)
        {
            // Array to return the result
            int[] arr = new int[2] { -1, -1 };
            // Map for number and index pair 
            Dictionary<int, int> map = new Dictionary<int, int>();

            /*
            Check if the map has an element which is equal to the difference between the target and current element
            */
            for (int i = 0; i < nums.Length; i++)
            {
                //int? val = null;
                //if (map.ContainsKey(target - nums[i]))
                //{
                //    val = map[target - nums[i]];
                //}
                int val = -1;
                var found = map.TryGetValue(target - nums[i], out val);
                if (!found)
                {
                    /*
                    No Match found add the current  item and index to map
                    */
                    map.Add(nums[i], i);
                }
                else
                {
                    arr[0] = val;
                    arr[1] = i;
                    break;
                }
            }
            return arr;
        }
    }
}
