using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MainDSA.Quizes
{
    public static class String
    {
        public static string MinWindow(string s, string t)
        {
            var dict = new Dictionary<char, int>();
            for (int i = 0; i < t.Length; i++)
            {
                if (dict.ContainsKey(t[i]))
                {
                    dict[t[i]]++;
                }
                else
                {
                    dict.Add(t[i], 1);
                }
            }

            var res = string.Empty;
            var len = s.Length + 1;
            var start = 0;
            var count = t.Length;
            for (int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i]))
                {
                    if (dict[s[i]]-- > 0)
                    {
                        count--;
                    }
                }

                while (count == 0)
                {
                    if (len > i - start + 1)
                    {
                        len = i - start + 1;
                        res = s.Substring(start, len);
                    }

                    if (dict.ContainsKey(s[start]))
                    {
                        if (dict[s[start]]++ >= 0)
                        {
                            count++;
                        }
                    }

                    start++;
                }
            }

            return res;
        }

        public static List<List<int>> PalindromePairs(string[] words)
        {
            List<List<int>> result = new List<List<int>>();

            Dictionary<string, int> map = new Dictionary<string, int>();
            for (int i = 0; i < words.Length; i++)
            {
                map.Add(words[i], i);
            }

            for (int i = 0; i < words.Length; i++)
            {
                string strCurrent = words[i];

                //if the word is a palindrome, get index of ""
                if (IsPalindrome(strCurrent))
                {
                    if (map.ContainsKey(""))
                    {
                        if (map[""] != i)
                        {
                            List<int> tempList = new List<int>();
                            tempList.Add(i);
                            tempList.Add(map[""]);
                            result.Add(tempList);

                            tempList = new List<int>();

                            tempList.Add(map[""]);
                            tempList.Add(i);
                            result.Add(tempList);
                        }
                    }
                }

                //if the reversed word exists, it is a palindrome
                var charArrayCurrentReverse = strCurrent.ToCharArray();
                Array.Reverse(charArrayCurrentReverse);
                string reversed = new string(charArrayCurrentReverse);
                if (map.ContainsKey(reversed))
                {
                    if (map[reversed] != i)
                    {
                        List<int> tempList = new List<int>();
                        tempList.Add(i);
                        tempList.Add(map[reversed]);
                        result.Add(tempList);
                    }
                }

                for (int k = 1; k < strCurrent.Length; k++)
                {
                    string left = strCurrent.Substring(0, k);
                    string right = strCurrent.Substring(k);

                    //if left part is palindrome, find reversed right part
                    if (IsPalindrome(left))
                    {
                        var charArrayRight = right.ToCharArray();
                        Array.Reverse(charArrayRight);
                        string reversedRight = new string(charArrayRight);

                        if (map.ContainsKey(reversedRight))
                        {
                            if (map[reversedRight] != i)
                            {
                                List<int> tempList = new List<int>();
                                tempList.Add(map[reversedRight]);
                                tempList.Add(i);
                                result.Add(tempList);
                            }
                        }
                    }

                    //if right part is a palindrome, find reversed left part
                    if (IsPalindrome(right))
                    {
                        var charArrayLeft = left.ToCharArray();
                        Array.Reverse(charArrayLeft);
                        string reversedLeft = new string(charArrayLeft);

                        if (map.ContainsKey(reversedLeft))
                        {
                            if (map[reversedLeft] != i)
                            {

                                List<int> tempList = new List<int>();
                                tempList.Add(i);
                                tempList.Add(map[reversedLeft]);
                                result.Add(tempList);
                            }
                        }
                    }
                }
            }

            return result;
        }

        public static bool IsPalindrome(string strData)
        {
            char[] arrData = strData.ToCharArray();
            Array.Reverse(arrData);
            string strReverseData = new string(arrData);
            return (string.Equals(strData, strReverseData));
        }

        // This method returns -1 if it is not possible to make string
        // a palindrome. It returns -2 if string is already a palindrome.
        // Otherwise it returns index of character whose removal can
        // make the whole string palindrome.
        public static int PossiblePalindromeByRemovingOneChar(string strData)
        {
            int strDataLength = strData.Length;
            //  Initialize low and right by both the ends of the string
            int low = 0, high = strData.Length - 1;

            //  loop untill low and high cross each other
            while (low < high)
            {
                // If both characters are equal then move both pointer
                // towards end
                if (strData[low] == strData[high])
                {
                    low++;
                    high--;
                }
                else
                {
                    /*  If removing str[low] makes the whole string palindrome.
                        We basically check if substring str[low+1..high] is
                        palindrome or not. */
                    if (IsPalindrome(strData.Remove(0, low + 1).Remove(high - low, strDataLength - (high + 1))))
                    {
                        return low;
                    }

                    /*  If removing str[high] makes the whole string palindrome
                        We basically check if substring str[low+1..high] is
                        palindrome or not. */
                    if (IsPalindrome(strData.Remove(0, low).Remove(high - low, strDataLength - high)))
                    {
                        return high;
                    }

                    return -1;
                }
            }

            //  We reach here when complete string will be palindrome
            //  if complete string is palindrome then return mid character
            return -2;
        }

        public static bool IsPalindromeUponDeletingAtMost1Character(string s)
        {
            if (PossiblePalindromeByRemovingOneChar(s)==-1)
            {
                return false;
            }
            return true;
        }

        public static bool IsPalindromeUsingRegex(string s)
        {
            bool result = true;
            string str = Regex.Replace(s, "[^a-zA-Z0-9_]+", "");

            for (int i = 0; i < str.Length; i++)
            {
                if (char.ToLowerInvariant(str[i]) != char.ToLowerInvariant(str[str.Length - 1 - i]))
                {
                    result = false; break;
                }
            }
            return result;
        }

        public static bool IsPalindromeWithoutUsingRegex(string s)
        {

            if (s == null) return false;
            if (s.Length < 2) return true;

            char[] charArray = s.ToCharArray();
            int len = s.Length;

            int i = 0;
            int j = len - 1;

            while (i < j)
            {
                char left = charArray[i], right = charArray[j];

                while (i < len - 1 && !IsAlpha(left) && !IsNum(left))
                {
                    i++;
                    left = charArray[i];
                }

                while (j > 0 && !IsAlpha(right) && !IsNum(right))
                {
                    j--;
                    right = charArray[j];
                }

                if (i >= j)
                    break;

                left = charArray[i];
                right = charArray[j];

                if (!IsSame(left, right))
                {
                    return false;
                }

                i++;
                j--;
            }
            return true;
        }

        public static bool IsAlpha(char a)
        {
            if ((a >= 'a' && a <= 'z') || (a >= 'A' && a <= 'Z'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool IsNum(char a)
        {
            if (a >= '0' && a <= '9')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool IsSame(char a, char b)
        {
            if (IsNum(a) && IsNum(b))
            {
                return a == b;
            }
            else if (char.ToLowerInvariant(a) == char.ToLowerInvariant(b))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsNumber(string s)
        {
            int i = 0;
            int n = s.Length;

            // step 1: skip leading white spaces
            while (i < n && s[i] == ' ')
            {
                i++;
            }

            // step 2: Skip + or - sign
            if (i < n && (s[i] == '+' || s[i] == '-'))
            {
                i++;
            }

            bool isNumeric = false;
            // step 3: skip the first segement of numeric characters
            while (i < n && IsNum(s[i]))
            {
                i++;
                isNumeric = true;
            }

            // step 4 and 5 skip the . character and the following numeric characters, if any
            if (i < n && s[i] == '.')
            {
                i++;
                while (i < n && IsNum(s[i]))
                {
                    i++;
                    isNumeric = true;
                }
            }

            // step 6 and 7 and 8, exponent character and following numeric characters
            if (isNumeric && i < n && (s[i] == 'e' || s[i] == 'E'))
            {
                i++;
                isNumeric = false;
                if (i < n && (s[i] == '+' || s[i] == '-'))
                {
                    i++;
                }
                while (i < n && IsNum(s[i]))
                {
                    i++;
                    isNumeric = true;
                }
            }
            // step 9: Remove trailing white spaces
            while (i < n && s[i] == ' ')
            {
                i++;
            }

            return isNumeric && i == n;
        }

        public static bool IsNumber2(string s)
        {
            bool result = false;
            double number;
            int power;
            result = double.TryParse(s, out number);
            if (result)
            {
                return result;
            }
            if (s.Contains("e"))
            {
                var numbers = s.Split('e');
                if (numbers.Length == 2)
                {
                    result = double.TryParse(numbers[0], out number);
                    if (result)
                    {
                        result = int.TryParse(numbers[1], out power);
                    }
                }
            }
            return result;
        }

        public static bool IsDouble(string s)
        {
            bool result = false;
            double number;
            result = double.TryParse(s, out number);
            if (result)
            {
                return result;
            }
            if (s.Contains("e"))
            {
                var numbers = s.Split('e');
                if (numbers.Length == 2)
                {
                    result = double.TryParse(numbers[0], out number);
                    if (result)
                    {
                        result = double.TryParse(numbers[1], out number);
                    }
                }
            }
            return result;
        }

        public static bool IsValidSetOfParenthesis(string s)
        {
            Dictionary<char, char> mapParenthesis = new Dictionary<char, char>();
            mapParenthesis.Add('(', ')');
            mapParenthesis.Add('[', ']');
            mapParenthesis.Add('{', '}');
            mapParenthesis.Add('<', '>');

            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                char current = s[i];
                if (mapParenthesis.ContainsKey(current))
                {
                    stack.Push(current);
                }
                else if (mapParenthesis.ContainsValue(current))
                {
                    if (stack.Count!=0 && mapParenthesis[stack.Peek()] == current)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return stack.Count==0;
        }
    }
}
