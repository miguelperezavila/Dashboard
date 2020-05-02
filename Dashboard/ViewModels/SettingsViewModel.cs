
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Text.Json;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using System.Windows.Controls;

namespace Dashboard
{
    public class SettingsViewModel : ControlViewModel
    {
        #region Public Properties

        /// <summary>
        /// The hour of the start time
        /// </summary>
        public string StartTimeHour { get; set; }

        /// <summary>
        /// The minute of the start time
        /// </summary>
        public string StartTimeMin { get; set; }

        /// <summary>
        /// The hour of the stop time
        /// </summary>
        public string StopTimeHour { get; set; }

        /// <summary>
        /// The minute of the stop time
        /// </summary>
        public string StopTimeMin { get; set; }

        /// <summary>
        /// The keep alive period
        /// </summary>
        public string KeepAlive { get; set; }

        /// <summary>
        /// Force the power off
        /// </summary>
        public bool PowerOFF { get; set; }

        /// <summary>
        /// Force the power on
        /// </summary>
        public bool PowerON { get; set; }


        public List<string> Items { get; set; }

        public string ItemSelected { get; set; }


        #endregion

        #region

        public ICommand SendCommand { get; set; }

        #endregion

        public SettingsViewModel()
        {
            Items = MongoDBHelpers.GetDevicesNames();

            SendCommand = new RelayCommand(SendConfiguration);
        }


        #region Private Helpers

        private void SendConfiguration()
        {
            var date = DateTimeOffset.Now.ToLocalTime();

            if( (StartTimeHour != null) || (StopTimeHour != null) || PowerOFF || PowerON || (KeepAlive != null) )
            {
                var document = new BsonDocument
            {   {"CommandDate", DateTime.Now} };

                if (StartTimeHour != null && StartTimeMin != null && (StartTimeHour != "") && (StartTimeMin != "") )
                {
                    DateTime tmp = new DateTime(date.Year, date.Month, date.Day, TimeLimits(Int32.Parse(StartTimeHour)), TimeLimits(Int32.Parse(StartTimeMin)), 0);
                    
                    document.Add("StartTime", tmp);
                }

                if (StopTimeHour != null && StopTimeMin != null && (StopTimeHour != "") && (StopTimeMin != ""))
                {
                    document.Add("StopTime", new DateTime(date.Year, date.Month, date.Day, TimeLimits(Int32.Parse(StopTimeHour)), TimeLimits(Int32.Parse(StopTimeMin)), 0));
                }
                if( PowerOFF )
                {
                    document.Add("PowerOFF", PowerConvert(PowerOFF));
                }
                
                if( PowerON )
                {
                    document.Add("PowerON", PowerConvert(PowerON));
                }
                
                if ( (KeepAlive != null) && (KeepAlive != "") )
                {
                    document.Add("KeepAlive", KeepAliveConvert(KeepAlive));
                }

                if( ItemSelected != null )
                {
                    MongoDBHelpers.InsertDocument(ItemSelected, document);
                }
            }
        }

        
        private string WrapData()
        {
            DataWrapper dataWrapper = new DataWrapper();

            dataWrapper.StartTime = TimeWrapper(TimeLimits(Int32.Parse(StartTimeHour)), TimeLimits(Int32.Parse(StartTimeMin)));

            dataWrapper.StopTime = TimeWrapper(TimeLimits(Int32.Parse(StopTimeHour)), TimeLimits(Int32.Parse(StopTimeMin)));

            dataWrapper.PowerOFF = PowerConvert(PowerOFF);

            dataWrapper.PowerON = PowerConvert(PowerON);

            dataWrapper.KeepAlive = KeepAliveConvert(KeepAlive);

            return JsonSerializer.Serialize(dataWrapper);

        }

        private int TimeLimits( int time )
        {
            int tmp = time;
            if( time > 24)
            {
                tmp = 24;
            }
            else if( time < 0)
            {
                tmp = 0;
            }

            return tmp;
        }
        private string TimeWrapper( int hour, int min )
        {

            DateTime dt = DateTime.Today;

            TimeSpan t = new TimeSpan(dt.DayOfYear, hour, min, 0);

            DateTime d = new DateTime(t.Ticks);
            var utc = d.ToUniversalTime();

            return utc.ToString();
        }

        private string PowerConvert( bool power )
        {
            if( power )
            {
                return "ON";
            }
            else
            {
                return "OFF";
            }

        }

        private string KeepAliveConvert( string keep )
        {
            string res = keep;
            int tmp = 0;
            if( !(keep == null))
            {
                tmp = Int32.Parse(keep);
            }
            else
            {
                res = "60";
            }

            if( tmp < 0)
            {
                res = "0"; 
            }

            return res;
            
        }


        /// <summary>
        /// Wrapper class for the JSON Serializer
        /// </summary>
        private class DataWrapper
        {
            /// <summary>
            /// Force ON value for the JSON
            /// </summary>
            public string PowerON { get; set; }

            /// <summary>
            /// Force OFF value
            /// </summary>
            public string PowerOFF { get; set; }

            

            /// <summary>
            /// The keep Alive value
            /// </summary>
            public string KeepAlive { get; set; }
            
            /// <summary>
            /// The startTime
            /// </summary>
            public string StartTime { get; set; }

            /// <summary>
            /// The StopTime
            /// </summary>
            public string StopTime { get; set; }
        }
        #endregion
    }
}
