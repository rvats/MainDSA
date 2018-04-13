using System;

namespace MainDSA.Quizes
{
    public static class Mathematics
    {
        public static int SquareRootUsingBinarySearch(int x)
        {
            var res = 0;
            var low = 1;
            var high = x;

            while (low <= high)
            {
                var mid = (high - low) / 2 + low;

                if (mid == x / mid)
                {
                    res = mid;
                    break;
                }
                else if (mid < x / mid)
                {
                    res = mid;
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return res;
        }

        public static int SquareRootUsingNewton(int x)
        {
            if (x <= 1)
            {
                return x;
            }
            var guess = x / 2.0;
            var newGuess = guess / 2.0 + x / (2.0 * guess);
            while (Math.Abs(newGuess - guess) > 0.001)
            {
                guess = newGuess;
                newGuess = guess / 2.0 + x / (2.0 * guess);
            }

            return (int)newGuess;
        }

        public static int[] MaxSumOfThreeSubarrays(int[] nums, int k)
        {
            int n = nums.Length;
            int[] sum = new int[n + 1];
            int[] left = new int[n];
            int[] right = new int[n];
            int[] ret = new int[3];

            // First get the prefix sum of nums.
            // Prefix sum enables us to get the sum of k consecutive element in O(1) time
            for (int i = 0; i < n; i++)
            {
                sum[i + 1] = sum[i] + nums[i];
            }

            // DP for the left intetval max sum
            for (int i = k, tot = sum[k] - sum[0]; i < n; i++)
            {
                if (sum[i + 1] - sum[i - k + 1] > tot)
                {
                    tot = sum[i + 1] - sum[i - k + 1];
                    left[i] = i - k + 1;
                }
                else
                {
                    left[i] = left[i - 1];
                }
            }

            // DP for the right interval max sum
            right[n - k] = n - k;
            for (int i = n - 1 - k, tot = sum[n] - sum[n - k]; i >= 0; i--)
            {
                if (sum[i + k] - sum[i] >= tot)
                {
                    tot = sum[i + k] - sum[i];
                    right[i] = i;
                }
                else
                {
                    right[i] = right[i + 1];
                }
            }

            // Find the max sum by iterating through the middle interval index based on above 2 cache.
            int maxSum = 0;
            for (int i = k; i <= n - 2 * k; i++)
            {
                int l = left[i - 1], r = right[i + k];
                int tot = sum[l + k] - sum[l] + sum[r + k] - sum[r] + sum[i + k] - sum[i];
                if (tot > maxSum)
                {
                    ret[0] = l;
                    ret[1] = i;
                    ret[2] = r;
                    maxSum = tot;
                }
            }

            return ret;
        }

        // Find the maximum possible sum in arr[] 
        // such that arr[m] is part of it
        static int MaxCrossingSum(int[] arr, int l,
                                        int m, int h)
        {
            // Include elements on left of mid.
            int sum = 0;
            int left_sum = int.MinValue;
            for (int i = m; i >= l; i--)
            {
                sum = sum + arr[i];
                if (sum > left_sum)
                    left_sum = sum;
            }

            // Include elements on right of mid
            sum = 0;
            int right_sum = int.MinValue; ;
            for (int i = m + 1; i <= h; i++)
            {
                sum = sum + arr[i];
                if (sum > right_sum)
                    right_sum = sum;
            }

            // Return sum of elements on left
            // and right of mid
            return left_sum + right_sum;
        }

        // Returns sum of maxium sum subarray 
        // in aa[l..h]
        static int MaxSubArraySum(int[] arr, int l,
                                            int h)
        {

            // Base Case: Only one element
            if (l == h)
                return arr[l];

            // Find middle point
            int m = (l + h) / 2;

            /* Return maximum of following three 
            possible cases:
            a) Maximum subarray sum in left half
            b) Maximum subarray sum in right half
            c) Maximum subarray sum such that the 
            subarray crosses the midpoint */
            return Math.Max(Math.Max(MaxSubArraySum(arr, l, m),
                                  MaxSubArraySum(arr, m + 1, h)),
                                 MaxCrossingSum(arr, l, m, h));
        }

        public static int[][] Multiply(int[][] A, int[][] B)
        {
            //validity check

            int[][] C = new int[A.Length][];
            for (int i = 0; i < B[0].Length; i++)
            {
                C[i] = new int[B[0].Length];
            }

            for (int i = 0; i < C.Length; i++)
            {
                for (int j = 0; j < C[0].Length; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < A[0].Length; k++)
                    {
                        sum += A[i][k] * B[k][j];
                    }
                    C[i][j] = sum;
                }
            }

            return C;
        }

        public static int[,] Multiply(int[,] A, int[,] B)
        {
            int[,] C = new int[A.GetUpperBound(0) + 1, B.GetUpperBound(1) + 1];

            // Normal Complete Matrix Multiplication
            //for (int i = 0; i < C.GetUpperBound(0)+1; i++)
            //{
            //    for (int j = 0; j < C.GetUpperBound(1)+1; j++)
            //    {
            //        int sum = 0;
            //        for (int k = 0; k < A.GetUpperBound(1)+1; k++)
            //        {
            //            sum += A[i,k] * B[k,j];
            //        }
            //        C[i,j] = sum;
            //    }
            //}

            for (int i = 0; i < C.GetUpperBound(0) + 1; i++)
            {
                for (int k = 0; k < A.GetUpperBound(1) + 1; k++)
                {
                    //validity check
                    if (A[i, k] != 0)
                    {
                        for (int j = 0; j < C.GetUpperBound(1) + 1; j++)
                        {
                            C[i, j] += A[i, k] * B[k, j];
                        }
                    }
                }
            }

            return C;
        }

        public static int Divide(int dividend, int divisor)
        {
            //handle special cases
            if (divisor == 0) return int.MaxValue;
            if (divisor == -1 && dividend == int.MinValue)
                return int.MaxValue;

            //get positive values
            long pDividend = Math.Abs((long)dividend);
            long pDivisor = Math.Abs((long)divisor);

            int result = 0;
            while (pDividend >= pDivisor)
            {
                //calculate number of left shifts
                int numShift = 0;
                while (pDividend >= (pDivisor << numShift))
                {
                    numShift++;
                }

                //dividend minus the largest shifted divisor
                result += 1 << (numShift - 1);
                pDividend -= (pDivisor << (numShift - 1));
            }

            if ((dividend > 0 && divisor > 0) || (dividend < 0 && divisor < 0))
            {
                return result;
            }
            else
            {
                return -result;
            }
        }

        public static int NthFibonacci(int number)
        {
            // Edge cases:
            if (number < 0)
            {
                throw new ArgumentException("Index was negative. No such thing as a negative index in a series.");
            }

            if (number == 0 || number == 1)
            {
                return number;
            }

            // We'll be building the fibonacci series from the bottom up.
            // So we'll need to track the previous 2 numbers at each step.
            int previousPrevious = 0;  // 0th fibonacci
            int previous = 1;      // 1st fibonacci
            int current = 0;   // Declare and initialize current
            Console.Write("{0}", previous);
            for (int i = 1; i < number; i++)
            {
                // Iteration 1: current = 2nd fibonacci
                // Iteration 2: current = 3rd fibonacci
                // Iteration 3: current = 4th fibonacci
                // To get nth fibonacci ... do n-1 iterations.
                current = previous + previousPrevious;
                previousPrevious = previous;
                previous = current;
                Console.Write(" : {0} ", current);
            }
            Console.WriteLine();
            return current;
        }
    }
}
