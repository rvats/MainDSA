using System.Collections.Generic;

namespace MainDSA.Quizes
{
    public class Parentheses
    {
        List<string> result = new List<string>();
        int max = 0;

        public IList<string> RemoveInvalidParentheses(string s)
        {
            if (s == null)
                return result;

            DepthFirstTraversal(s, "", 0, 0);
            if (result.Count == 0)
            {
                result.Add("");
            }

            return result;
        }

        public void DepthFirstTraversal(string left, string right, int countLeft, int maxLeft)
        {
            if (left.Length == 0)
            {
                if (countLeft == 0 && right.Length != 0)
                {
                    if (maxLeft > max)
                    {
                        max = maxLeft;
                    }

                    if (maxLeft == max && !result.Contains(right))
                    {
                        result.Add(right);
                    }
                }

                return;
            }

            if (left[0] == '(')
            {
                DepthFirstTraversal(left.Substring(1), right + "(", countLeft + 1, maxLeft + 1);//keep (
                DepthFirstTraversal(left.Substring(1), right, countLeft, maxLeft);//drop (
            }
            else if (left[0] == ')')
            {
                if (countLeft > 0)
                {
                    DepthFirstTraversal(left.Substring(1), right + ")", countLeft - 1, maxLeft);
                }

                DepthFirstTraversal(left.Substring(1), right, countLeft, maxLeft);

            }
            else
            {
                DepthFirstTraversal(left.Substring(1), right + left[0], countLeft, maxLeft);
            }
        }
    }
}
