using System;
using System.Collections.Generic;

namespace MainDSA.Quizes
{
    public class Addition
    {
        /// <summary>
        /// 15. 3Sum
        /// </summary>
        /// <param name="num"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> GetListOf3WhoseSumIsTarget(int[] num, int target = 0)
        {
            Array.Sort(num);
            IList <IList<int>> result = new List<IList<int>>();
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
