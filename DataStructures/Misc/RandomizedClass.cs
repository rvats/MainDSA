using System;
using System.Collections.Generic;

namespace MainDSA.DataStructures.Misc
{
    public class RandomizedSet
    {
        Dictionary<int, HashSet<int>> map1;
        Dictionary<int, int> map2;
        Random r;

        /** Initialize your data structure here. */
        public RandomizedSet()
        {
            map1 = new Dictionary<int, HashSet<int>>();
            map2 = new Dictionary<int, int>();
            r = new Random();
        }

        /** Inserts a value to the collection. Returns true if the collection did not already contain the specified element. */
        public bool Insert(int val)
        {
            //add to map2
            int size2 = map2.Count;
            map2.Add(size2 + 1, val);

            if (map1.ContainsKey(val))
            {
                map1[val].Add(size2 + 1);
                return false;
            }
            else
            {
                HashSet<int> set = new HashSet<int>();
                set.Add(size2 + 1);
                map1.Add(val, set);
                return true;
            }
        }

        /** Removes a value from the collection. Returns true if the collection contained the specified element. */
        public bool Remove(int val)
        {
            if (map1.ContainsKey(val))
            {
                HashSet<int> set = map1[val];
                int toRemove = set.GetEnumerator().Current;


                //remove from set of map1
                set.Remove(toRemove);

                if (set.Count == 0)
                {
                    map1.Remove(val);
                }

                if (toRemove == map2.Count)
                {
                    map2.Remove(toRemove);
                    return true;
                }

                int size2 = map2.Count;
                int key = map2[size2];

                HashSet<int> setChange = map1[key];
                setChange.Remove(size2);
                setChange.Add(toRemove);



                map2.Remove(size2);
                map2.Remove(toRemove);

                map2.Add(toRemove, key);

                return true;
            }

            return false;
        }

        /** Get a random element from the collection. */
        public int GetRandom()
        {
            if (map1.Count == 0)
                return -1;

            if (map2.Count == 1)
            {
                return map2[1];
            }

            return map2[r.Next(map2.Count) + 1]; // nextInt() returns a random number in [0, n).
        }
    }

    /**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */
}
