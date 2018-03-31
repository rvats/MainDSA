using System;
using System.Collections.Generic;

namespace MainDSA.Algorithms.Sort
{
    /// <summary>
    /// Bubble Sort is a sorting algorithm (an algorithm that puts elements of a list in a certain order). The simplest sorting algorithm is Bubble Sort. In the Bubble Sort, as elements are sorted they gradually "bubble up" to their proper location in the array, like bubbles rising in a glass of soda. 
    /// The Bubble Sort works by iterating down an array to be sorted from the first element to the last, comparing each pair of elements and switching their positions if necessary.This process is repeated as many times as necessary, until the array is sorted.
    /// </summary>
    public class SelectionSort
    {
        public int[] Sort(int[] number)
        {
            //pos_min is short for position of min
            int pos_min, temp;

            for (int i = 0; i < number.Length - 1; i++)
            {
                pos_min = i;//set pos_min to the current index of array

                for (int j = i + 1; j < number.Length; j++)
                {
                    if (number[j] < number[pos_min])
                    {
                        //pos_min will keep track of the index that min is in, this is needed when a swap happens
                        pos_min = j;
                    }
                }

                //if pos_min no longer equals i than a smaller value must have been found, so a swap must occur
                if (pos_min != i)
                {
                    temp = number[i];
                    number[i] = number[pos_min];
                    number[pos_min] = temp;
                }

                Console.Write("Iteration {0}-{1}\t", i+1, number.Length-i-1);
                foreach (var num in number)
                {
                    Console.Write("{0} ", num);
                }
                Console.WriteLine();
            }
            return number;
        }
    }
}
