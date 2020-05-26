using LiveCharts;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using Dashboard.DataModels;

namespace Dashboard
{
  
    public class LocationViewModel : ControlViewModel
    {

        #region properties


        public string Title { get; set; }
        
        public SeriesCollection Series { get; set; }

        public List<string> Items { get; set; }

        public string ItemSelected { get; set; }

        public DateTime DateSelected { get; set; }

        public Func<double, string> Formatter { get; set; }
        #endregion

        #region Command

        public ICommand UpdateCommand { get; set; }

        #endregion

        #region Constructor

        public LocationViewModel()
        {
            this.Title = "Nuevo Titulo";

            var dayConfig = Mappers.Xy<DateChartModel>()
                .X(dayModel => (double)dayModel.DateTime.Ticks / TimeSpan.FromHours(1).Ticks)
                .Y(dayModel => dayModel.Value);

            this.Series = new SeriesCollection(dayConfig);

            DateSelected = DateTime.Today;

            Items = MongoDBHelpers.GetDevicesNames();

            UpdateCommand = new RelayCommand(Update);
        }
        #endregion

        #region Private Helpers

        private void Update()
        {
            Series.Clear();

            LineSeries line = MongoDBHelpers.GetData(ItemSelected, DateSelected);
            
            Series.Add(line);

            Formatter = value => new System.DateTime((long)(value * TimeSpan.FromHours(1).Ticks)).ToString("t");
        }

        #endregion

        }
}
