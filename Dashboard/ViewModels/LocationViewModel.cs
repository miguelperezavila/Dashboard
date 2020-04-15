using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard
{
    public class LocationViewModel : ControlViewModel
    {

        public string Title { get; set; }
        public IList<DataPoint> Points { get; private set; }
        public LocationViewModel()
        {
            this.Title = "Nuevo Titulo";

            this.Points = new List<DataPoint>
            {
                new DataPoint(0,4),
                new DataPoint(1,4),
                new DataPoint(2,4),
                new DataPoint(3,4),
                new DataPoint(4,4),
                new DataPoint(5,4),
                new DataPoint(6,34),
                new DataPoint(7,78),
            };
        }
    }
}
