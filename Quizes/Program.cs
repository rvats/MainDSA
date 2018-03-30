using System;
using System.Collections.Generic;

namespace DemoQuizes
{
    public class Program
    {
        public static int[] Nums1 = { 2, 7, 11, 15, 1, 4, 3, 5, 6, 8, 9, 10 };
        public static int[] Nums2 = { -1, 0, -2, 0, 1, 2, -1, -2, 1, 2 };
        public static int[] stockPricesYesterday = { 10, 7, 5, 8, 11, 9 };
        public static int[] arrayForProducts = { 1, 7, 3, 4, -10, -10 };
        public static List<Meeting> allMeetings = new List<Meeting>();
        public static int[] changeDenominations = { 1, 2, 3 };
        public static void Main(string[] args)
        {
            Console.WriteLine("Ways to Create Amount from Given Denominations: {0}",ArrayExtensions.ChangePossibilitiesBottomUp(1, changeDenominations));
        }
        public static void TestMergingMeetings()
        {
            allMeetings.Add(new Meeting(0, 1));
            allMeetings.Add(new Meeting(3, 5));
            allMeetings.Add(new Meeting(4, 8));
            allMeetings.Add(new Meeting(10, 12));
            allMeetings.Add(new Meeting(9, 10));
            Console.WriteLine("All Meetings before Merging");
            foreach (var meeting in allMeetings)
            {
                Console.WriteLine(meeting);
            }
            Console.WriteLine("All Meetings after Merging");
            var mergeMeetings = Meeting.MergeRanges(allMeetings);
            foreach (var meeting in mergeMeetings)
            {
                Console.WriteLine(meeting);
            }
        }

        public static void TestHighestProductFrom3NumbersInArray()
        {
            var HighestIntegerFrom3NumbersInArray = ArrayExtensions.HighestProductOf3(arrayForProducts);
            Console.WriteLine("Highest Number obtained from multiplying any 3 numbers in the array: {0}", HighestIntegerFrom3NumbersInArray);
        }
        public static void TestProductOfRemainingNumbersInArray()
        {
            Console.WriteLine("My Solution to the ProuctOfRemaining Numbers: ");
            var productsArray1 = ArrayExtensions.ReturnProductOfRemainingNumbers(arrayForProducts);
            foreach (var item in productsArray1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Solution from Interview Cake: ");
            var productsArray2 = ArrayExtensions.GetProductsOfAllIntsExceptAtIndex(arrayForProducts);
            foreach (var item in productsArray2)
            {
                Console.WriteLine(item);
            }
        }

        public static void TestStock()
        {
            var maxProfit = Stocks.GetMaxProfit(stockPricesYesterday);
            Console.WriteLine("Maximum Profit that could have been earned Yesterday: {0}", maxProfit);
        }

        public static void Test()
        {
            var array = SumOfElements.TwoSum(Nums1, 26);
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Sum of Two Numbers!");
            var list = Area.AllAreas(Nums1);
            foreach (var item in list)
            {
                Console.Write(item);
                Console.Write("     ");
            }
            Console.WriteLine("All Areas!");
            var maxArea = Area.MaxArea(Nums1);
            Console.WriteLine(maxArea);
            Console.WriteLine("Max Area!");
            var duplicates1 = ArrayExtensions.RemoveDuplicatesAndReturnLength(Nums1);
            Console.WriteLine(duplicates1);
            var duplicates2 = ArrayExtensions.RemoveDuplicatesAndReturnLength(Nums2);
            Console.WriteLine(duplicates2);
            Console.WriteLine("Duplicates Removed!");
            var removeElement1 = ArrayExtensions.RemoveElementAndReturnLength(Nums1, 15);
            Console.WriteLine(removeElement1);
            var removeElement2 = ArrayExtensions.RemoveElementAndReturnLength(Nums2, -2);
            Console.WriteLine(removeElement2);
            Console.WriteLine("Duplicates Removed!");
        }
    }
}