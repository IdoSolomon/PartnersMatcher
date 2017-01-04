using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DataGridRecords
{
    public class ActivityRecord
    {
        public string Activity { get; set; }
        public string Catagory { get; set; }
        public int NumOfParticipate { get; set; }
        public string Place { get; set; }
        public DateTime StartsOn { get; set; }
        public DateTime FinishOn { get; set; }
        public TimeSpan StartHour { get; set; }
        public TimeSpan FinishHour { get; set; }
        public string Frequency { get; set; }
        public bool Sunday { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        
        
        public string Description { get; set; }
        public string Days { get; set; }

        public ActivityRecord(string category, string activity, string description, string place, DateTime startsOn, string frequency, string days)
        {
            Catagory = category;
            Activity = activity;
            Place = place;
            Description = description;
            StartsOn = startsOn;
            Frequency = frequency;
            Days = days;
        }

        public ActivityRecord(string activity, string catagory, int numOfParticipate, string place, DateTime startsOn, DateTime finishOn, TimeSpan startHour, TimeSpan finishHour, string frequency, bool sunday, bool monday, bool tuesday, bool wednesday, bool thursday, bool friday, bool saturday)
        {
            Activity = activity;
            Catagory = catagory;
            NumOfParticipate = numOfParticipate;
            Place = place;
            StartsOn = startsOn;
            FinishOn = finishOn;
            StartHour = startHour;
            FinishHour = finishHour;
            Frequency = frequency;
            Sunday = sunday;
            Monday = monday;
            Tuesday = tuesday;
            Wednesday = wednesday;
            Thursday = thursday;
            Friday = friday;
            Saturday = saturday;

        }
    }
}
