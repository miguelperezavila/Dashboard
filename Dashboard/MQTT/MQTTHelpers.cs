using System;
using System.Text;
using uPLibrary.Networking.M2Mqtt;

namespace Dashboard
{
    public static class MQTTHelpers
    {
        #region MQTT Broker properties
        
        /// <summary>
        /// the broker direction
        /// </summary>
        private static string broker { get; set; }

        /// <summary>
        /// The user
        /// </summary>
        private static string user { get; set; }

        /// <summary>
        /// The private pass
        /// </summary>
        private static string pass { get; set; }

        /// <summary>
        /// The topic header
        /// </summary>
        private static string topicHeader = "RBZ/NODE4G/1.0/{0}/CONFIG";
        #endregion

        public static void Publish(string topic, string message )
        {
            byte[] msg = Encoding.ASCII.GetBytes(message);

            string realTopic = string.Format(topicHeader, topic);
            MqttClient client = new MqttClient(broker);
            client.Connect(Guid.NewGuid().ToString(), user, pass);

            client.Publish(topic, msg);
        }

    }
}
