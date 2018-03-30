using System;

namespace DemoQuizes
{
    public static class ArrayExtensions
    {
        public static int RemoveDuplicatesAndReturnLength(int [] num)
        {
            /* Handle Empty List First */
            if (num.Length == 0)
            {
                return 0;
            }
            Array.Sort(num);
            int j = 0;
            for(int i = 1; i < num.Length; i++)
            {
                if (num[i] != num[j])
                {
                    num[++j] = num[i];
                }
            }
            for(int i = 0; i <= j; i++)
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
        public static int [] ReturnProductOfRemainingNumbers(int[] array)
        {
            int length = array.Length;
            var productArray = new int[length];

            for(int i = 0; i < length; i++)
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
            if (arrayOfInts.Length < 3)
            {
                throw new ArgumentException("Less than 3 items!", nameof(arrayOfInts));
            }

            // We're going to start at the 3rd item (at index 2)
            // so pre-populate highests and lowests based on the first 2 items.
            // We could also start these as null and check below if they're set
            // but this is arguably cleaner
            int highest = Math.Max(arrayOfInts[0], arrayOfInts[1]);
            int lowest = Math.Min(arrayOfInts[0], arrayOfInts[1]);

            int highestProductOf2 = arrayOfInts[0] * arrayOfInts[1];
            int lowestProductOf2 = arrayOfInts[0] * arrayOfInts[1];

            // Except this one--we pre-populate it for the first *3* items.
            // This means in our first pass it'll check against itself, which is fine.
            int highestProductOf3 = arrayOfInts[0] * arrayOfInts[1] * arrayOfInts[2];

            // Walk through items, starting at index 2
            for (int i = 2; i < arrayOfInts.Length; i++)
            {
                int current = arrayOfInts[i];

                // Do we have a new highest product of 3?
                // It's either the current highest,
                // or the current times the highest product of two
                // or the current times the lowest product of two
                highestProductOf3 = Math.Max(Math.Max(
                    highestProductOf3,
                    current * highestProductOf2),
                    current * lowestProductOf2);

                // Do we have a new highest product of two?
                highestProductOf2 = Math.Max(Math.Max(
                    highestProductOf2,
                    current * highest),
                    current * lowest);

                // Do we have a new lowest product of two?
                lowestProductOf2 = Math.Min(Math.Min(
                    lowestProductOf2,
                    current * highest),
                    current * lowest);

                // Do we have a new highest?
                highest = Math.Max(highest, current);

                // Do we have a new lowest?
                lowest = Math.Min(lowest, current);
            }

            return highestProductOf3;
        }

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
                for(int i = 0; i < amount; i++)
                {
                    Console.Write(waysOfDoingNCents[i]);
                }
                Console.WriteLine();
            }

            return waysOfDoingNCents[amount];
        }
    }
}
