using System;

namespace Demo
{
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
