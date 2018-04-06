using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainDSA.Quizes
{
    public class Water
    {
        public int Trap(int[] height)
        {
            if (height.Length == 0)
            {
                return 0;
            }

            int length = height.Length;
            // left[i] contains height of tallest bar to the
            // left of i'th bar including itself
            int[] left = new int[length];

            // Right [i] contains height of tallest bar to
            // the right of ith bar including itself
            int[] right = new int[length];

            // Initialize result
            int water = 0;

            // Fill left array
            left[0] = height[0];
            for (int i = 1; i < length; i++)
                left[i] = Math.Max(left[i - 1], height[i]);

            // Fill right array
            right[length - 1] = height[length - 1];
            for (int i = length - 2; i >= 0; i--)
                right[i] = Math.Max(right[i + 1], height[i]);

            // Calculate the accumulated water element by element
            // consider the amount of water on i'th bar, the
            // amount of water accumulated on this particular
            // bar will be equal to min(left[i], right[i]) - arr[i] .
            for (int i = 0; i < length; i++)
                water += Math.Min(left[i], right[i]) - height[i];

            return water;
        }
    }
}
