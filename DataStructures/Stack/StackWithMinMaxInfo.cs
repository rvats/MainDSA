using System.Collections.Generic;

namespace MainDSA.DataStructures
{
    /// <summary>
    /// Cracking The Coding Interview: 3.2 Stack Min
    /// </summary>
    public class StackWithMinMaxInfo:Stack<int>
    {
        Stack<int> MinInfo;
        Stack<int> MaxInfo;

        public StackWithMinMaxInfo()
        {
            MinInfo = new Stack<int>();
            MaxInfo = new Stack<int>();
        }

        public int Min()
        {
            if (MinInfo.Count == 0)
            {
                return int.MaxValue;
            }
            else
            {
                return MinInfo.Peek();
            }
        }

        public int Max()
        {
            if (MaxInfo.Count == 0)
            {
                return int.MinValue;
            }
            else
            {
                return MaxInfo.Peek();
            }
        }

        public new void Push(int value)
        {
            if (value <= Min())
            {
                MinInfo.Push(value);
            }
            if (value <= Max())
            {
                MaxInfo.Push(value);
            }
            base.Push(value);
        }

        public new int Pop()
        {
            int value = base.Pop();
            if (value == Min())
            {
                MinInfo.Pop();
            }
            if (value == Max())
            {
                MaxInfo.Pop();
            }
            return value;
        }

        public new int Peek()
        {
            return base.Peek();
        }
    }
}
