using System;
using System.Collections.Generic;

namespace MainDSA.Quizes
{
    public class ThreeSum
    {
        public List<List<int>> SumIsTarget(int[] num, int target = 0)
        {
            Array.Sort(num);
            List<List<int>> result = new List<List<int>>();
            for (int i = 0; i < num.Length - 2; i++)
            {
                if (i == 0 || (i > 0 && num[i] != num[i - 1]))
                {
                    int low = i + 1, high = num.Length - 1, sum = 0 - num[i];
                    while (low < high)
                    {
                        if (num[low] + num[high] == sum)
                        {
                            result.Add(new List<int>() { num[i], num[low], num[high] });
                            while (low < high && num[low] == num[low + 1]) low++;
                            while (low < high && num[high] == num[high - 1]) high--;
                            low++; high--;
                        }
                        else if (num[low] + num[high] < sum)
                        {
                            low++;
                        }
                        else
                        {
                            high--;
                        }
                    }
                }
            }
            return result;
        }
    }
}
