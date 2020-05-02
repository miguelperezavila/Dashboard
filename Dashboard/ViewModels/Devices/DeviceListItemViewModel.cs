
using System;

namespace Dashboard
{
    /// <summary>
    /// View model for each device list item 
    /// </summary>
    public class DeviceListItemViewModel : BaseViewModel
    {
        /// <summary>
        /// The serial number
        /// </summary>
        public string IMEI { get; set; }

        /// <summary>
        /// The state of the device
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Time of the last state update
        /// </summary>
        public string Date { get; set; } 
        
        /// <summary>
        /// Convert the state to a color
        /// </summary>
        public string StatePictureRGB { get; set; }
    }
}
