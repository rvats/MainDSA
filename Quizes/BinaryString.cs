using System;
using System.Text;

namespace MainDSA.Quizes
{
    static public class BinaryString
    {
        static public string AddBinary(string a, string b)
        {
            if ((a == null || a.Length == 0) && (b == null || b.Length == 0))
            {
                throw new ArgumentException("No Binary Strings Passed");
            }
            if (a == null || a.Length == 0)
            {
                return b;
            }
            if (b == null || b.Length == 0)
            {
                return a;
            }

            int aLength = a.Length - 1;
            int bLength = b.Length - 1;

            int flag = 0;
            StringBuilder sb = new StringBuilder();
            while (aLength >= 0 || bLength >= 0)
            {
                int va = 0;
                int vb = 0;

                if (aLength >= 0)
                {
                    va = a[aLength] == '0' ? 0 : 1;
                    aLength--;
                }
                if (bLength >= 0)
                {
                    vb = b[bLength] == '0' ? 0 : 1;
                    bLength--;
                }

                int sum = va + vb + flag;
                if (sum >= 2)
                {
                    sb.Append((sum - 2).ToString());
                    flag = 1;
                }
                else
                {
                    flag = 0;
                    sb.Append(sum.ToString());
                }
            }

            if (flag == 1)
            {
                sb.Append("1");
            }
            var reversedCharArray = sb.ToString().ToCharArray();
            Array.Reverse(reversedCharArray);
            return new string(reversedCharArray);
        }
    }
}
