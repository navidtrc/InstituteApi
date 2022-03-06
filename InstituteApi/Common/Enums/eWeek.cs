using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InstituteApi.Common.Enums
{
    public enum eWeek
    {
        Saturday = 1,
        Sunday = 2,
        Monday = 4,
        Tuesday = 8,
        Wednesday = 16,
        Thursday = 32,
        Friday = 64,
    }
    public static class WeekExtension
    {
        public static int ToWeekModel(this List<int> weeks)
        {
            int result = 0;
            weeks.ForEach(week =>
            {
                switch (week)
                {
                    case 1:
                        result += (int)eWeek.Saturday;
                        break;
                    case 2:
                        result += (int)eWeek.Sunday;
                        break;
                    case 3:
                        result += (int)eWeek.Monday;
                        break;
                    case 4:
                        result += (int)eWeek.Tuesday;
                        break;
                    case 5:
                        result += (int)eWeek.Wednesday;
                        break;
                    case 6:
                        result += (int)eWeek.Thursday;
                        break;
                    case 7:
                        result += (int)eWeek.Friday;
                        break;
                }
            });
            return result;
        }

        public static List<int> ToWeekList(this int weekdays)
        {
            List<int> weeks = new List<int>();
            if ((weekdays & (int)eWeek.Saturday) > 0)
                weeks.Add(1);
            if ((weekdays & (int)eWeek.Sunday) > 0)
                weeks.Add(2);
            if ((weekdays & (int)eWeek.Monday) > 0)
                weeks.Add(3);
            if ((weekdays & (int)eWeek.Tuesday) > 0)
                weeks.Add(4);
            if ((weekdays & (int)eWeek.Wednesday) > 0)
                weeks.Add(5);
            if ((weekdays & (int)eWeek.Thursday) > 0)
                weeks.Add(6);
            if ((weekdays & (int)eWeek.Friday) > 0)
                weeks.Add(7);
            return weeks;
        }
    }
}
