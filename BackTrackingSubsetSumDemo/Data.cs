using System;
using System.Collections.Generic;

namespace BackTrackingSubsetSumDemo
{
    class Data
    {
        // Init data
        public Config Config;
        public float Sum { get; private set; }
        public float[] Numbers { get; private set; }

        // Backtracking data
        public bool[] Path { get; private set; }
        public float WorkingSum { get; private set; }
        public Stack<int> Stack = new Stack<int>();

        // Result data
        public int PathsTried;
        public List<string> SolutionsList = new List<string>();
        public int Solutions { get; set; }

        // Only used for Detect code error
        public HashSet<string> SetPathsTried = new HashSet<string>();

        public Data(List<float> numbers, float sum, Config config)
        {
            numbers.Sort(); // sort is used for reject condition in bt algo
            Numbers = numbers.ToArray();
            Path = new bool[Numbers.Length];
            Sum = sum;
            Config = config;
        }

        // O(1)
        public void Remove(Candidate c)
        {
            if (c == null) { throw new ArgumentNullException("c"); }

            var i = Stack.Pop();
            UpdatePath(false, i);
            WorkingSum -= Numbers[i];
        }

        // O(1) (or O(n) if detectCodeError)
        public void Add(Candidate c)
        {
            if (c == null) { throw new ArgumentNullException("c"); }

            UpdatePath(true, c.Index);
            WorkingSum += Numbers[c.Index];
            Stack.Push(c.Index);
            PathsTried++;

            if (Config.DetectCodeError)
            {
                var path = Stack.GetString(); // O(n) where n is stack count
                if (SetPathsTried.Contains(path)) // O(1)
                {
                    throw new ApplicationException(string.Format("Path already visited: {0}", path));
                }
                SetPathsTried.Add(path);
            }
        }

        // O(1)
        private void UpdatePath(bool value, int index)
        {
            if (Path[index] == value)
            {
                throw new ApplicationException(string.Format("Path already set for index: {0}, value: {1}",
                    index, Numbers[index]));
            }
            Path[index] = value;
        }
    }
}
