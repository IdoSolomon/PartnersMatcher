using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DataGridRecords
{
    public class RecommendedActivityRecord
    {
        public string Catagory { get; set; }
        public string Activity { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }

        public DateTime StartsOn { get; set; }
        public string Frequency { get; set; }
        public string Days { get; set; }

        public RecommendedActivityRecord(string category, string activity, string description, string place, DateTime startsOn, string frequency, string days)
        {
            Catagory = category;
            Activity = activity;
            Place = place;
            Description = description;
            StartsOn = startsOn;
            Frequency = frequency;
            Days = days;
        }
    }
}
