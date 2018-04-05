using MainDSA.Quizes;
using System;

namespace Demo
{
    class Program
    {
        static string[] cpDomains = new string[] { "10000 google.com", "50 yahoo.com" };

        static void Main(string[] args)
        {
            foreach (var subDomainVisit in DomainVisits.SubdomainVisits(cpDomains))
            {
                Console.WriteLine(subDomainVisit);
            }
        }
    }
}
