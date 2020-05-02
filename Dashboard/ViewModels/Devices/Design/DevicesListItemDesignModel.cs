
namespace Dashboard
{
    /// <summary>
    /// The design of the DevicesListItemViewmodel
    /// </summary>
    public class DevicesListItemDesignModel : DeviceListItemViewModel
    {

        #region Singleton

        public static DevicesListItemDesignModel Instance => new DevicesListItemDesignModel();

        #endregion
        
        #region Constructor

        public DevicesListItemDesignModel()
        {
            IMEI = "352656100042210";
            State = "ON";
            Date = "2015";
            StatePictureRGB = "#00000";
        }
        #endregion
    }
}
