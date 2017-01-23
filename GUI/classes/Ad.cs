using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.classes
{
    public class Ad : Preference
    {
        public DateTime postTime { get; set; }
        public DateTime postHour { get; set; }
        public DateTime lastUpdate { get; set; }
    }
}
