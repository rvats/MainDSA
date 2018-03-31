using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainDSA.Quizes
{
    public class InflightEntertainment
    {
        public bool CanTwoMoviesFillFlight(int[] movieLengths, int flightLength)
        {
            // Movie lengths we've seen so far
            var movieLengthsSeen = new HashSet<int>();

            foreach (var firstMovieLength in movieLengths)
            {
                int matchingSecondMovieLength = flightLength - firstMovieLength;
                if (movieLengthsSeen.Contains(matchingSecondMovieLength))
                {
                    return true;
                }

                movieLengthsSeen.Add(firstMovieLength);
            }

            // We never found a match, so return false
            return false;
        }
    }
}
