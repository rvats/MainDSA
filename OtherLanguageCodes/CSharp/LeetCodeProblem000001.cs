/***********************************************************************************************************
Author: Rahul Vats (https://github.com/rvats/MainDSA)
1. Two Sum
https://leetcode.com/problems/two-sum/description/
Given an array of integers, return indices of the two numbers such that they add up to a specific target.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

Example:

Given nums = [2, 7, 11, 15], target = 9,

Because nums[0] + nums[1] = 2 + 7 = 9,
return [0, 1].
***********************************************************************************************************/
using System;
using System.Collections.Generic;

namespace Demo
{
    class Program
    {
        private static int counter = 0;

        static void Main(string[] args)
        {
            Solution s = new Solution();
            // The first case is limited
            var result = s.TwoSum1(new int[] { 2, 7, 11, 15 }, 4);
            s.DisplayResult(result, ++counter);
            result = s.TwoSum1(new int[] { 2, 7, 11, 15 }, 9);
            s.DisplayResult(result, ++counter);
            result = s.TwoSum1(new int[] { 2, 7, 11, 15 }, 13);
            s.DisplayResult(result, ++counter);
            result = s.TwoSum1(new int[] { 2, 7, 11, 15 }, 17);
            s.DisplayResult(result, ++counter);
            result = s.TwoSum1(new int[] { 2, 7, 11, 15 }, 14);
            s.DisplayResult(result, ++counter);
            result = s.TwoSum1(new int[] { 2, 7, 11, 15 }, 18);
            s.DisplayResult(result, ++counter);
            result = s.TwoSum1(new int[] { 2, 7, 11, 15 }, 22);
            s.DisplayResult(result, ++counter);
            result = s.TwoSum1(new int[] { 2, 7, 11, 15 }, 26);
            s.DisplayResult(result, ++counter);
            result = s.TwoSum2(new int[] { 2, 7, 11, 15 }, 26);
            s.DisplayResult(result, ++counter);
        }
    }

    /// <summary>
    /// 1. Two Sum
    /// </summary>
    public class Solution
    {
        /// <summary>
        /// 1. Two Sum Using Dictionary to achieve O(N) Time Complexity
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum1(int[] nums, int target)
        {
            if (nums == null || nums.Length < 2)
            {
                return new int[] { -1, -1 };
            }
            Dictionary<int, int> mapDifferenceFromTarget = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                // This is an edge case I added for testing certain scenarios 
                // Remove the following 3 lines for any isssues in Leetcode Acceptance
                if (target - nums[i] == nums[i])
                {
                    return new int[] { i, i };
                }
                if (mapDifferenceFromTarget.ContainsKey(nums[i]))
                {
                    return new int[] { mapDifferenceFromTarget[nums[i]], i };
                }
                else if (!mapDifferenceFromTarget.ContainsKey(target - nums[i]))
                {
                    mapDifferenceFromTarget.Add(target - nums[i], i);
                }
            }
            return new int[] { -1, -1 };
        }

        /// <summary>
        /// 1. Two Sum Using two for loops to achieve O(N^2) Time Complexity
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum2(int[] nums, int target)
        {
            if (nums == null || nums.Length < 2)
            {
                return new int[] { -1, -1 };
            }

            for (int i = 0; i < nums.Length; i++)
            {
                // You can change following for to j = i+1 and j < num.Length - 1 for removing my edge case
                for (int j = 0; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return new int[] { -1, -1 };
        }

        /// <summary>
        /// Helper Method To Display The Result
        /// </summary>
        /// <param name="result"></param>
        /// <param name="counter"></param>
        public void DisplayResult(int[] result, int counter)
        {
            Console.WriteLine("Test Case: {0}", counter);
            foreach (var index in result)
            {
                Console.WriteLine(index);
            }
            Console.WriteLine("================================================");
        }
    }
}