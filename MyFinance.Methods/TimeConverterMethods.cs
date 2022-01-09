using System;
using System.Collections.Generic;

namespace MyFinance.Methods
{
    public static class TimeConverterMethods
    {
        private static readonly DateTime _timeStampStaringDateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime ConvertTimeStampToDateTime(int timeStamp)
        {
            return _timeStampStaringDateTime.AddSeconds(timeStamp);
        }

        public static int ConvertDateTimeToTimeStamp(DateTime datetime)
        {
            return (int)datetime.Subtract(_timeStampStaringDateTime).TotalSeconds;
        }

        public static int CountDayOfWeekForDuration(DateTime startDate, DateTime endDate, DayOfWeek dayOfWeek)
        {
            int dayOfWeekCount = 0;

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1.0))
            {
                if (date.DayOfWeek == dayOfWeek)
                {
                    dayOfWeekCount++;
                }
            }

            return dayOfWeekCount;
        }

        public static IEnumerable<DateTime> DatesDayOfWeekForDuration(DateTime startDate, DateTime endDate, DayOfWeek dayOfWeek)
        {
            IList<DateTime> datetimes = new List<DateTime>();

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1.0))
            {
                if (date.DayOfWeek == dayOfWeek)
                {
                    datetimes.Add(date.Date);
                }
            }

            return datetimes;
        }
    }
}
