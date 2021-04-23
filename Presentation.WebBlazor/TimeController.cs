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
        //Enda undantaget är när user ändrar en spinbox, då kör jag WriteSolarTimeToUnix


        //För att använda internt
        public Int64 StartTimeUnix { get; set; }
        public Int64 EndTimeUnix { get; set; }
        public Int64 IntervallTime { get; set; }

        private DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);

        //Time representation as year/month/day/hour/minute/second. I call this SolarTime 
        #region
        public int StartYear { get; set; }
        public int StartMonth { get; set; }
        public int StartDay { get; set; }
        public int StartHour { get; set; }
        public int StartMinute { get; set; }
        public int StartSecond { get; set; }
        public int EndYear { get; set; }
        public int EndMonth { get; set; }
        public int EndDay { get; set; }
        public int EndHour { get; set; }
        public int EndMinute { get; set; }
        public int EndSecond { get; set; }
        #endregion

        //1619005552045
        //2021-04-21 11:45:52
        //1415115303410
        //2014-11-04 15:35:03
        //OBS: Jag skall lägga till miliseconds även om jag inte avnänder det.


        public void WriteUnixToSolartime_StartTime()
        {
            DateTime time = dtDateTime.AddMilliseconds(1415115303410);
            StartYear = time.Year;
            StartMonth = time.Month;
            StartDay = time.Day;
            StartHour = time.Hour;
            StartMinute = time.Minute;
            StartSecond = time.Second;
            Debug.WriteLine($"In WriteUnixToSolartime: {StartYear} {StartMonth} {StartDay} {StartHour} {StartMinute} {StartSecond}");
        }


        public void WriteSolarTimeToUnix_StartTime()
        {
            StartYear = 2014;
            StartMonth = 11;
            StartDay = 4;
            StartHour = 15;
            StartMinute = 35;
            StartSecond = 3;

            DateTime dtDateTime2 = new DateTime(StartYear, StartMonth, StartDay, StartHour, StartMinute, StartSecond, 410, System.DateTimeKind.Utc);
            //Int64 n = dtDateTime2.Total

            //(long)dtDateTime2.TotalMilliseconds

            var test = (long)(dtDateTime2 - new DateTime(1970, 1, 1)).TotalMilliseconds;



            Debug.WriteLine($"In WriteSolarTimeToUnix: {test}");

            //            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            //            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
        }

        //public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        //{
        //    // Unix timestamp is seconds past epoch
        //    System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
        //    dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
        //    return dtDateTime;
        //}

        //long unixTimeStampInMilliseconds = dateTimeOffset.ToUnixTimeMilliseconds();



    }
}
