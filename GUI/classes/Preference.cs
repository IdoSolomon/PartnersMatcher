using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.classes
{
    public class Preference
    {
        public string userEmail { get; set; }
        public string sex { get; set; }
        public int minAge { get; set; }
        public int maxAge { get; set; }
        public int maxPrice { get; set; }
        public string location { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public DateTime startHour { get; set; }
        public DateTime endHour { get; set; }
        public int numberOfParticipants { get; set; }
        public string difficulty { get; set; }
        public string smokes { get; set; }
        public string pet { get; set; }
        string frequency { get; set; }
        bool[] days { get; set; }
    }
}
