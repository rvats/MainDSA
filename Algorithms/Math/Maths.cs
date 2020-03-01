namespace MainDSA.Algorithms.Math
{
    public static class Maths
    {
        /// <summary>
        /// Work in Progress
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int ConvertToInt(string data)
        {
            int number = 0;
            if (
                string.IsNullOrWhiteSpace(data)
                ||
                ((data[0] != 45) && (data[0] < 49 || data[0] > 57))
                ||
                ((data[0] == 45) && (data[1] < 49 || data[1] > 57))
               )
            {
                return number;
            }
            int i = 0;
            if(data[0] != 45)
            {
                while (i < data.Length)
                {
                    int num = data[i];
                    if ((num < 48 || num > 57))
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
            }
            
            return number;
        }
    }
}
