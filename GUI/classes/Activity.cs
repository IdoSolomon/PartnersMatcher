using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.classes
{
    public class Activity
    {
        public int id { get; set; }
        public string name { get; set; }
        public string field { get; set; }
        public string gender { get; set; }
        public int numberOfParticipants { get; set; }
        public string location { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public TimeSpan startTime { get; set; }
        public TimeSpan endTime { get; set; }
        public string difficulty { get; set; }
        public double price { get; set; }
        public string frequency { get; set; }
        public bool[] days { get; set; }

        public Activity() { }
    }
}
