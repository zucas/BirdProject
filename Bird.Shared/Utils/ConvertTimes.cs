using System;

namespace Bird.Shared.Utils
{
    public static class ConvertTimes
    {
        public static int EetToMinutes(string eet)
        {
            int minutes = int.Parse(eet.Substring(2));
            int hours = int.Parse(eet.Substring(0, 2));

            return (hours * 60) + minutes;
        }
        public static DateTime EobtToDateTime(string eobt, DateTime day)
        {
            int minutes = int.Parse(eobt.Substring(2));
            int hours = int.Parse(eobt.Substring(0, 2));
            return new DateTime(
            day.Year,
            day.Month,
            day.Day,
            hours,
            minutes,
            0,
            0,
            day.Kind
            );
        }
    }
}