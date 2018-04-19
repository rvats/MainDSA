namespace Demo
{
    class Program
    {
        static void Main(string[] args) 
        {
            Solution s = new Solution();
        }
    }

    /// <summary>
    /// 8. String to Integer (atoi)
    /// </summary>
    public class Solution
    {
        public int MyAtoi(string str)
        {
            if (str == null || str.Length < 1)
                return 0;

            // trim white spaces
            str = str.Trim();

            char flag = '+';

            // check negative or positive
            int i = 0;
            if (str[0] == '-')
            {
                flag = '-';
                i++;
            }
            else if (str[0] == '+')
            {
                i++;
            }
            // use double to store result
            double result = 0;

            // calculate value
            while (str.Length > i && str[i] >= '0' && str[i] <= '9')
            {
                result = result * 10 + (str[i] - '0');
                i++;
            }

            if (flag == '-')
                result = -result;

            // handle max and min
            if (result > int.MaxValue)
                return int.MaxValue;

            if (result < int.MinValue)
                return int.MinValue;

            return (int)result;
        }
    }
}