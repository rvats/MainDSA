using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MainDSA.Quizes
{
    public static class String
    {
        /// <summary>
        /// 1.6 String Compression: Implement Basic compression using count of repeated consecutive characters
        /// </summary>
        /// <param name="strData"></param>
        /// <returns></returns>
        public static string Compress(string strData)
        {
            StringBuilder compressed = new StringBuilder();
            int countConsecutive = 0;
            for(int i = 0; i < strData.Length; i++)
            {
                countConsecutive++;

                if(i+1>=strData.Length || (strData[i] != strData[i + 1]))
                {
                    compressed.Append(strData[i]);
                    compressed.Append(countConsecutive);
                    countConsecutive = 0;
                }
            }
            return (compressed.Length>=strData.Length) ? strData: compressed.ToString();
        }

        /// <summary>
        /// 1.6 String Compression: Get Compressed String Length
        /// </summary>
        /// <param name="strData"></param>
        /// <returns></returns>
        public static int CompressProspectLength(string strData)
        {
            int compressLength = 0;
            int countConsecutive = 0;
            for (int i = 0; i < strData.Length; i++)
            {
                countConsecutive++;

                if (i + 1 >= strData.Length || (strData[i] != strData[i + 1]))
                {
                    compressLength += countConsecutive.ToString().Length + 1;
                    countConsecutive = 0;
                }
            }
            return compressLength;
        }

        /// <summary>
        /// 1.5 One Edit Away: There are three types of edits that can be performed: Insert, Remove Or Replace
        /// </summary>
        /// <returns></returns>
        public static bool OneEditAway(string first, string second)
        {
            if (Math.Abs(first.Length - second.Length) > 1)
            {
                return false;
            }

            var string1 = first.Length < second.Length ? first : second;
            var string2 = first.Length < second.Length ? second : first;

            int index1 = 0, index2 = 0;
            bool foundDifference = false;

            while(index2<string2.Length && index1 < string1.Length)
            {
                if (string1[index1] != string2[index2])
                {
                    if (foundDifference) return false;
                    foundDifference = true;

                    if (string1.Length == string2.Length)
                    {
                        index1++;
                    }
                }
                else
                {
                    index1++;
                }
                index2++;
            }
            return true;
        }

        /// <summary>
        /// 1.4 Palindrome Permutation 
        /// </summary>
        /// <param name="phrase"></param>
        /// <returns></returns>
        public static bool IsPermutationOfPalindrome(string phrase)
        {
            //Assumption palindrome is case insensitive
            phrase = phrase.ToLower();
            Dictionary<char, int> mapCharInPhraseCount = new Dictionary<char, int>();
            // For string to be a palindrome not more than one character can have odd count
            int charWithOddCount = 0;
            //Add every character count to dictionary and update the value of charWithOddCount
            foreach (var character in phrase.ToCharArray())
            {
                if (mapCharInPhraseCount.ContainsKey(character))
                {
                    mapCharInPhraseCount[character]++;
                }
                else
                {
                    mapCharInPhraseCount.Add(character, 1);
                }
                if (mapCharInPhraseCount[character] % 2 == 1)
                {
                    charWithOddCount++;
                }
                else
                {
                    charWithOddCount--;
                }
            }
            
            if (charWithOddCount > 1)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 1.3 URLify: Write a method to replace all spaces in a string with %20
        /// </summary>
        public static void Urlify()
        {

        }

        /// <summary>
        /// 1.2 Check Permutation: Given Two strings write a method to decide if one is a permutation of the other.
        /// </summary>
        /// <param name="strData1"></param>
        /// <param name="strData2"></param>
        /// <returns></returns>
        public static bool CheckIfStringsArePermutationOfEachOther(string strData1, string strData2)
        {
            if (strData1.Length != strData2.Length)
            {
                return false;
            }

            var strDataChar1 = strData1.ToCharArray();
            var strDataChar2 = strData2.ToCharArray();

            Array.Sort(strDataChar1);
            Array.Sort(strDataChar2);

            return string.Equals(new string(strDataChar1), new string(strDataChar2));
        }

        /// <summary>
        /// 38. Count and Say
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string CountAndSay(int n)
        {
            if (n <= 0)
                return null;

            string result = "1";
            int i = 1;

            while (i < n)
            {
                StringBuilder sb = new StringBuilder();
                int count = 1;
                for (int j = 1; j < result.Length; j++)
                {
                    if (result[j] == result[j - 1])
                    {
                        count++;
                    }
                    else
                    {
                        sb.Append(count);
                        sb.Append(result[j - 1]);
                        count = 1;
                    }
                }

                sb.Append(count);
                sb.Append(result[result.Length - 1]);
                result = sb.ToString();
                i++;
            }

            return result;
        }

        /// <summary>
        /// 161. One Edit Distance
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsOneEditDistance(string s, string t)
        {
            if (s == null || t == null)
                return false;

            int m = s.Length;
            int n = t.Length;

            if (Math.Abs(m - n) > 1)
            {
                return false;
            }

            int i = 0;
            int j = 0;
            int count = 0;

            while (i < m && j < n)
            {
                if (s[i] == t[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    count++;
                    if (count > 1)
                        return false;

                    if (m > n)
                    {
                        i++;
                    }
                    else if (m < n)
                    {
                        j++;
                    }
                    else
                    {
                        i++;
                        j++;
                    }
                }
            }

            if (i < m || j < n)
            {
                count++;
            }

            if (count == 1)
                return true;

            return false;
        }

        /// <summary>
        /// 6. ZigZag Conversion
        /// </summary>
        /// <param name="s"></param>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public static string Convert(string s, int numRows)
        {
            if (numRows == 1)
                return s;

            StringBuilder sb = new StringBuilder();
            // step
            int step = 2 * numRows - 2;

            for (int i = 0; i < numRows; i++)
            {
                //first & last rows
                if (i == 0 || i == numRows - 1)
                {
                    for (int j = i; j < s.Length; j = j + step)
                    {
                        sb.Append(s[j]);
                    }
                    //middle rows	
                }
                else
                {
                    int j = i;
                    bool flag = true;
                    int step1 = 2 * (numRows - 1 - i);
                    int step2 = step - step1;

                    while (j < s.Length)
                    {
                        sb.Append(s[j]);
                        if (flag)
                            j = j + step1;
                        else
                            j = j + step2;
                        flag = !flag;
                    }
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// 5. Longest Palindromic Substring - Incorrect solution
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string LongestPalindrome(string s)
        {
            if (s.Length == 0)
            {
                return null;
            }

            if (s.Length == 1)
            {
                return s;
            }

            string longest = s.Substring(0, 1);
            for (int i = 0; i < s.Length-1; i++)
            {
                // get longest palindrome with center of i
                string tmp = Helper(s, i, i);
                if (tmp.Length > longest.Length)
                {
                    longest = tmp;
                }

                // get longest palindrome with center of i, i+1
                tmp = Helper(s, i, i + 1);
                if (tmp.Length > longest.Length)
                {
                    longest = tmp;
                }
            }

            return longest;
        }

        // Given a center, either one letter or two letter, 
        // Find longest palindrome
        /// <summary>
        /// 5. Longest Palindromic Substring
        /// </summary>
        /// <param name="s"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static string Helper(string s, int begin, int end)
        {
            while (begin >= 0 && end < s.Length - 1 && s[begin] == s[end])
            {
                begin--;
                end++;
            }
            return s.Substring(begin + 1, end - begin-1);
        }

        /// <summary>
        /// 3. Longest Substring Without Repeating Characters
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int LengthOfLongestSubstring(string s)
        {
            if (s == null || s.Length == 0)
            {
                return 0;
            }
            int result = 0;
            int k = 0;
            HashSet<char> set = new HashSet<char>();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (!set.Contains(c))
                {
                    set.Add(c);
                    result = Math.Max(result, set.Count);
                }
                else
                {
                    while (k < i)
                    {
                        if (s[k] == c)
                        {
                            k++;
                            break;
                        }
                        else
                        {
                            set.Remove(s[k]);
                            k++;
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 127. Word Ladder
        /// </summary>
        /// <param name="beginWord"></param>
        /// <param name="endWord"></param>
        /// <param name="wordList"></param>
        /// <returns></returns>
        public static int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            HashSet<string> dict = new HashSet<string>();
            foreach (string word in wordList)
            {
                dict.Add(word);
            }

            if (!dict.Contains(endWord)) return 0;

            Queue<string> q = new Queue<string>();
            q.Enqueue(beginWord);

            int l = beginWord.Length;
            int steps = 0;

            while (q.Count!=0)
            {
                ++steps;
                for (int s = q.Count; s > 0; --s)
                {
                    string w = q.Dequeue();
                    char[] chs = w.ToCharArray();
                    for (int i = 0; i < l; ++i)
                    {
                        char ch = chs[i];
                        for (char c = 'a'; c <= 'z'; ++c)
                        {
                            if (c == ch) continue;
                            chs[i] = c;
                            string t = new string(chs);
                            if (t.Equals(endWord)) return steps + 1;
                            if (!dict.Contains(t)) continue;
                            dict.Remove(t);
                            q.Enqueue(t);
                        }
                        chs[i] = ch;
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// Solution To 14. Longest Common Prefix
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return "";
            }

            if (strs.Length == 1)
                return strs[0];

            int minLen = strs.Length + 1;

            foreach (string str in strs)
            {
                if (minLen > str.Length)
                {
                    minLen = str.Length;
                }
            }

            for (int i = 0; i < minLen; i++)
            {
                for (int j = 0; j < strs.Length - 1; j++)
                {
                    string s1 = strs[j];
                    string s2 = strs[j + 1];
                    if (s1[i] != s2[i])
                    {
                        return s1.Substring(0, i);
                    }
                }
            }

            return strs[0].Substring(0, minLen);
        }

        public static bool IsRegexMatch(string s, string p)
        {
            var dp = new bool[s.Length + 1, p.Length + 1];
            dp[0, 0] = true;
            for (int i = 1; i < p.Length; i++)
            {
                if (p[i] == '*') dp[0, i + 1] = dp[0, i - 1];
                else dp[0, i + 1] = false;
            }

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < p.Length; j++)
                {
                    if (s[i] == p[j] || p[j] == '.')
                    {
                        dp[i + 1, j + 1] = dp[i, j];
                    }
                    else if (p[j] == '*')
                    {
                        dp[i + 1, j + 1] = dp[i + 1, j - 1] || (dp[i, j + 1] && (s[i] == p[j - 1] || p[j - 1] == '.'));
                    }
                }
            }

            return dp[s.Length, p.Length];
        }

        public static bool IsMatch(string s, string p)
        {
            var dp = new bool[s.Length + 1, p.Length + 1];
            dp[0, 0] = true;

            for (int j = 0; j < p.Length; j++)
            {
                if (p[j] == '*')
                {
                    dp[0, j + 1] = dp[0, j];
                }
            }

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < p.Length; j++)
                {
                    if (s[i] == p[j])
                    {
                        dp[i + 1, j + 1] = dp[i, j];
                    }
                    else
                    {
                        if (p[j] == '?')
                        {
                            dp[i + 1, j + 1] = dp[i, j];
                        }
                        else if (p[j] == '*')
                        {
                            dp[i + 1, j + 1] = dp[i + 1, j] || dp[i, j + 1];
                        }
                        else
                        {
                            dp[i + 1, j + 1] = false;
                        }
                    }
                }
            }

            return dp[s.Length, p.Length];
        }

        public static bool IsMatchSlow(string s, string p)
        {
            return IsMatchRecursion(s, 0, p, 0);
        }

        private static bool IsMatchRecursion(string s, int sindex, string p, int pindex)
        {
            while (sindex >= s.Length && pindex < p.Length && p[pindex] == '*')
            {
                pindex++;
            }
            if (sindex >= s.Length && pindex >= p.Length)
            {
                return true;
            }

            if (sindex >= s.Length || pindex >= p.Length)
            {
                return false;
            }
            if (p[pindex] == '*')
            {
                return IsMatchRecursion(s, sindex + 1, p, pindex) || IsMatchRecursion(s, sindex, p, pindex + 1);
            }

            if (p[pindex] == '?' || p[pindex] == s[sindex])
            {
                return IsMatchRecursion(s, sindex + 1, p, pindex + 1);
            }

            return false;
        }

        public static string MinWindow(string stringToSearchIn, string pattern)
        {
            int lengthStringToSearchIn = stringToSearchIn.Length;
            int lengthPattern = pattern.Length;

            // check if string's length is less than pattern's
            // length. If yes then no such window can exist
            if (lengthStringToSearchIn < lengthPattern)
            {
                return "";
            }

            Dictionary<char,int> hashPattern = new Dictionary<char, int>();
            Dictionary<char, int> hashStringToSearchIn = new Dictionary<char, int>();

            // store occurrence ofs characters of pattern
            for (int i = 0; i < lengthPattern; i++)
            {
                if (hashPattern.ContainsKey(pattern[i]))
                {
                    hashPattern[pattern[i]]++;
                }
                else
                {
                    hashPattern.Add(pattern[i], 1);
                }
            }
                

            int start = 0, startIndex = -1, minLength = int.MaxValue;

            // start traversing the string
            int count = 0;  // count of characters
            for (int j = 0; j < lengthStringToSearchIn; j++)
            {
                // count occurrence of characters of string
                if (hashStringToSearchIn.ContainsKey(stringToSearchIn[j]))
                {
                    hashStringToSearchIn[stringToSearchIn[j]]++;
                }
                else
                {
                    hashStringToSearchIn.Add(stringToSearchIn[j], 1);
                }

                // If string's char matches with pattern's char
                // then increment count
                if (hashPattern.ContainsKey(stringToSearchIn[j]))
                {
                    count++;
                }

                // if all the characters are matched
                if (count == lengthPattern)
                {
                    // Try to minimize the window i.e., check if
                    // any character is occurring more no. of times
                    // than its occurrence  in pattern, if yes
                    // then remove it from starting and also remove
                    // the useless characters.
                    while (
                        !hashPattern.ContainsKey(stringToSearchIn[start]) || 
                        (
                        hashPattern.ContainsKey(stringToSearchIn[start]) && 
                        hashStringToSearchIn[stringToSearchIn[start]] > hashPattern[stringToSearchIn[start]]
                        ) 
                    )
                    {

                        if (
                            hashPattern.ContainsKey(stringToSearchIn[start]) && 
                            hashStringToSearchIn[stringToSearchIn[start]] > hashPattern[stringToSearchIn[start]]
                        )
                        {
                            hashStringToSearchIn[stringToSearchIn[start]]--;
                        }
                        start++;
                    }

                    // update window size
                    int lengthWindow = j - start + 1;
                    if (minLength > lengthWindow)
                    {
                        minLength = lengthWindow;
                        startIndex = start;
                    }
                }
            }

            // If no window found
            if (startIndex == -1)
            {
                return "";
            }

            // Return substring starting from start_index
            // and length min_len
            return stringToSearchIn.Substring(startIndex, minLength);
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
