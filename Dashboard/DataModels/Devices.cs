using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard
{
    public class Devices
    {

        /// <summary>
        /// The serial Number;
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// The State;
        /// </summary>
        public bool State { get; set; }

        /// <summary>
        /// The time of the state update
        /// </summary>
        public string Time { get; set; }
    }
}
