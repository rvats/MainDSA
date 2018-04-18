namespace MainDSA.DataStructures.Search
{
    public class BinarySearch
    {
        public bool SearchForN(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] == target)
                    return true;

                if (nums[left] < nums[mid])
                {
                    if (nums[left] <= target && target < nums[mid])
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                else if (nums[left] > nums[mid])
                {
                    if (nums[mid] < target && target <= nums[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
                else
                {
                    left++;
                }
            }

            return false;
        }

        /// <summary>
        /// 33. Search in Rotated Sorted Array
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Search(int[] nums, int target)
        {
            return Search(nums, 0, nums.Length - 1, target);
        }

        /// <summary>
        /// 33. Search in Rotated Sorted Array
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Search(int[] nums, int left, int right, int target)
        {
            if (left > right)
                return -1;

            int mid = left + (right - left) / 2;

            if (target == nums[mid])
                return mid;

            if (nums[left] <= nums[mid])
            {
                if (nums[left] <= target && target < nums[mid])
                {
                    return Search(nums, left, mid - 1, target);
                }
                else
                {
                    return Search(nums, mid + 1, right, target);
                }
            }
            else
            {
                if (nums[mid] < target && target <= nums[right])
                {
                    return Search(nums, mid + 1, right, target);
                }
                else
                {
                    return Search(nums, left, mid - 1, target);
                }
            }
        }

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
