using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard
{
    public class DevicesViewModel : ControlViewModel
    {
        public List<DeviceListItemViewModel> Items { get; set; }

        #region Constructor

        /// <summary>
        /// constructor
        /// </summary>
        public DevicesViewModel()
        {
            Items = MongoDBHelpers.GetDevices();

        }

        #endregion
    }
}
