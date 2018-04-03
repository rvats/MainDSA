using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackTrackingSubsetSumDemo
{
    static class Extensions
    {
        public static string GetString<T>(this IEnumerable<T> arr)
        {
            return arr.Aggregate("", (a, b) => a + string.Format("{0}->", b));
        }
        public static string Get(this IEnumerable<bool> arr)
        {
            return arr.Aggregate("", (a, b) => a + (b ? "1" : "0"));
        }
    }
}
