using System.Collections.Generic;

namespace MainDSA.DataStructures.HashTables
{
    public class HashTable<Generic>
    {
        private List<Generic> keys = new List<Generic>();
        private List<Generic> values = new List<Generic>();

        public Generic Get(Generic key)
        {
            int index = keys.IndexOf(key);
            return values[index];
        }

        public void Add(Generic key, Generic value)
        {
            keys.Add(key);
            values.Add(value);
        }

        public void Remove(Generic key)
        {
            int index = keys.IndexOf(key);
            keys.RemoveAt(index);
            values.RemoveAt(index);
        }

        public void Clear()
        {
            keys = new List<Generic>();
            values = new List<Generic>();
        }
    }
}
