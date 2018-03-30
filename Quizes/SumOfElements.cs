using System.Collections.Generic;

namespace DemoQuizes
{
    public static class SumOfElements
    {
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
