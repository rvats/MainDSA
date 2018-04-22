namespace MainDSA.Algorithms.BitwiseOperations
{
    public class BitwiseOperations
    {
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
    }
}
