namespace MainDSA.Algorithms.Encryption
{
    public class Compression
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bufferData"></param>
        /// <returns></returns>
        public char[] Compress(char[] bufferData)
        {
            int countCharacter = 1;
            int previousCharacterIndex = 0;
            for (int i = 0; i < bufferData.Length - 1; i++)
            {

                if (bufferData[i] == bufferData[i + 1])
                {
                    countCharacter++;
                }
                else
                {
                    previousCharacterIndex = SetBufferDataToCountDigits(bufferData, previousCharacterIndex, countCharacter);
                    countCharacter = 1;
                }
            }
            return bufferData;
        }

        public int SetBufferDataToCountDigits(char [] bufferData, int previousCharacterIndex, int countCharacter)
        {
            for(int i = 0; i < countCharacter.ToString().Length; i++)
            {
                bufferData[previousCharacterIndex + i + 1] = countCharacter.ToString()[i];
            }
            return previousCharacterIndex + countCharacter.ToString().Length + 1;
        }
    }
}
