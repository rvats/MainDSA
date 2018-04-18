using MainDSA.DataStructures.Misc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MainDSA.Quizes
{
    public class Meeting
    {
        /// <summary>
        /// 252. Meeting Rooms - Not Working
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public bool CanAttendMeetings(Interval[] intervals)
        {
            var sortedMeetings = intervals.Select(i => new Interval(i.start, i.end))
                .OrderBy(i => i.start).ToList();

            for (int i = 0; i < intervals.Length - 1; i++)
            {
                if (intervals[i].end > intervals[i + 1].start)
                {
                    return false;
                }
            }

            return true;
        }

        public int MinMeetingRooms(Interval[] intervals)
        {
            int[] start = new int[intervals.Length];
            int[] end = new int[intervals.Length];
            for (int i = 0; i < intervals.Length; i++)
            {
                start[i] = intervals[i].start;
                end[i] = intervals[i].end;
            }
            Array.Sort(start);
            Array.Sort(end);
            int endIdx = 0, res = 0;
            for (int i = 0; i < start.Length; i++)
            {
                if (start[i] < end[endIdx]) res++;
                else endIdx++;
            }
            return res;
        }

        /// <summary>
        /// To Do Complete this method using Priority Queue
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public int MinMeetingRoomsByPriorityQueue(Interval[] intervals)
        {
            if (intervals == null || intervals.Length == 0)
            {
                return 0;
            }
            return 0;
            //            Array.Sort(intervals, new Comparable<Interval>()
            //            {
            //        public int compare(Interval i1, Interval i2)
            //            {
            //                return i1.start - i2.start;
            //            }
            //        });
            //	PriorityQueue<Interval> pq = new PriorityQueue<>(new Comparator<Interval>()
            //    {

            //        public int compare(Interval i1, Interval i2)
            //        {
            //            return i1.end - i2.end;
            //        }
            //    });
            //	pq.offer(intervals[0]);
            //	for (int i = 1; i<intervals.length; i++) {
            //		Interval interval = pq.poll();
            //		if (intervals[i].start >= interval.end) 
            //			interval.end = intervals[i].end;
            //		else
            //			pq.offer(intervals[i]);
            //		pq.offer(interval);
            //	}
            //	return pq.size();
        }


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

        public IList<Interval> Merge(IList<Interval> intervals)
        {
            if (intervals == null || intervals.Count <= 1)
            {
                return intervals;
            }
            // Step 1: Sort The Meetings 
            // Make a copy so we don't destroy the input, and sort by start time
            var sortedMeetings = intervals.Select(m => new Interval(m.start, m.end)).OrderBy(m => m.start).ToList();

            // Step 2: Create mergeMeetings Variable
            // Initialize mergedMeetings with the earliest meeting
            var mergedMeetings = new List<Interval>() { sortedMeetings[0] };

            // Iterate through all the meetings
            for (int i = 1; i < sortedMeetings.Count; i++)
            {
                var lastMergedMeeting = mergedMeetings.Last();
                var currentMeeting = sortedMeetings[i];

                // Since Everything is sorted and last merged meeting will end after current meeting start time
                // The two meetings can be merged.
                if (currentMeeting.start <= lastMergedMeeting.end)
                {
                    // Since the current meeting overlaps with the last merged meeting, 
                    // use the later end time of the two
                    lastMergedMeeting.end = Math.Max(currentMeeting.end, lastMergedMeeting.end);
                }
                else
                {
                    // Add the current meeting since it doesn't overlap
                    mergedMeetings.Add(currentMeeting);
                }
            }

            return mergedMeetings;
        }

        public static List<Meeting> MergeRanges(List<Meeting> meetings)
        {
            // Step 1: Sort The Meetings 
            // Make a copy so we don't destroy the input, and sort by start time
            var sortedMeetings = meetings.Select(m => new Meeting(m.StartTime, m.EndTime)).OrderBy(m => m.StartTime).ToList();

            // Step 2: Create mergeMeetings Variable
            // Initialize mergedMeetings with the earliest meeting
            var mergedMeetings = new List<Meeting>() { sortedMeetings[0] };

            // Iterate through all the meetings
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
                    lastMergedMeeting.EndTime = Math.Max(currentMeeting.EndTime, lastMergedMeeting.EndTime);
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
