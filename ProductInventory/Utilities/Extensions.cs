using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory.Utilities
{
    public static class Extensions
    {
        public static List<string> GetAllMonthNames()
        {
            var monthNames = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
            List<string> lst = new List<string>();
            lst.AddRange(monthNames);
            return lst;
        }
    }
}
