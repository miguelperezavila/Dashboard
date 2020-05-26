using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.DataModels
{
    public class DateChartModel
    {
        public DateTime DateTime { get; set; }
        public double Value { get; set; }

        public DateChartModel( DateTime newDate, double newValue )
        {
            DateTime = newDate;
            Value = newValue;
        }
    }
}
