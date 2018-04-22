using System.Collections.Generic;

namespace MainDSA.DataStructures.Misc
{
    /// <summary>
    /// Leetcode: 359. Logger Rate Limiter
    /// Design a logger system that receive stream of messages along with its timestamps, each message should be printed if and only if it is not printed in the last 10 seconds.
    /// Given a message and a timestamp(in seconds granularity), return true if the message should be printed in the given timestamp, otherwise returns false.
    /// It is possible that several messages arrive roughly at the same time.
    /// </summary>
    public class Logger
    {
        private Dictionary<string, int> messagePrintTime;

        /** Initialize your data structure here. */
        public Logger()
        {
            messagePrintTime = new Dictionary<string, int>();
        }

        /** Returns true if the message should be printed in the given timestamp, otherwise returns false.
            If this method returns false, the message will not be printed.
            The timestamp is in seconds granularity. */
        public bool ShouldPrintMessage(int timestamp, string message)
        {
            if (messagePrintTime.ContainsKey(message))
            {
                int time = messagePrintTime[message];
                //System.out.println(message + " " + time + " " + timestamp);
                if (timestamp - time >= 10)
                {
                    messagePrintTime[message] = timestamp;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                messagePrintTime.Add(message, timestamp);
                return true;
            }
        }
    }
}
