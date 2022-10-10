using System;
using System.Collections.Generic;
using System.Text;

namespace _05.DateModifier
{
    public static class DateModifier
    {

        public static int DateModifierMethod(string startingDate, string endingDate)
        {

            DateTime startDate = DateTime.Parse(startingDate);
            DateTime endDate = DateTime.Parse(endingDate);



            TimeSpan timeSpan = endDate - startDate;

            return Math.Abs(timeSpan.Days);
        }

    }
}
