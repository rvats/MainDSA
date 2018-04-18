using System;
using System.Collections.Generic;
using System.Linq;

namespace MainDSA.Quizes
{
    public static class ArrayExtensions
    {
        public static int[] TwoSum(int[] nums, int target)
        {
            if (nums == null || nums.Length < 2)
                return new int[] { -1, -1 };

            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(nums[i]))
                {
                    return new int[] { map[nums[i]], i };
                }
                else
                {
                    // For each Index add the difference between the index and target and the index as a key value pair.
                    // Make Sure We do not add duplicates
                    if (!map.ContainsKey(target - nums[i]))
                    {
                        map.Add(target - nums[i], i);
                    }
                }
            }

            return new int[] { -1, -1 };
        }

        public static int FindLengthOfLCIS(int[] nums)
        {
            int ans = 0, anchor = 0;
            for (int i = 0; i < nums.Length; ++i)
            {
                if (i > 0 && nums[i - 1] >= nums[i]) anchor = i;
                ans = Math.Max(ans, i - anchor + 1);
            }
            return ans;
        }

        public static IList<IList<int>> Permute(int[] numbersSet)
        {
            Array.Sort(numbersSet);
            return PermuteUniqueList(numbersSet.ToList());
        }

        private static IList<IList<int>> PermuteUniqueList(List<int> numbersSet)
        {
            var result = new List<IList<int>>();
            if (!numbersSet.Any())
            {
                result.Add(new List<int>());
                return result;
            }

            for (int i = 0; i < numbersSet.Count; i++)
            {
                if (i != 0 && numbersSet[i] == numbersSet[i - 1])
                {
                    continue;
                }
                var numRemoved = new List<int>(numbersSet);
                numRemoved.RemoveAt(i);
                var restPermutations = PermuteUniqueList(numRemoved);

                foreach (var restPermutation in restPermutations)
                {
                    restPermutation.Add(numbersSet[i]);
                    result.Add(restPermutation);
                }
            }

            return result;
        }
        
        /// <summary>
        /// 78. Subsets
        /// </summary>
        public static IList<IList<int>> Subsets(int[] numbersSet)
        {
            Array.Sort(numbersSet);
            var result = new List<IList<int>>();
            var solution = new List<int>();
            SubsetsRecursion(numbersSet, 0, result, solution);
            return result;
        }

        private static void SubsetsRecursion(int[] numbersSet, int index, List<IList<int>> result, List<int> solution)
        {
            if (index >= numbersSet.Count())
            {
                result.Add(new List<int>(solution));
                return;
            }

            // add item nums[index] 
            solution.Add(numbersSet[index]);
            SubsetsRecursion(numbersSet, index + 1, result, solution);
            solution.RemoveAt(solution.Count - 1);

            // do not add nums[index]
            SubsetsRecursion(numbersSet, index + 1, result, solution);
        }

        public static IList<int> Subsets2(int[] S)
        {
            Array.Sort(S);
            var results = new List<int>();
            var count = (int)Math.Pow(2, S.Length);

            for (int i = 0; i < count; i++)
            {
                var resultData = new List<int>();
                for (int j = 0; j < 32; j++)
                {
                    if ((i >> j & 1) == 1)
                    {
                        resultData.Add(S[j]);
                    }
                }
                foreach(var data in resultData)
                {
                    results.Add(data);
                }
            }

            return results;
        }

        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            while (m > 0 && n > 0)
            {
                if (nums1[m - 1] > nums2[n - 1])
                {
                    nums1[m + n - 1] = nums1[m - 1];
                    m--;
                }
                else
                {
                    nums1[m + n - 1] = nums2[n - 1];
                    n--;
                }
            }

            while (n > 0)
            {
                nums1[m + n - 1] = nums2[n - 1];
                n--;
            }
        }

        public static int NumIslands(char[,] grid)
        {
            if (grid == null || grid.Length == 0 || grid.GetUpperBound(0) < 0 || grid.GetUpperBound(1) < 0)
                return 0;

            int m = grid.GetUpperBound(0) + 1;
            int n = grid.GetUpperBound(1) + 1;

            int count = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i,j] == '1')
                    {
                        count++;
                        Merge(grid, i, j);
                    }
                }
            }

            return count;
        }

        public static void Merge(char[,] grid, int i, int j)
        {
            int m = grid.GetUpperBound(0) + 1;
            int n = grid.GetUpperBound(1) + 1;

            if (i < 0 || i >= m || j < 0 || j >= n || grid[i,j] != '1')
                return;

            grid[i,j] = 'X';

            Merge(grid, i - 1, j);
            Merge(grid, i + 1, j);
            Merge(grid, i, j - 1);
            Merge(grid, i, j + 1);
        }

        public static int FindKthLargest2(int[] nums, int k)
        {
            Queue<int> queue = new Queue<int>(k);
            foreach (int i in nums)
            {
                queue.Enqueue(i);

                if (queue.Count > k)
                {
                    queue.Dequeue();
                }
            }

            return queue.Peek();
        }

        public static int FindKthLargest(int[] nums, int k)
        {
            Array.Sort(nums, (a, b) => b.CompareTo(a));
            return nums[k - 1];
        }

        public static int MaximumSubArrayLengthNonContiguous(int target, int[] numbers)
        {
            Array.Sort(numbers);
            int sum = 0, count = 0;
            while (sum < target && count < numbers.Length)
            {
                sum += numbers[count];
                count++;
            }
            if (sum < target)
            {
                return 0;
            }
            else
            {
                return count;
            }
        }

        public static int MaximumSubArrayLengthContiguous(int target, int[] numbers)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            int max = 0;
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];

                if (sum == target)
                {
                    max = Math.Max(max, i + 1);
                }

                int diff = sum - target;

                if (map.ContainsKey(diff))
                {
                    max = Math.Max(max, i - map[diff]);
                }

                if (!map.ContainsKey(sum))
                {
                    map.Add(sum, i);
                }
            }
            return max;
        }

        public static int MinimumSubArrayLengthNonContiguous(int target, int[] numbers)
        {
            Array.Sort(numbers, (a, b) => b.CompareTo(a));
            int sum = 0, count = 0;
            while (sum < target && count < numbers.Length)
            {
                sum += numbers[count];
                count++;
            }
            if (sum < target)
            {
                return 0;
            }
            else
            {
                return count;
            }
        }

        public static int MinimumSubArrayLengthContiguous(int target, int[] numbers)
        {
            int length = numbers.Length;
            int count = int.MaxValue;
            int left = 0;
            int sum = 0;
            for (int i = 0; i < length; i++)
            {
                sum += numbers[i];
                while (sum >= target)
                {
                    count = Math.Min(count, i + 1 - left);
                    sum -= numbers[left++];
                }
            }
            return (count != int.MaxValue) ? count : 0;
        }

        static public int[] IntersectNoSortingAllowed(int[] nums1, int[] nums2)
        {
            // For Storing How many time a number is appearing in the given array
            // Key is the number and value is the count of times the number appeared in the array
            Dictionary<int, int> map = new Dictionary<int, int>();
            // This is O(n)
            foreach (var num in nums1)
            {
                if (map.ContainsKey(num))
                {
                    map[num] = map[num] + 1;
                }
                else
                {
                    map.Add(num, 1);
                }
            }
            
            // Use a list for dynamically handling the size and making the addition of numbers easy
            List<int> list = new List<int>();

            // This is O(m)
            foreach (var num in nums2)
            {
                // Check if the map contains the number and reduce the value of the map for a given key unless its 1 then remove the key 
                if (map.ContainsKey(num))
                {
                    if (map[num] > 1)
                    {
                        map[num] = map[num] - 1;
                    }
                    else
                    {
                        map.Remove(num);
                    }
                    list.Add(num);
                }
            }

            // Overall Time Complexity is O(n+m) ≈ O(n) Considering n > m and treating m as a constant
            return list.ToArray();
        }

        static public int[] IntersectSortingAllowed(int[] nums1, int[] nums2)
        {
            Array.Sort(nums1);
            Array.Sort(nums2);

            List<int> list = new List<int>();

            int p1 = 0, p2 = 0;
            while (p1 < nums1.Length && p2 < nums2.Length)
            {
                if (nums1[p1] < nums2[p2])
                {
                    p1++;
                }
                else if (nums1[p1] > nums2[p2])
                {
                    p2++;
                }
                else
                {
                    list.Add(nums1[p1]);
                    p1++;
                    p2++;

                }
            }

            return list.ToArray();
        }

        static public void MoveZeroes(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        if (nums[j] != 0)
                        {
                            int temp = nums[j];
                            nums[j] = nums[i];
                            nums[i] = temp;
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// // Function prints all combinations of numbers 
        /// // 1, 2, ...maxPoint that sum up to n. i is 
        /// // used in recursion keep track of index in 
        /// // arr[] where next element is to be added. 
        /// // Initital value of i must be passed as 0
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="n"></param>
        /// <param name="i"></param>
        public static void PrintCompositions(int[] arr, int n, int i, int maxPoint)
        {
            if (n == 0)
            {
                PrintArray(arr, i);
            }
            else if (n > 0)
            {
                for (int k = 1; k <= maxPoint; k++)
                {
                    arr[i] = k;
                    PrintCompositions(arr, n - k, i + 1, maxPoint);
                }
            }
        }

        // Utility function to print array arr[]
        private static void PrintArray(int[] arr, int m)
        {
            for (int i = 0; i < m; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }

        public static int FindRotationPoint(string[] words)
        {
            string firstWord = words[0];

            int floorIndex = 0;
            int ceilingIndex = words.Length - 1;

            while (floorIndex < ceilingIndex)
            {
                // Guess a point halfway between floor and ceiling
                int guessIndex = floorIndex + ((ceilingIndex - floorIndex) / 2);

                // If guess comes after first word or is the first word
                if (string.Compare(words[guessIndex], firstWord, StringComparison.Ordinal) >= 0)
                {
                    // Go right
                    floorIndex = guessIndex;
                }
                else
                {
                    // Go left
                    ceilingIndex = guessIndex;
                }

                // If floor and ceiling have converged
                if (floorIndex + 1 == ceilingIndex)
                {
                    // Between floor and ceiling is where we flipped to the beginning,
                    // so ceiling is alphabetically first
                    break;
                }
            }

            return ceilingIndex;
        }

        public static int RemoveDuplicatesAndReturnLength(int[] num)
        {
            /* Handle Empty List First */
            if (num.Length == 0)
            {
                return 0;
            }
            Array.Sort(num);
            int j = 0;
            for (int i = 1; i < num.Length; i++)
            {
                if (num[i] != num[j])
                {
                    num[++j] = num[i];
                }
            }
            for (int i = 0; i <= j; i++)
            {
                Console.WriteLine(num[i]);
            }
            return ++j;
        }

        public static int RemoveElementAndReturnLength(int[] num, int element)
        {
            /* Handle Empty List First */
            if (num.Length == 0)
            {
                return 0;
            }
            Array.Sort(num);
            int slow = 0;
            for (int fast = 0; fast < num.Length; fast++)
            {
                if (num[fast] != element)
                {
                    num[slow++] = num[fast];
                }
            }
            for (int i = 0; i < slow; i++)
            {
                Console.WriteLine(num[i]);
            }
            return slow;
        }

        /// <summary>
        /// This is the basic approach and it takes O(n^2) order of time and O(n) space
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int[] ReturnProductOfRemainingNumbers(int[] array)
        {
            int length = array.Length;
            var productArray = new int[length];

            for (int i = 0; i < length; i++)
            {
                productArray[i] = 1;
                for (int j = 0; j < length; j++)
                {
                    if (j != i)
                    {
                        productArray[i] = productArray[i] * array[j];
                    }
                }
            }
            return productArray;
        }

        /// <summary>
        /// This is a better approach and it takes O(n+n)=O(n) order of time and O(n) space
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int[] GetProductsOfAllIntsExceptAtIndex(int[] intArray)
        {
            if (intArray.Length < 2)
            {
                throw new ArgumentException(
                    "Getting the product of numbers at other indices requires at least 2 numbers",
                    nameof(intArray));
            }

            // We make an array with the length of the input array to
            // hold our products
            int[] productsOfAllIntsExceptAtIndex = new int[intArray.Length];

            // For each integer, we find the product of all the integers
            // before it, storing the total product so far each time
            int productSoFar = 1;
            for (int i = 0; i < intArray.Length; i++)
            {
                productsOfAllIntsExceptAtIndex[i] = productSoFar;
                productSoFar *= intArray[i];
            }

            // For each integer, we find the product of all the integers
            // after it. since each index in products already has the
            // product of all the integers before it, now we're storing
            // the total product of all other integers
            productSoFar = 1;
            for (int i = intArray.Length - 1; i >= 0; i--)
            {
                productsOfAllIntsExceptAtIndex[i] *= productSoFar;
                productSoFar *= intArray[i];
            }
            return productsOfAllIntsExceptAtIndex;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arrayOfInts"></param>
        /// <returns></returns>
        public static int HighestProductOf3(int[] arrayOfInts)
        {
            // k = 3
            if (arrayOfInts.Length < 3)
            {
                throw new ArgumentException("Less than 3 items!", nameof(arrayOfInts));
            }

            // We're going to start at the 3rd item (at index 2)
            // so pre-populate highests and lowests based on the first 2 items.
            // We could also start these as null and check below if they're set
            // but this is arguably cleaner

            // For highestProductOfk -> highestProductOf3 = arrayOfInts[0] * arrayOfInts[1] *...* arrayOfInts[k-1]
            int highestProductOf3 = arrayOfInts[0] * arrayOfInts[1] * arrayOfInts[2];
            // For highestProductOfk-1 -> highestProductOf3 = arrayOfInts[0] * arrayOfInts[1] *...* arrayOfInts[k-2]
            int highestProductOf2 = arrayOfInts[0] * arrayOfInts[1];
            // For highestProductOfk-1 -> highestProductOf3 = arrayOfInts[0] * arrayOfInts[1] *...* arrayOfInts[k-2]
            int lowestProductOf2 = arrayOfInts[0] * arrayOfInts[1];

            // Following 2 Steps remains same for highestProductOfk
            int highest = Math.Max(arrayOfInts[0], arrayOfInts[1]);
            int lowest = Math.Min(arrayOfInts[0], arrayOfInts[1]);

            // index will start at k-1
            for (int i = 2; i < arrayOfInts.Length; i++)
            {
                // Following Steps remains same for highestProductOfk except for the fact that here k is 3 and k-1 is 2
                int current = arrayOfInts[i];

                // Do we have a new highest product of 3?
                // It's either the current highest,
                // or the current times the highest product of two
                // or the current times the lowest product of two
                highestProductOf3 = Math.Max(Math.Max(highestProductOf3,
                    current * highestProductOf2),
                    current * lowestProductOf2);

                // Do we have a new highest product of two?
                highestProductOf2 = Math.Max(Math.Max(highestProductOf2,
                    current * highest),
                    current * lowest);

                // Do we have a new lowest product of two?
                lowestProductOf2 = Math.Min(Math.Min(lowestProductOf2,
                    current * highest),
                    current * lowest);
                
                // Do we have a new highest?
                highest = Math.Max(current, highest);

                // Do we have a new lowest?
                lowest = Math.Min(current, lowest);
            }

            return highestProductOf3;
        }

        /// <summary>
        /// Review This code more and become better at it
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="denominations"></param>
        /// <returns></returns>
        public static int ChangePossibilitiesBottomUp(int amount, int[] denominations)
        {
            int[] waysOfDoingNCents = new int[amount + 1];  // Array of zeros from 0..amount
            waysOfDoingNCents[0] = 1;

            foreach (int coin in denominations)
            {
                for (int higherAmount = coin; higherAmount <= amount; higherAmount++)
                {
                    int higherAmountRemainder = higherAmount - coin;
                    waysOfDoingNCents[higherAmount] += waysOfDoingNCents[higherAmountRemainder];
                }
                // The following code is for debugging purposes only and should not be counted towards the solution for the problem
                // We can safely omit or comment the next 5 lines from foreach loop to Console.WriteLine
                foreach (var wayOfDoingCents in waysOfDoingNCents)
                {
                    Console.Write(wayOfDoingCents);
                }
                Console.WriteLine();
            }

            return waysOfDoingNCents[amount];
        }
    }
}
