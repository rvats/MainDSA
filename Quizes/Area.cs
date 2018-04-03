using System;
using System.Collections.Generic;

namespace MainDSA.Quizes
{
    public static class Area
    {
        public static int MaxArea(int[] heights)
        {
            int left = 0, right = heights.Length - 1;
            int maxArea = 0;

            while (left < right)
            {
                maxArea = Math.Max(maxArea, Math.Min(heights[left], heights[right])*(right-left));
                if(heights[left] < heights[right])
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
            return maxArea;
        }

        public static LinkedList<int> AllAreas(int[] heights)
        {
            LinkedList<int> allAreas = new LinkedList<int>();
            for (int i = 0; i < heights.Length - 2; i++)
            {
                for (int j = i+1; j < heights.Length - 1; j++)
                {
                    allAreas.AddLast(Math.Min(heights[i], heights[j]) * (j - i));
                }
            }
            
            return allAreas;
        }
    }
}
