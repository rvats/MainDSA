using System;
using System.Collections.Generic;
using System.Linq;

namespace MainDSA.Quizes
{
    public class Meeting
    {
        public int StartTime { get; set; }

        public int EndTime { get; set; }

        public Meeting(int startTime, int endTime)
        {
            // Number of 30 min blocks past 9:00 am
            StartTime = startTime;
            EndTime = endTime;
        }

        public override string ToString()
        {
            return $"({StartTime}, {EndTime})";
        }

        public static List<Meeting> MergeRanges(List<Meeting> meetings)
        {
            // Step 1: Sort The Meetings 
            // Make a copy so we don't destroy the input, and sort by start time
            var sortedMeetings = meetings.Select(m => new Meeting(m.StartTime, m.EndTime))
                .OrderBy(m => m.StartTime).ToList();

            // Step 2: Create mergeMeetings Variable
            // Initialize mergedMeetings with the earliest meeting
            var mergedMeetings = new List<Meeting> { sortedMeetings[0] };

            for (int i = 1; i < sortedMeetings.Count; i++)
            {
                var lastMergedMeeting = mergedMeetings.Last();
                var currentMeeting = sortedMeetings[i];

                // Since Everything is sorted and last merged meeting will end after current meeting start time
                // The two meetings can be merged.
                if (currentMeeting.StartTime <= lastMergedMeeting.EndTime)
                {
                    // Since the current meeting overlaps with the last merged meeting, 
                    // use the later end time of the two
                    lastMergedMeeting.EndTime = Math.Max(lastMergedMeeting.EndTime, currentMeeting.EndTime);
                }
                else
                {
                    // Add the current meeting since it doesn't overlap
                    mergedMeetings.Add(currentMeeting);
                }
            }
                return mergedMeetings;
        }
    }
}
