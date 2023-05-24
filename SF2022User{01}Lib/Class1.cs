using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SF2022User_01_Lib
{
    public class Calculations
    {
        public static List<String> AvailablePeriods(TimeSpan[] startTimes, int[] durations,
            TimeSpan beginWorkingTime, TimeSpan endWorkingTime, int consultationTime) {

            int minutes; 
            List<string> notAvailable = new();
            List<string> available = new();
            

            for (int i = 0; i < startTimes.Length; i++)
            {
                minutes = startTimes[i].Minutes + durations[i];

                notAvailable.Add($"{startTimes[i]}-{new TimeSpan(startTimes[i].Hours, minutes,0)}");
                
            }

            TimeSpan currentTime = beginWorkingTime;
            int nMinutes = 0;
            TimeSpan oldTime = beginWorkingTime;

            while (currentTime.Hours != endWorkingTime.Hours) 
                {
               
                    oldTime = currentTime;
                    nMinutes = currentTime.Minutes + consultationTime;

                    currentTime = GetCurrentTime(currentTime, nMinutes);

                if (startTimes.Length > 0)
                {
                    if (MoreThanRestTime(currentTime,startTimes[0]))
                    {
                        oldTime = GetCurrentTime(new TimeSpan(startTimes[0].Hours, startTimes[0].Minutes, 0), durations[0]);
                        currentTime = GetCurrentTime(oldTime, nMinutes + durations[0]);
                        if (startTimes.Length > 1 &&

                        MoreThanRestTime(currentTime, startTimes[1]))
                            currentTime = startTimes[1];



                        if (startTimes.Length > 0) startTimes = startTimes.Skip(1).ToArray();
                        if (durations.Length > 0) durations = durations.Skip(1).ToArray();
                    }
                }




                available.Add($"{oldTime}-{currentTime}");

               
            }
                

            return available;

            
        
        }
        public static TimeSpan GetCurrentTime(TimeSpan currentTime, int nMinutes)
        {
            
            if (nMinutes < 60)
                currentTime = new TimeSpan(currentTime.Hours, nMinutes, 0);
            else
                currentTime = new TimeSpan(currentTime.Hours + 1, nMinutes - 60, 0);

            return currentTime;
        }
        public static bool MoreThanRestTime(TimeSpan currentTime, TimeSpan startTime)
        {
            if (currentTime.Hours >= startTime.Hours && currentTime.Minutes >= startTime.Minutes)
                return true;
            return false;
        }
    }
}
