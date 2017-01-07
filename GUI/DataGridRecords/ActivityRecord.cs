using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DataGridRecords
{
    public class ActivityRecord
    {
        private DataRow dataRow;

        public string Activity { get; set; }
        public string Catagory { get; set; }
        public int NumOfParticipate { get; set; }
        public string Place { get; set; }
        public DateTime StartsOn { get; set; }
        public DateTime FinishOn { get; set; }
        public TimeSpan StartHour { get; set; }
        public TimeSpan FinishHour { get; set; }
        public string Difficulty { get; set; }
        public string Frequency { get; set; }
        public string Price { get; set; }
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

        public ActivityRecord(string activity, string catagory, int numOfParticipate, string place, DateTime startsOn, DateTime finishOn, TimeSpan startHour, TimeSpan finishHour, string difficulty, string frequency, string price, bool sunday, bool monday, bool tuesday, bool wednesday, bool thursday, bool friday, bool saturday)
        {
            Activity = activity;
            Catagory = catagory;
            NumOfParticipate = numOfParticipate;
            Place = place;
            StartsOn = startsOn;
            FinishOn = finishOn;
            StartHour = startHour;
            FinishHour = finishHour;
            Difficulty = difficulty;
            Frequency = frequency;
            Price = price;
            Sunday = sunday;
            Monday = monday;
            Tuesday = tuesday;
            Wednesday = wednesday;
            Thursday = thursday;
            Friday = friday;
            Saturday = saturday;
            Days = "";
        }

        public ActivityRecord(DataRow dataRow)
        {
            Activity = (string)dataRow[1];
            Catagory = (string)dataRow[2];
            NumOfParticipate = (int)dataRow[3];
            Place = (string)dataRow[4];
            StartsOn = ((DateTime)dataRow[5]).Date;
            FinishOn = ((DateTime)dataRow[6]).Date;
            StartHour = ((DateTime)dataRow[7]).TimeOfDay;
            FinishHour = ((DateTime)dataRow[8]).TimeOfDay;
            Difficulty = (string)dataRow[9];
            Price = ((decimal)dataRow[10]).ToString();
            Frequency = (string)dataRow[11];
            Sunday = false;
            Monday = false;
            Tuesday = false;
            Wednesday = false;
            Thursday = false;
            Friday = false;
            Saturday = false;
            Days = "";
        }
    }
}
