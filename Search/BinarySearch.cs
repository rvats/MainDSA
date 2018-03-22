using System.Collections.Generic;

namespace MainDSA.Search
{
    public class BinarySearch
    {
        //public Dictionary<int, string> Data;
        //Data = new Dictionary<int, string>();
        //Data.Add(1, "Abhishek Sharma");
        //Data.Add(2, "Anshul Jain");
        //Data.Add(3, "Atul Agrawal");
        //Data.Add(36, "Rahul Vats");
        private int[] Data;

        public BinarySearch() => Data = new int[] {
                0, 1, 2, 8, 13, 17, 19, 32, 42
            };

        public BinarySearch(int[] Data) => this.Data = Data;
        
        /// <summary>
        /// Does a Binary Search for the given item and then returns items position.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int FindIndex(int data)
        {
            int mid = -1, found = -1;
            int start = 0, last = Data.Length-1;
            while (last >= start)
            {
                mid = (start + last) / 2;
                if (data == Data[mid])
                {
                    found = mid;
                    return found;
                }
                else
                {
                    if (data < Data[mid])
                    {
                        last = mid - 1;
                    }
                    else
                    {
                        start = mid + 1;
                    }
                }
            }
            return found;
        }

        /// <summary>
        /// Does a Binary Search for the given item and then returns whether the iten exist.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Exists(int data)
        {
            bool found = false;
            int mid = -1;
            int start = 0, last = Data.Length-1;
            while (last >= start)
            {
                mid = (start + last) / 2;
                if (data == Data[mid])
                {
                    found = true;
                    break;
                }
                else
                {
                    if (data < Data[mid])
                    {
                        last = mid - 1;
                    }
                    else
                    {
                        start = mid + 1;
                    }
                }
            }
            return found;
        }
    }
}
