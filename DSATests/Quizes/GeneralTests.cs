using MainDSA.Quizes;
using System;
using System.Collections.Generic;

namespace DSATests
{
    public class Program
    {
        public static int[] Nums1 = { 2, 7, 11, 15, 1, 4, 3, 5, 6, 8, 9, 10 };
        public static int[] Nums2 = { -1, 0, -2, 0, 1, 2, -1, -2, 1, 2 };
        public static int[] arrayForProducts = { 1, 7, 3, 4, -10, -10 };
        public static List<Meeting> allMeetings = new List<Meeting>();
        public static int[] changeDenominations = { 1, 2, 3 };
        public static string[] words = new string[]
        {
            "ptolemaic", // 0
            "retrograde", // 1
            "supplant", // 2
            "undulate", // 3
            "xenoepist", // 4
            "asymptote", // 5 // <-- rotates here!
            "babka", // 6
            "banoffee", // 7
            "engender", // 8
            "karpatka", // 9
            "othellolagkage" // 10
        };

        public static void TestNthFibonacci(string[] args)
        {
            int Number = 15;
            Console.WriteLine("{0}th term in the Fibonaccci Series : {1}", Number, Mathematics.NthFibonacci(Number));
        }
        public static void TestRotationPoint()
        {
            int rotationPoint = ArrayExtensions.FindRotationPoint(words);
            Console.WriteLine("I Rotated the dictionary at the index {0} for the word {1}", rotationPoint, words[rotationPoint]);
        }

        public static void TestSecondLargestOrSecondSmallest()
        {
            BinaryTreeNode root = new BinaryTreeNode(4);
            root.InsertLeft(2);
            root.Left.InsertLeft(1);
            root.InsertRight(6);
            root.Left.Left.InsertLeft(0);
            Console.WriteLine("Largest Node in the Given Binary Search Tree: {0}", root.FindLargest(root));
            Console.WriteLine("Second Largest Node in the Given Binary Search Tree: {0}", root.FindSecondLargest(root));
            Console.WriteLine("Smallest Node in the Given Binary Search Tree: {0}", root.FindSmallest(root));
            Console.WriteLine("Second Smallest Node in the Given Binary Search Tree: {0}", root.FindSecondSmallest(root));
        }

        public static void TestIsTreeBST()
        {
            BinaryTreeNode root = new BinaryTreeNode(4);
            root.InsertLeft(2);
            root.Left.InsertLeft(1);
            root.InsertRight(6);
            root.Left.Left.InsertLeft(0);
            // Uncomment following line to render tree just Binary
            //root.Right.InsertLeft(0);
            // The bounds in the code below of 0 appears to be useless
            NodeBounds check = new NodeBounds(root, 0, 0);
            Console.WriteLine("Given Tree is Binary Search Tree: {0}", check.IsBinarySearchTree(root));
        }

        public static void TestIsTreeBalanced()
        {
            BinaryTreeNode root = new BinaryTreeNode(4);
            root.InsertLeft(2);
            root.Left.InsertLeft(1);
            root.InsertRight(6);
            // Comment following line to render tree Balanced
            root.Left.Left.InsertLeft(0);
            // The depth in the code below of 0 appears to be useless
            NodeDepthPair check = new NodeDepthPair(root, 0);
            Console.WriteLine("Given Tree is Balanced: {0}", check.IsBalanced(root));
        }
        public static void TestChangeDenominations()
        {
            Console.WriteLine("Ways to Create Amount from Given Denominations: {0}", ArrayExtensions.ChangePossibilitiesBottomUp(1, changeDenominations));
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