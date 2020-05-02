using LiveCharts;
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
        
        public SeriesCollection Series { get; set; }
        
        public LocationViewModel()
        {
            this.Title = "Nuevo Titulo";

            this.Series = new SeriesCollection();
        }


    }
}
