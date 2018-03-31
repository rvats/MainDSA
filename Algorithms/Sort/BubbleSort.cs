using System;
using System.Collections.Generic;

namespace MainDSA.Algorithms.Sort
{
    /// <summary>
    /// Bubble Sort is a sorting algorithm (an algorithm that puts elements of a list in a certain order). The simplest sorting algorithm is Bubble Sort. In the Bubble Sort, as elements are sorted they gradually "bubble up" to their proper location in the array, like bubbles rising in a glass of soda. 
    /// The Bubble Sort works by iterating down an array to be sorted from the first element to the last, comparing each pair of elements and switching their positions if necessary.This process is repeated as many times as necessary, until the array is sorted.
    /// </summary>
    public class BubbleSort
    {
        public int[] Sort(int[] number)
        {
            bool flag = true;
            int temp;
            int numLength = number.Length;

            //sorting an array
            for (int i = 1; (i <= (numLength - 1)) && flag; i++)
            {
                flag = false;
                for (int j = 0; j < (numLength - 1); j++)
                {
                    if (number[j + 1] < number[j])
                    {
                        temp = number[j];
                        number[j] = number[j + 1];
                        number[j + 1] = temp;
                        flag = true;
                    }
                    Console.Write("Iteration {0}-{1}\t", i, j+1);
                    foreach(var num in number)
                    {
                        Console.Write("{0} ", num);
                    }
                    Console.WriteLine();
                }
            }
            return number;
        }
    }
}
