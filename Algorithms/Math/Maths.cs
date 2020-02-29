namespace MainDSA.Algorithms.Math
{
    public static class Maths
    {
        public static int ConvertToInt(string data)
        {
            int number = 0;
            if (
                string.IsNullOrWhiteSpace(data)
                ||
                (data[0] < 49 || data[0] > 57)
            )
            {
                return number;
            }
            int i = 0;
            while(i < data.Length)
            {
                int num = data[i];
                if((num < 48 || num > 57))
                {
                    return 0;
                }
                else
                {
                    num = num - 48;
                }
                number = (number * 10) + num;
                i++;
            }
            return number;
        }
    }
}
