using MainDSA.Algorithms.Math;
using System;

namespace MathsDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Please Enter Any Number: ");
            string data = Console.ReadLine();
            int number = Maths.ConvertToInt(data);
            if (number == 0)
            {
                Console.WriteLine("Either you entered 0 or an invalid number");
            }
            else
            {
                Console.WriteLine($"The number you have entered is {number}");
            }
            Console.ReadKey();
        }
    }
}
