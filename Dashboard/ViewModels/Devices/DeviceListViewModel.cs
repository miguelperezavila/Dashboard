
using System.Collections.Generic;

namespace Dashboard
{
    /// <summary>
    /// View model for the overview device list
    /// </summary>
    public class DeviceListViewModel : BaseViewModel
    {
        public List<DeviceListItemViewModel> Items { get; set; }
    }
}
