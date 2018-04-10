using System.Collections.Generic;

namespace MainDSA.Quizes.Design
{
    public class NestedIterator
    {
        Stack<int> stack = new Stack<int>();
 
        //public NestedIterator(List<NestedInteger> nestedList)
        //{
        //    if (nestedList == null)
        //        return;

        //    for (int i = nestedList.size() - 1; i >= 0; i--)
        //    {
        //        stack.push(nestedList.get(i));
        //    }
        //}

        public int Next()
        {
            return stack.Pop();
        }

        //public bool HasNext()
        //{
        //    while (stack.Count!=0)
        //    {
        //        NestedInteger top = stack.Peek();
        //        if (top.isInteger())
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            stack.Pop();
        //            for (int i = top.getList().size() - 1; i >= 0; i--)
        //            {
        //                stack.Push(top.getList().get(i));
        //            }
        //        }
        //    }

        //    return false;
        //}
    }
}