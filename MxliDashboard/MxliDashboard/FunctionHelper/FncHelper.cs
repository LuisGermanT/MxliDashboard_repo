using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MxliDashboard.FunctionHelper
{
    public class FncHelper
    {
        //Returns Week number 
        public int GetWeekNumber(string pstDt)
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int wkNum = ciCurr.Calendar.GetWeekOfYear(DateTime.Parse(pstDt), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            //if (wkNum == 53)
            //    wkNum = 1;

            return wkNum;
        }

        //Returns the number of the day of the week (sunday = 0... saturday = 6)
        public int GetDayOfWk(string pstDt)
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int dy = (int)ciCurr.Calendar.GetDayOfWeek(DateTime.Parse(pstDt));
            return dy;
        }

        //Returns Saturday
        public DateTime GetSaturday(DateTime dt)
        {
            DateTime stdy;
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            DayOfWeek dow = DayOfWeek.Sunday;
            
            int diff = (int)dt.DayOfWeek - (int)dow;
            DateTime bWk = dt.AddDays(diff * -1);

            stdy = bWk.AddDays(6);

            return stdy;
        }
    }
}