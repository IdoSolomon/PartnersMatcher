using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.classes
{
    public class Activity
    {
        int id { get; set; }
        string name { get; set; }
        string field { get; set; }
        int numberOfParticipants { get; set; }
        string location { get; set; }
        DateTime startDate { get; set; }
        DateTime endDate { get; set; }
        DateTime startTime { get; set; }
        DateTime endTime { get; set; }
        string difficulty { get; set; }
        int price { get; set; }
        string frequency { get; set; }
        bool[] days { get; set; }
    }
}
