using System;
using MainDSA.Algorithms.Misc;
namespace ClockDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            int hour, minute = 0;
            Console.Write("Please Enter the Hour Value (Number between 1 and 12): ");
            hour = int.Parse(Console.ReadLine());
            Console.Write("Please Enter the Minute Value (Number between 0 and 59): ");
            minute = int.Parse(Console.ReadLine());
            double angleBetweenHourHandandMinuteHand = Clock.CalculateAngleBetweenHourHandAndMinuteHand(hour, minute);
            Console.WriteLine($"Angle Between Hour Hand at {hour} and Minute Hand at {minute} is {angleBetweenHourHandandMinuteHand}");
            Console.ReadKey();
        }
    }
}
