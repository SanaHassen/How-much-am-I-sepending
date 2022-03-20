using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class MonthBreakout
    {
        public string Month {get;set; }
        public float Total { get; set; }

        public MonthBreakout(string month, float total)
        {
            Month = month;
            Total = total;
        }

    }
}
