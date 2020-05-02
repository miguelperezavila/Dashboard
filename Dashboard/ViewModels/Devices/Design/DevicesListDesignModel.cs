
using System.Collections.Generic;

namespace Dashboard
{
    /// <summary>
    /// The design of the DevicesListItemViewmodel
    /// </summary>
    public class DevicesListDesignModel : DeviceListViewModel
    {

        #region Singleton

        public static DevicesListDesignModel Instance => new DevicesListDesignModel();

        #endregion
        
        #region Constructor

        public DevicesListDesignModel()
        {
            Items = new List<DeviceListItemViewModel>()
            {
                new DeviceListItemViewModel
                {
                    IMEI = "352656100042210",
                    State = "ON",
                    Date = "2015",
                    StatePictureRGB = "#00000",
                },
                new DeviceListItemViewModel
                {
                    IMEI = "352656100042210",
                    State = "OFF",
                    Date = "2015",
                    StatePictureRGB = "#00000",
                },
                new DeviceListItemViewModel
                {
                    IMEI = "352656100042210",
                    State = "ON",
                    Date = "2015",
                    StatePictureRGB = "#00000",
                },
                new DeviceListItemViewModel
                {
                    IMEI = "352656100042210",
                    State = "ON",
                    Date = "2015",
                    StatePictureRGB = "#00000",
                }
            };
        }
        #endregion
    }
}
