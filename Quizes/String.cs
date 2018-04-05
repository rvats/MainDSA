using System.Text.RegularExpressions;

namespace MainDSA.Quizes
{
    public static class String
    {
        public static bool IsPalindromeUponDeletingAtMost1Character(string str)
        {
            bool result = true;
            bool flag1CharDeleted = false;
            int i = 0, j = str.Length - 1;
            while (i < j)
            {
                if (char.ToLowerInvariant(str[i]) != char.ToLowerInvariant(str[j - i]))
                {
                    if (!flag1CharDeleted)
                    {
                        flag1CharDeleted = true;
                        if (char.ToLowerInvariant(str[i]) == char.ToLowerInvariant(str[j - i - 1]))
                        {
                            j--;
                        }
                        else if (char.ToLowerInvariant(str[i + 1]) == char.ToLowerInvariant(str[j - i]))
                        {
                            i++;
                        }
                        if (char.ToLowerInvariant(str[i]) != char.ToLowerInvariant(str[j - i - 1]))
                        {
                            result = false; break;
                        }
                    }
                    else
                    {
                        result = false; break;
                    }
                }

                i++; j--;
            }
            return result;
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
