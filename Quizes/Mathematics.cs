using System;

namespace MainDSA.Quizes
{
    public static class Mathematics
    {
        public static int[][] Multiply(int[][] A, int[][] B)
        {
            //validity check

            int[][] C = new int[A.Length][];
            for(int i = 0; i < B[0].Length; i++)
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
                    if (A[i,k] != 0)
                    {
                        for (int j = 0; j < C.GetUpperBound(1) + 1; j++)
                        {
                            C[i,j] += A[i,k] * B[k,j];
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
