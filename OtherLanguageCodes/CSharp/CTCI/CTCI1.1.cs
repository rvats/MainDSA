/***********************************************************************************************************
Author: Rahul Vats (https://github.com/rvats/MainDSA)
Cracking The Coding Interview Solutions 
Edition 6 - 1.1 Interview Questions Is Unique
***********************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Demo
{
    class Program
    {
        private static int counter = 0;
        private static string strData1 = "abcdefghijklmnopqrstuvwxyz";
        private static string strData2 = "aquickbrownfxjumpsoverthelazydog";

        static void Main(string[] args)
        {
            Solution s = new Solution();
            // This is not accurate and I am not recommending the strategy. This was for some fun and numbers that I was interested in looking.
            var watch = Stopwatch.StartNew();
            // the code that you want to measure comes here
            var result = s.HasUniqueCharactersBruteForce(strData1);
            s.DisplayResult(result, ++counter);
            result = s.HasUniqueCharactersBruteForce(strData2);
            s.DisplayResult(result, ++counter);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine(elapsedMs);

            watch = Stopwatch.StartNew();
            result = s.HasUniqueCharactersSorting(strData1);
            s.DisplayResult(result, ++counter);
            result = s.HasUniqueCharactersSorting(strData2);
            s.DisplayResult(result, ++counter);
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine(elapsedMs);

            watch = Stopwatch.StartNew();
            result = s.HasUniqueCharactersBoolArray(strData1);
            s.DisplayResult(result, ++counter);
            result = s.HasUniqueCharactersBoolArray(strData2);
            s.DisplayResult(result, ++counter);
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine(elapsedMs);

            watch = Stopwatch.StartNew();
            result = s.HasUniqueCharactersHashSet(strData1);
            s.DisplayResult(result, ++counter);
            result = s.HasUniqueCharactersHashSet(strData2);
            s.DisplayResult(result, ++counter);
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine(elapsedMs);
        }
    }

    class Solution
    {
        /// <summary>
        /// Approach 1 – Brute Force technique
        /// Simple Brute Force Approach With O(N^2) Complexity
        /// </summary>
        /// <param name="strData"></param>
        /// <returns></returns>
        public bool HasUniqueCharactersBruteForce(string strData)
        {
            for (int i = 0; i < strData.Length; i++)
            {
                for (int j = i + 1; j < strData.Length; j++)
                {
                    if (strData[i] == strData[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Approach 2 – Sorting: Using sorting based on ASCII values of characters
        /// Simple Algorithm By Sorting The Array which takes O(NlogN) Complexity
        /// </summary>
        /// <param name="strData"></param>
        /// <returns></returns>
        public bool HasUniqueCharactersSorting(String strData)
        {
            char[] chArray = strData.ToCharArray();
            Array.Sort(chArray);

            for (int i = 0; i < chArray.Length - 1; i++)
            {
                if (chArray[i] == chArray[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Approach 3 – Use of Extra Data Structure boolean array
        /// Time Complexity: O(n)
        /// </summary>
        /// <param name="strData"></param>
        /// <returns></returns>
        public bool HasUniqueCharactersBoolArray(String strData)
        {
            int charSize = 256;
            if (strData.Length > charSize)
            {
                return false;
            }
            bool[] chars = new bool[charSize];
            // Arrays.fill(chars, false); In C# we have to create a library to have a fill extension method. 
            // Not Really Needed for this Method
            for (int i = 0; i < strData.Length; i++)
            {
                int index = strData[i];
                if (chars[index] == true)
                {
                    return false;
                }
                chars[index] = true;
            }
            return true;
        }

        /// <summary>
        /// Approach 3 – Use of Extra Data Structure HashSet
        /// Time Complexity: O(n)
        /// </summary>
        /// <param name="strData"></param>
        /// <returns></returns>
        public bool HasUniqueCharactersHashSet(String strData)
        {
            HashSet<char> mapCharactersInStringData = new HashSet<char>();
            mapCharactersInStringData.Add(strData[0]);
            for (int i = 1; i < strData.Length; i++)
            {
                if (mapCharactersInStringData.Contains(strData[i]))
                {
                    return false;
                }
                else
                {
                    mapCharactersInStringData.Add(strData[i]);
                }
            }
            return true;
        }

        /// <summary>
        /// Helper Method To Display The Result
        /// </summary>
        /// <param name="result"></param>
        /// <param name="counter"></param>
        public void DisplayResult(bool result, int counter)
        {
            Console.WriteLine("Test Case: {0}", counter);
            Console.WriteLine(result);
            Console.WriteLine("================================================");
        }
    }
}