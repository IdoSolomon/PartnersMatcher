using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.classes
{
    /// <summary>
    /// user preferences object
    /// </summary>
    public class Preference
    {
        /// <summary>
        /// ctor, sets the bool array
        /// </summary>
        public Preference()
        {
            days = new bool[7];
        }
        public string userEmail { get; set; }
        public string sex { get; set; }
        public int minAge { get; set; }
        public int maxAge { get; set; }
        public int maxPrice { get; set; }
        public string location { get; set; }
        public TimeSpan startHour { get; set; }
        public TimeSpan endHour { get; set; }
        public int numberOfParticipants { get; set; }
        public string difficulty { get; set; }
        public Boolean smokes { get; set; }
        public Boolean pet { get; set; }
        public string frequency { get; set; }
        public bool[] days { get; set; }
    }
}
