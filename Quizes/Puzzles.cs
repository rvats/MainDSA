using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainDSA.Quizes
{
    public class Puzzles
    {
        /// <summary>
        /// 639. Decode Ways II
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int NumDecodings(string s)
        {
            long[] res = new long[2];
            res[0] = Ways(s[0]);
            if (s.Length < 2) return (int)res[0];

            res[1] = res[0] * Ways(s[1]) + Ways(s[0], s[1]);
            for (int j = 2; j < s.Length; j++)
            {
                long temp = res[1];
                res[1] = (res[1] * Ways(s[j]) + res[0] * Ways(s[j - 1], s[j])) % 1000000007;
                res[0] = temp;
            }
            return (int)res[1];
        }

        /// <summary>
        /// 639. Decode Ways II
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
        private int Ways(int ch)
        {
            if (ch == '*') return 9;
            if (ch == '0') return 0;
            return 1;
        }

        /// <summary>
        /// 639. Decode Ways II
        /// </summary>
        /// <param name="ch1"></param>
        /// <param name="ch2"></param>
        /// <returns></returns>
        private int Ways(char ch1, char ch2)
        {
            string str = "" + ch1 + "" + ch2;
            if (ch1 != '*' && ch2 != '*')
            {
                if (int.Parse(str) >= 10 && int.Parse(str) <= 26)
                    return 1;
            }
            else if (ch1 == '*' && ch2 == '*')
            {
                return 15;
            }
            else if (ch1 == '*')
            {
                if (int.Parse("" + ch2) >= 0 && int.Parse("" + ch2) <= 6)
                    return 2;
                else
                    return 1;
            }
            else
            {
                if (int.Parse("" + ch1) == 1)
                {
                    return 9;
                }
                else if (int.Parse("" + ch1) == 2)
                {
                    return 6;
                }
            }
            return 0;
        }

        /// <summary>
        /// 636. Exclusive Time of Functions
        /// </summary>
        /// <param name="n"></param>
        /// <param name="logs"></param>
        /// <returns></returns>
        public int[] ExclusiveTime(int n, IList<string> logs)
        {
            Stack<int> stack = new Stack<int>();
            int[] res = new int[n];
            string[] s = logs[0].Split(':');
            stack.Push(int.Parse(s[0]));
            int i = 1, prev = int.Parse(s[2]);
            while (i < logs.Count)
            {
                s = logs[i].Split(':');
                if (s[1].Equals("start"))
                {
                    if (stack.Count != 0)
                        res[stack.Peek()] += int.Parse(s[2]) - prev;
                    stack.Push(int.Parse(s[0]));
                    prev = int.Parse(s[2]);
                }
                else
                {
                    res[stack.Peek()] += int.Parse(s[2]) - prev + 1;
                    stack.Pop();
                    prev = int.Parse(s[2]) + 1;
                }
                i++;
            }
            return res;
        }

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

        /// <summary>
        /// H-Index and H-Index II solution. No need to sort the array if array is already sorted.
        /// </summary>
        /// <param name="citations"></param>
        /// <returns></returns>
        public int HIndex(int[] citations)
        {
            Array.Sort(citations);

            int result = 0;
            for (int i = 0; i < citations.Length; i++)
            {
                int smaller = Math.Min(citations[i], citations.Length - i);
                result = Math.Max(result, smaller);
            }

            return result;
        }

        public void WallsAndGates(int[,] rooms)
        {
            if (rooms == null || rooms.GetUpperBound(0) == 0 || rooms.GetUpperBound(1) == 0)
                return;

            int m = rooms.GetUpperBound(0);
            int n = rooms.GetUpperBound(1);

            bool[,] visited = new bool[m+1, n+1];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (rooms[i, j] == 0)
                    {
                        Fill(rooms, i - 1, j, 0, visited);
                        Fill(rooms, i, j + 1, 0, visited);
                        Fill(rooms, i + 1, j, 0, visited);
                        Fill(rooms, i, j - 1, 0, visited);
                        visited = new bool[m, n];
                    }
                }
            }
        }

        public void Fill(int[,] rooms, int i, int j, int start, bool[,] visited)
        {
            int m = rooms.GetUpperBound(0);
            int n = rooms.GetUpperBound(1);

            if (i < 0 || i >= m || j < 0 || j >= n || rooms[i, j] <= 0 || visited[i, j])
            {
                return;
            }

            rooms[i, j] = Math.Min(rooms[i, j], start + 1);
            visited[i, j] = true;

            Fill(rooms, i - 1, j, start + 1, visited);
            Fill(rooms, i, j + 1, start + 1, visited);
            Fill(rooms, i + 1, j, start + 1, visited);
            Fill(rooms, i, j - 1, start + 1, visited);

            visited[i, j] = false;
        }
    }
}
