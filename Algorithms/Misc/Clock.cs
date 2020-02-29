using System;

namespace MainDSA.Algorithms.Misc
{
    public class Clock
    {
        public static double CalculateAngleBetweenHourHandAndMinuteHand(int hour, int minute)
        {
            double hourAngle, minuteAngle, angle = 0.0;
            if (hour == 12)
            {
                hour = 0;
            }
            hourAngle = (hour * 30.0) + ((minute/60.0)*30.0);
            minuteAngle = minute * 6.0;
            if (hourAngle <= minuteAngle)
            {
                angle = minuteAngle - hourAngle;
            }
            else
            {
                angle = 360 - (hourAngle - minuteAngle);
            }
            return angle;
        }

        public static double calcAngle(double h, double m)
        {
            if (h == 12)
            {
                h = 0;
            }
                
            double hour_angle = (0.5 * (h * 60 + m));
            double minute_angle = (6 * m);

            double angle = Math.Abs(hour_angle - minute_angle);
            // smaller angle of two possible angles 
            angle = Math.Min(360 - angle, angle);
            return angle;
        }
    }
}
