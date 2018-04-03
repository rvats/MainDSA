using MainDSA.Quizes;
using System;

namespace LoveRectangleDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            LoveRectangle rectangle1 = new LoveRectangle(1, 1, 5, 4);
            LoveRectangle rectangle2 = new LoveRectangle(5, 3, 3, 4);
            RangeOverlap rangeOverlap = new RangeOverlap(3, 1);
            LoveRectangle overlapRectangle = rangeOverlap.FindRectangularOverlap(rectangle1, rectangle2);
            Console.WriteLine(overlapRectangle);
        }
    }
}
