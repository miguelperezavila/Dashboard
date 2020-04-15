
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
                    DateTime = "2014",
                    StatePictureRGB = "#00000",
                },
                new DeviceListItemViewModel
                {
                    IMEI = "352656100042210",
                    State = "OFF",
                    DateTime = "2014",
                    StatePictureRGB = "#00000",
                },
                new DeviceListItemViewModel
                {
                    IMEI = "352656100042210",
                    State = "ON",
                    DateTime = "2014",
                    StatePictureRGB = "#00000",
                },
                new DeviceListItemViewModel
                {
                    IMEI = "352656100042210",
                    State = "ON",
                    DateTime = "2014",
                    StatePictureRGB = "#00000",
                },
                new DeviceListItemViewModel
                {
                    IMEI = "352656100042210",
                    State = "OFF",
                    DateTime = "2014",
                    StatePictureRGB = "#00000",
                },
                new DeviceListItemViewModel
                {
                    IMEI = "352656100042210",
                    State = "ON",
                    DateTime = "2014",
                    StatePictureRGB = "#00000",
                },
                new DeviceListItemViewModel
                {
                    IMEI = "352656100042210",
                    State = "ON",
                    DateTime = "2014",
                    StatePictureRGB = "#00000",
                },
                new DeviceListItemViewModel
                {
                    IMEI = "352656100042210",
                    State = "OFF",
                    DateTime = "2014",
                    StatePictureRGB = "#00000",
                },
                new DeviceListItemViewModel
                {
                    IMEI = "352656100042210",
                    State = "ON",
                    DateTime = "2014",
                    StatePictureRGB = "#00000",
                },
                new DeviceListItemViewModel
                {
                    IMEI = "352656100042210",
                    State = "ON",
                    DateTime = "2014",
                    StatePictureRGB = "#00000",
                },
                new DeviceListItemViewModel
                {
                    IMEI = "352656100042210",
                    State = "OFF",
                    DateTime = "2014",
                    StatePictureRGB = "#00000",
                },
                new DeviceListItemViewModel
                {
                    IMEI = "352656100042210",
                    State = "ON",
                    DateTime = "2014",
                    StatePictureRGB = "#00000",
                }

            };
        }
        #endregion
    }
}
