using System;

namespace Demo
{
    /// <summary>
    /// This Program is to keep history of all the problems solved from LeetCode One At A Time
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string choice = "Y";
            while(choice != "n")
            {
                var strPalindrome = Console.ReadLine();
                Console.WriteLine(MainDSA.Quizes.String.IsPalindromeUponDeletingAtMost1Character(strPalindrome));
                choice = Console.ReadLine();
            }
            
        }
    }
}
