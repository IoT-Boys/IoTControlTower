using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialMonitor
{
    [Serializable]
    public class XMLConfiguration
    {
        public string ButtonText { get; set; }
        public string PinMapping { get; set; }
    }
}
