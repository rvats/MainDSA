﻿using System;
using System.Text.RegularExpressions;

namespace MainDSA.Quizes
{
    public static class String
    {
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

        public static bool IsNum(char a)
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

        public static bool IsSame(char a, char b)
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
    }
}