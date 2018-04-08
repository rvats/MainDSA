using System;
using System.Collections.Generic;
using System.Text;

namespace MainDSA.Quizes
{
    public class Puzzles
    {
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
            foreach(char c in tasks)
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
    }
}
