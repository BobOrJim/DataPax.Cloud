using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.WebBlazor
{
    public class TimeController
    {
        //Strategi
        //Alltid använda Unix
        //Enda undantaget är när user ändrar en spinbox, då kör jag WriteSolarTimeToUnix, och sedan återgår till unix.

        public Int64 StartTimeUnix { get; set; }
        public Int64 EndTimeUnix { get; set; }
        public Int64 IntervallTime { get; set; }

        private DateTime dateTime;  // = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);

        //Time representation as year/month/day/hour/minute/second/millisecond. I call this SolarTime 
        #region
        public int StartYear { get; set; }
        public int StartMonth { get; set; }
        public int StartDay { get; set; }
        public int StartHour { get; set; }
        public int StartMinute { get; set; }
        public int StartSecond { get; set; }
        public int StartMilliseconds { get; set; }
        public int EndYear { get; set; }
        public int EndMonth { get; set; }
        public int EndDay { get; set; }
        public int EndHour { get; set; }
        public int EndMinute { get; set; }
        public int EndSecond { get; set; }
        public int EndMilliseconds { get; set; }
        #endregion

        //1619005552045
        //2021-04-21 11:45:52
        //1415115303410
        //2014-11-04 15:35:03



        public void WriteUnixToSolartime_StartTime()
        {
            dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            DateTime time = dateTime.AddMilliseconds(StartTimeUnix);
            StartYear = time.Year;
            StartMonth = time.Month;
            StartDay = time.Day;
            StartHour = time.Hour;
            StartMinute = time.Minute;
            StartSecond = time.Second;
            StartMilliseconds = time.Millisecond;
            //Debug.WriteLine($"In WriteUnixToSolartime_StartTime: {StartYear} {StartMonth} {StartDay} {StartHour} {StartMinute} {StartSecond} {StartMilliseconds} ");
        }

        public void WriteUnixToSolartime_EndTime()
        {
            dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            DateTime time = dateTime.AddMilliseconds(EndTimeUnix);
            EndYear = time.Year;
            EndMonth = time.Month;
            EndDay = time.Day;
            EndHour = time.Hour;
            EndMinute = time.Minute;
            EndSecond = time.Second;
            EndMilliseconds = time.Millisecond;
            //Debug.WriteLine($"In WriteUnixToSolartime_EndTime: {StartYear} {StartMonth} {StartDay} {StartHour} {StartMinute} {StartSecond} {StartMilliseconds} ");
        }

        public void WriteSolarTimeToUnix_StartTime()
        {
            //StartYear = 2014;
            //StartMonth = 11;
            //StartDay = 4;
            //StartHour = 15;
            //StartMinute = 35;
            //StartSecond = 3;
            //StartMilliseconds = 410;
            dateTime = new DateTime(StartYear, StartMonth, StartDay, StartHour, StartMinute, StartSecond, StartMilliseconds, System.DateTimeKind.Utc);
            StartTimeUnix = (long)(dateTime - new DateTime(1970, 1, 1)).TotalMilliseconds;
            //Debug.WriteLine($"In WriteSolarTimeToUnix_StartTime: {StartTimeUnix}");
        }

        public void WriteSolarTimeToUnix_EndTime()
        {
            //StartYear = 2014;
            //StartMonth = 11;
            //StartDay = 4;
            //StartHour = 15;
            //StartMinute = 35;
            //StartSecond = 3;
            //StartMilliseconds = 410;
            dateTime = new DateTime(EndYear, EndMonth, EndDay, EndHour, EndMinute, EndSecond, EndMilliseconds, System.DateTimeKind.Utc);
            EndTimeUnix = (long)(dateTime - new DateTime(1970, 1, 1)).TotalMilliseconds;
            //Debug.WriteLine($"In WriteSolarTimeToUnix_EndTime: {EndTimeUnix}");
        }


    }
}
