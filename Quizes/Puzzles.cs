﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MainDSA.Quizes
{
    public class Puzzles
    {
        private Dictionary<char, IList> phonenumber = new Dictionary<char, IList>
        {
            {'0', new List<char>()},
            {'1', new List<char>()},
            {'2', new List<char>() {'a', 'b', 'c'}},
            {'3', new List<char>() {'d', 'e', 'f'}},
            {'4', new List<char>() {'g', 'h', 'i'}},
            {'5', new List<char>() {'j', 'k', 'l'}},
            {'6', new List<char>() {'m', 'n', 'o'}},
            {'7', new List<char>() {'p', 'q', 'r', 's'}},
            {'8', new List<char>() {'t', 'u', 'v'}},
            {'9', new List<char>() {'w', 'x', 'y', 'z'}}
        };
        private List<string> resultString = new List<string>();
        public IList<string> LetterCombinations(string digits)
        {
            LetterCombinationsHelper(digits, 0, new StringBuilder());

            return resultString;
        }

        private void LetterCombinationsHelper(string digits, int i, StringBuilder result)
        {
            if (i >= digits.Length)
            {
                if (result.Length > 0)
                {
                    resultString.Add(result.ToString());
                }
                return;
            }

            var cur = phonenumber[digits[i]];
            foreach (var letter in cur)
            {
                result.Append(letter);
                LetterCombinationsHelper(digits, i + 1, result);
                result.Remove(result.Length - 1, 1);
            }
        }

        public IList<string> LetterCombinationsSimple(string digits)
        {
            Dictionary<int, string> map = new Dictionary<int, string>();
            map.Add(2, "abc");
            map.Add(3, "def");
            map.Add(4, "ghi");
            map.Add(5, "jkl");
            map.Add(6, "mno");
            map.Add(7, "pqrs");
            map.Add(8, "tuv");
            map.Add(9, "wxyz");
            map.Add(0, "");

            List<string> result = new List<string>();

            if (digits == null || digits.Length == 0)
                return result;

            List<char> temp = new List<char>();
            GetString(digits, temp, result, map);

            return result;
        }

        public void GetString(string digits, List<char> temp, List<string> result, Dictionary<int, string> map)
        {
            if (digits.Length == 0)
            {
                char[] arr = new char[temp.Count];
                for (int i = 0; i < temp.Count; i++)
                {
                    arr[i] = temp[i];
                }
                result.Add(new string(arr));
                return;
            }

            int curr = int.Parse(digits.Substring(0, 1));
            string letters = map[curr];
            for (int i = 0; i < letters.Length; i++)
            {
                temp.Add(letters[i]);
                GetString(digits.Substring(1, digits.Length - 1), temp, result, map);
                temp.Remove(temp[temp.Count - 1]);
            }
        }

        // Person with 2 is celebrity
        private int[,] Matrix = new int[4, 4] { { 0, 0, 1, 0 },
                              { 0, 0, 1, 0 },
                              { 0, 0, 0, 0 },
                              { 0, 0, 1, 0 } };

        // Returns true if a knows b, false otherwise
        private bool Knows(int a, int b)
        {
            bool res = (Matrix[a, b] == 1) ? true : false;
            return res;
        }
        public int FindCelebrity(int n)
        {
            Stack<int> stack = new Stack<int>();
            int celebrity;

            // Step 1 :Push everybody onto stack
            for (int i = 0; i < n; i++)
            {
                stack.Push(i);
            }

            while (stack.Count > 1)
            {
                // Step 2 :Pop off top two persons from the 
                // stack, discard one person based on return
                // status of knows(A, B).
                int a = stack.Pop();
                int b = stack.Pop();

                // Step 3 : Push the remained person onto stack.
                if (Knows(a, b))
                {
                    stack.Push(b);
                }
                else
                {
                    stack.Push(a);
                }
            }
            celebrity = stack.Pop();

            // Step 5 : Check if the last person is 
            // celebrity or not
            for (int i = 0; i < n; i++)
            {
                // If any person doesn't know 'c' or 'a'
                // doesn't know any person, return -1
                if (i != celebrity && (Knows(celebrity, i) || !Knows(i, celebrity)))
                    return -1;
            }
            return celebrity;
        }

        public int LeastInterval(char[] tasks, int n)
        {
            int[] map = new int[26];
            foreach (char c in tasks)
                map[c - 'A']++;
            Array.Sort(map);
            int time = 0;
            while (map[25] > 0)
            {
                int i = 0;
                while (i <= n)
                {
                    if (map[25] == 0)
                        break;
                    if (i < 26 && map[25 - i] > 0)
                        map[25 - i]--;
                    time++;
                    i++;
                }
                Array.Sort(map);
            }
            return time;
        }

        Dictionary<int, string> map = new Dictionary<int, string>();

        public string NumberToWords(int num)
        {
            FillMap();
            StringBuilder sb = new StringBuilder();

            if (num == 0)
            {
                return map[0];
            }

            if (num >= 1000000000)
            {
                int extra = num / 1000000000;
                sb.Append(Convert(extra) + " Billion");
                num = num % 1000000000;
            }

            if (num >= 1000000)
            {
                int extra = num / 1000000;
                sb.Append(Convert(extra) + " Million");
                num = num % 1000000;
            }

            if (num >= 1000)
            {
                int extra = num / 1000;
                sb.Append(Convert(extra) + " Thousand");
                num = num % 1000;
            }

            if (num > 0)
            {
                sb.Append(Convert(num));
            }

            return sb.ToString().Trim();
        }

        public string Convert(int num)
        {

            StringBuilder sb = new StringBuilder();

            if (num >= 100)
            {
                int numHundred = num / 100;
                sb.Append(" " + map[numHundred] + " Hundred");
                num = num % 100;
            }

            if (num > 0)
            {
                if (num > 0 && num <= 20)
                {
                    sb.Append(" " + map[num]);
                }
                else
                {
                    int numTen = num / 10;
                    sb.Append(" " + map[numTen * 10]);

                    int numOne = num % 10;
                    if (numOne > 0)
                    {
                        sb.Append(" " + map[numOne]);
                    }
                }
            }

            return sb.ToString();
        }

        public void FillMap()
        {
            map.Add(0, "Zero");
            map.Add(1, "One");
            map.Add(2, "Two");
            map.Add(3, "Three");
            map.Add(4, "Four");
            map.Add(5, "Five");
            map.Add(6, "Six");
            map.Add(7, "Seven");
            map.Add(8, "Eight");
            map.Add(9, "Nine");
            map.Add(10, "Ten");
            map.Add(11, "Eleven");
            map.Add(12, "Twelve");
            map.Add(13, "Thirteen");
            map.Add(14, "Fourteen");
            map.Add(15, "Fifteen");
            map.Add(16, "Sixteen");
            map.Add(17, "Seventeen");
            map.Add(18, "Eighteen");
            map.Add(19, "Nineteen");
            map.Add(20, "Twenty");
            map.Add(30, "Thirty");
            map.Add(40, "Forty");
            map.Add(50, "Fifty");
            map.Add(60, "Sixty");
            map.Add(70, "Seventy");
            map.Add(80, "Eighty");
            map.Add(90, "Ninety");
        }

        public int MaximalRectangle(char[,] matrix)
        {
            var res = 0;
            var row = matrix.GetLength(0);
            var column = matrix.GetLength(1);

            var left = new int[column];
            var right = Enumerable.Repeat(column, column).ToArray();
            var heights = new int[column];
            for (int i = 0; i < row; i++)
            {
                var curleft = 0;
                var curright = column;
                for (int j = 0; j < column; j++)
                {
                    if (matrix[i, j] == '0')
                    {
                        heights[j] = 0;
                    }
                    else
                    {
                        heights[j]++;
                    }
                    if (matrix[i, j] == '0')
                    {
                        left[j] = 0;
                        curleft = j + 1;
                    }
                    else
                    {
                        left[j] = Math.Max(left[j], curleft);
                    }
                }
                for (int j = column - 1; j >= 0; j--)
                {
                    if (matrix[i, j] == '0')
                    {
                        right[j] = column;
                        curright = j;
                    }
                    else
                    {
                        right[j] = Math.Min(right[j], curright);
                    }
                }

                for (int j = 0; j < column; j++)
                {
                    res = Math.Max(res, heights[j] * (right[j] - left[j]));
                }
            }

            return res;
        }
    }
}
