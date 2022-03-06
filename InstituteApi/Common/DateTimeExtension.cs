using System.Globalization;

namespace System
{
    public static class DateTimeExtension
    {
        public static string ToPersianDateTime(this DateTime dateTime)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            var year = persianCalendar.GetYear(dateTime);
            var month = persianCalendar.GetMonth(dateTime);
            var day = persianCalendar.GetDayOfMonth(dateTime);
            return $"{year}/{month}/{day} {dateTime.ToShortTimeString()}";
        }
    }
}
