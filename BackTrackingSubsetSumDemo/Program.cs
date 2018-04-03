using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace BackTrackingSubsetSumDemo
{
    public class Program
    {
        private static readonly Action<object> Write = Console.Write;
        private static readonly Func<ConsoleKeyInfo> ReadKey = Console.ReadKey;

        // Composition root
        private static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            // Use timer for checking algo time
            var sw = new Stopwatch();
            sw.Start();


            // -----------------------------------------
            // ** INSERT YOUR DATA HERE **
            // Init config, 
            var config = new Config
            {
                MaxSolutions = 100,          // restrict result count
                ShowProgress = true,       // show backtrack progress
                ShowStatus = true,         // show iteration progress
                DisplaySolutions = true,   // Show solution list
                DetectCodeError = false,   // slower running time if true
            };

            // set
            var set = new List<float> { -3, -2, -1, 0, 1, 2, 3, 4 };

            // subset sum
            var sum = 3;

            // ** END INSERT DATA **
            // -----------------------------------------


            // Init data
            var P = new Data(set, sum, config);

            // Init backtrack algo
            var bt = new Backtrack(Write, P);

            // Find solutions
            bt.Run();

            // Algo done, stop time
            sw.Stop();

            // Show results
            bt.Show();

            Write(string.Format("\nSec: {0}\nPress a key to exit\n",
                sw.ElapsedMilliseconds / 1000d));

            ReadKey();
        }
    }
}
