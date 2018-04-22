using System.Text;

namespace MainDSA.Algorithms.BitwiseOperations
{
    public class BitwiseOperations
    {
        /// <summary>
        /// Cracking The Coding Interviw: 17.1 Adding without Plus Operator
        /// Write A Function that adds two number without using any arithmetic operator
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <returns></returns>
        public int Addition(int number1, int number2)
        {
            if(number2==0) { return number1; }
            int sum = number1 ^ number2; // Add Without Carrying -> number1 XOR number2
            int carry = (number1 & number2) << 1; // Carry but don't add -> number1 AND number 2 and left shift bit by 1
            return Addition(sum, carry);
        }

        /// <summary>
        /// 5.1 Insertion: We are given two 32-Bit numbers and two bits position
        /// Write A Method to insert number M into N starting at bit J and ending at bit I
        /// </summary>
        /// <param name="numberN"></param>
        /// <param name="numberM"></param>
        /// <param name="bitPositionI"></param>
        /// <param name="bitPositionJ"></param>
        /// <returns></returns>
        public int UpdateBits(int numberN, int numberM, int bitPositionI, int bitPositionJ)
        {
            // Create A Mask to clear bits i through j in n: i = 2 and j = 4
            // Mask Should Be 11100011
            // Start with all 1s: 11111111
            int allOnes = ~0;
            // 1s before position j, then 0s: 11100000
            int left = allOnes << (bitPositionJ + 1);
            // 1s after position i, rest 0s: 00000011
            int right = ((1 << bitPositionI) - 1);
            // All 1s, except for 0s between i and j. mask = 11100011
            int mask = left | right;
            // Clear bits j through i then put m in there
            int numberNCleared = numberN & mask;
            int numberMShifted = mask << bitPositionI;
            return numberNCleared | numberMShifted;
        }

        /// <summary>
        /// 5.2 Binary to String: Given a real number between 0 and 1 (e.g.: 0.72)
        /// Print the Binary Representation of the number
        /// if the number cannot be represented by 32 characters then print "ERROR"
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public string PrintBinary(double number)
        {
            if (number >= 1 || number <= 0) { return "ERROR"; }
            StringBuilder binary = new StringBuilder(32);
            binary.Append(".");
            while (number > 0)
            {
                // Setting a limit on length: 32
                if (binary.Length >= 32)
                {
                    return "ERROR";
                }
                double r = number * 2;
                if (r >= 1)
                {
                    binary.Append(1);
                    number = r - 1;
                }
                else
                {
                    binary.Append(0);
                    number = r;
                }
            }
            return binary.ToString();
        }

        /// <summary>
        /// 5.5 Debugger: Explain what the following code does ((n&(n-1))==0)
        /// Answer: It Checks for the Power of 2.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool PowerOf2(int number)
        {
            return ((number & (number - 1)) == 0);
        }

        /// <summary>
        /// 5.6 Conversion: Write a function to determine the number of bits you would have to swap to 
        /// change number1 to number2
        /// for(int changedBit = number1 ^ number2; changedBit != 0; changedBit = changedBit >> 1) { count += changedBit & 1; } This could be very slow
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <returns></returns>
        public int BitSwapRequired(int number1, int number2)
        {
            int count = 0;
            for (int changedBit = number1 ^ number2; changedBit != 0; changedBit = changedBit & (changedBit - 1))
            {
                count++;
            }
            return count;
        }

        /// <summary>
        /// 5.7 Pairwise Swap: Write a program to swap odd and even bits in an integer
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public int SwapOddEvenBits(int number)
        {
            return (((number & 0xaaaaaaa) >> 1) | ((number & 0x55555555) << 1));
        }
    }
}
