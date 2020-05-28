using LiveCharts;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using Dashboard.DataModels;
using System.Data;

namespace Dashboard
{
  
    public class LocationViewModel : ControlViewModel
    {

        #region properties


        public string Title { get; set; }
        
        public SeriesCollection Series { get; set; }
        public DataTable Table { get; set; }

        public string[] Number { get; set; }
        public string[] Configuration { get; set; }

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
            this.Table = createTable();

            DateSelected = DateTime.Today;

            Items = MongoDBHelpers.GetDevicesNames();

            UpdateCommand = new RelayCommand(Update);
        }
        #endregion

        #region Private Helpers

        private DataTable createTable()
        {
            DataTable Table = new DataTable();

            DataColumn DateCommand = new DataColumn("DateCommand", typeof(string));
            DataColumn Start = new DataColumn("StartTime", typeof(string));
            DataColumn Stop = new DataColumn("StopTime", typeof(string));
            DataColumn Off = new DataColumn("ForceOFF", typeof(string));
            DataColumn On = new DataColumn("ForceON", typeof(string));

            Table.Columns.Add(DateCommand);
            Table.Columns.Add(Start);
            Table.Columns.Add(Stop);
            Table.Columns.Add(Off);
            Table.Columns.Add(On);

            Table.Rows.Clear();

            return Table;
        }
        private void Update()
        {

            //LineSeries line = 
            Series.Clear();
            
            MongoDBHelpers.GetData(ItemSelected, DateSelected, Series);

            MongoDBHelpers.GetCommandData(ItemSelected, DateSelected, Table );

            Formatter = value => new System.DateTime((long)(value * TimeSpan.FromHours(1).Ticks)).ToString("t");

            //Series.Add(line);


        }

        #endregion

        }
}
