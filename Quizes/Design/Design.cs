using System;

namespace MainDSA.Quizes.Design
{
    public class Design
    {
        private char[] read4buf = new char[4];
        private int alreadyReadCount = 0;
        private int alreadyReadIndex = 0;
        bool endoffile = false;

        public int Read2(char[] buf, int n)
        {
            var readindex = 0;

            if (alreadyReadCount > alreadyReadIndex)
            {
                var length = Math.Min(n - readindex, alreadyReadCount - alreadyReadIndex);
                for (int i = 0; i < length; i++)
                {
                    buf[i + readindex] = read4buf[i + alreadyReadIndex];
                }

                readindex = length;
                alreadyReadIndex += length;
            }

            while (readindex < n && !endoffile)
            {
                var readbytes = (int)Read4(read4buf);
                if (readbytes < 4)
                {
                    endoffile = true;
                }

                var length = Math.Min(n - readindex, readbytes);
                for (int i = 0; i < length; i++)
                {
                    buf[i + readindex] = read4buf[i];
                }
                readindex += length;
                alreadyReadCount = readbytes;
                alreadyReadIndex = length;
            }

            return readindex;
        }

        private object Read4(char[] read4buf)
        {
            throw new NotImplementedException();
        }

        /**
     * @param buf Destination buffer
     * @param n   Maximum number of characters to read
     * @return    The number of characters read
     */
        public int Read1(char[] buf, int n)
        {
            var read4buf = new char[4];
            var readindex = 0;
            var endoffile = false;

            while (readindex < n && !endoffile)
            {
                var readbytes = (int)Read4(read4buf);
                if (readbytes < 4)
                {
                    endoffile = true;
                }

                var length = Math.Min(n - readindex, readbytes);
                for (int i = 0; i < length; i++)
                {
                    buf[i + readindex] = read4buf[i];
                }
                readindex += length;
            }

            return readindex;
        }
    }
}
