using Dashboard.DataModels;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using System.Data;

namespace Dashboard
{
    public class MongoDBHelpers
    {
        /// <summary>
        /// Instance of the class for the singleton
        /// </summary>
        public static MongoDBHelpers Instance;

        /// <summary>
        /// The private connection, we just want to have one.
        /// </summary>
        private MongoClient ClientMongo { get; set; }

        /// <summary>
        /// Private constructor of the class
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        private MongoDBHelpers(string username, string password)
        {
            MongoCredential credential = MongoCredential.CreateCredential("tfmDatabase", username, password);

            MongoClientSettings mongoClientSettings = new MongoClientSettings
            {
                Credential = credential,
                Server = new MongoServerAddress("192.168.1.25", 40532)
            };

            ClientMongo = new MongoClient(mongoClientSettings);

        }

        /// <summary>
        /// Returns the instance of the class
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public static MongoClient GetInstance(string user, string pass)
        {
            if (Instance == null)
            {
                Instance = new MongoDBHelpers(user, pass);
                return Instance.ClientMongo;
            }
            else
            {
                return Instance.ClientMongo;
            }
        }

        /// <summary>
        /// Checks the if the user and password are good for the login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool CheckConnection(string username, string password)
        {
            var db = GetInstance(username, password).GetDatabase("tfmDatabase");

            

            var document = new BsonDocument
            {
                { "name", "MongoDB" }
            };
            try
            {
                var listCollection = db.ListCollections().ToList().First();
                var collection  = db.GetCollection<BsonDocument>(listCollection["name"].ToString());
                collection.InsertOne(document);
            }
            catch
            {
                Instance = null;
                return false;
            }

            var listCollection2 = db.ListCollections().ToList().First();
            var collection2 = db.GetCollection<BsonDocument>(listCollection2["name"].ToString());
            var deleteFilter = Builders<BsonDocument>.Filter.Eq("name", "MongoDB");
            collection2.DeleteOne(deleteFilter);
           
            return true;
        }

        /// <summary>
        /// In order to clean the instance when a log out is done
        /// </summary>
        public void RemoveInstance()
        {
            Instance = null;
        }

        public static void FindCollection()
        {
            var filter = Builders<BsonDocument>.Filter.Eq("topicVersion", "1.0");
            var sort = Builders<BsonDocument>.Sort.Descending("time");
            var sort2 = Builders<BsonDocument>.Sort.Ascending("time");
            
            var document = Instance.ClientMongo.GetDatabase("tfmDatabase").GetCollection<BsonDocument>("352656100042210").Find(filter).ToList();
            List<string> collections = new List<string>();
            

            foreach (var item in Instance.ClientMongo.GetDatabase("tfmDatabase").ListCollections().ToList())
            {
                
            }

            var document2 = Instance.ClientMongo.GetDatabase("tfmDatabase").GetCollection<BsonDocument>("352656100042210").Find(filter).Sort(sort).First();
            var document3 = Instance.ClientMongo.GetDatabase("tfmDatabase").GetCollection<BsonDocument>("352656100042210").Find(filter).Sort(sort2).First();


        }

        public static List<DeviceListItemViewModel> GetDevices()
        {
            List<DeviceListItemViewModel> Items = new List<DeviceListItemViewModel>();
            var filter = Builders<BsonDocument>.Filter.Eq("topicVersion", "1.0");
            var sort = Builders<BsonDocument>.Sort.Descending("time");
            foreach (var item in Instance.ClientMongo.GetDatabase("tfmDatabase").ListCollections().ToList())
            {
                DeviceListItemViewModel dev = new DeviceListItemViewModel();
                dev.IMEI = item["name"].ToString();
                var document = Instance.ClientMongo.GetDatabase("tfmDatabase").GetCollection<BsonDocument>(item["name"].ToString()).Find(filter).Sort(sort).First();

                dev.Date = ( (DateTime) (document["time"].AsBsonDateTime)).ToString("MM/dd/yyyy HH:mm:ss");
                dev.State = document["state"].ToString();

                Items.Add(dev);
            }

            return Items;
        }

        public static List<string> GetDevicesNames()
        {
            List<string> Items = new List<string>();
            foreach (var item in Instance.ClientMongo.GetDatabase("tfmDatabase").ListCollections().ToList())
            {
                Items.Add(item["name"].ToString());
            }

            return Items;
        }

        public static void InsertDocument( string collection, BsonDocument document )
        {
            Instance.ClientMongo.GetDatabase("tfmDatabase").GetCollection<BsonDocument>(collection).InsertOne(document);
        }

        public static void GetData( string collection, DateTime date, SeriesCollection series )
        {
            LineSeries line = new LineSeries();
            line.Values = new ChartValues<DateChartModel>();
            var filter = Builders<BsonDocument>.Filter.Gte("time", date) & Builders<BsonDocument>.Filter.Lte("time", date.AddDays(1));

            List<BsonDocument> values = Instance.ClientMongo.GetDatabase("tfmDatabase").GetCollection<BsonDocument>(collection).Find(filter).ToList();

            foreach ( var item in values)
            {
                //series[0].Values.Add(new DateChartModel((DateTime)item["time"].AsBsonDateTime, Convert(item["state"].AsString)));
                line.Values.Add(new DateChartModel((DateTime)item["time"].AsBsonDateTime, Convert(item["state"].AsString)));
            }

            series.Add(line);
            //return line;
        }

        public static void GetCommandData( string collection, DateTime date, DataTable Table )
        {
            var filter = Builders<BsonDocument>.Filter.Gte("CommandDate", date) & Builders<BsonDocument>.Filter.Lte("CommandDate", date.AddDays(1));
            List<BsonDocument> values = Instance.ClientMongo.GetDatabase("tfmDatabase").GetCollection<BsonDocument>(collection).Find(filter).ToList();
            //BsonDocument last;
            Table.Rows.Clear();

            if ( values.Count == 0 )
            {
                filter = Builders<BsonDocument>.Filter.Exists("CommandDate");
                var sort = Builders<BsonDocument>.Sort.Descending("CommandDate");

                var last = Instance.ClientMongo.GetDatabase("tfmDatabase").GetCollection<BsonDocument>(collection).Find(filter).Sort(sort).First();

                DataRow row = Table.NewRow();

                row[0] = ((DateTime)(last["CommandDate"].AsBsonDateTime)).ToString("dd/MM/yyyy HH:mm:ss");
                row[1] = ((DateTime)(last["StartTime"].AsBsonDateTime)).ToString("HH:mm:ss");
                row[2] = ((DateTime)(last["StopTime"].AsBsonDateTime)).ToString("HH:mm:ss");
                row[3] = last["PowerOFF"].AsString;
                row[4] = last["PowerON"].AsString;

                Table.Rows.Add(row);

            }
            else
            {
                foreach( var item in values )
                {
                    DataRow row = Table.NewRow();

                    row[0] = ((DateTime)(item["CommandDate"].AsBsonDateTime)).ToString("dd/MM/yyyy HH:mm:ss");
                    row[1] = ((DateTime)(item["StartTime"].AsBsonDateTime)).ToString("HH:mm:ss");
                    row[2] = ((DateTime)(item["StopTime"].AsBsonDateTime)).ToString("HH:mm:ss");
                    row[3] = item["PowerOFF"].AsString;
                    row[4] = item["PowerON"].AsString;

                    Table.Rows.Add(row);
                }
            }
        }

        public static double Convert( string state )
        {
            double res = 0.0;
            if( state.Equals("ON"))
            {
                res = 1.0;
            }
            else if (state.Equals("OFF"))
            {
                res = 0.0;
            }

            return res;
        }

    }
}
