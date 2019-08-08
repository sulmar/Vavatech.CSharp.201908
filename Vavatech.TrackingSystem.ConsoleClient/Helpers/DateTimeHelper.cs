using Bogus.DataSets;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vavatech.TrackingSystem.ConsoleClient.Helpers
{
    public static class DateTimeHelper
    {
        public static bool IsHoliday(DateTime dateTime)
        {
            return 
                dateTime.DayOfWeek == DayOfWeek.Saturday ||
                dateTime.DayOfWeek == DayOfWeek.Sunday;
        }
    }

    public static class DateTimeExtensions
    {
        public static bool IsHoliday(this DateTime dateTime)
        {
            return
                dateTime.DayOfWeek == DayOfWeek.Saturday ||
                dateTime.DayOfWeek == DayOfWeek.Sunday;
        }

        public static DateTime AddWorkDays(this DateTime dateTime, int days)
        {
            return dateTime.AddDays(days);
        }
    }
}
