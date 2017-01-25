using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DataGridRecords
{
    /// <summary>
    /// activity object for datagrid representation
    /// </summary>
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

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="category">catagory name</param>
        /// <param name="activity">activity name</param>
        /// <param name="description">activity description</param>
        /// <param name="place">activity location</param>
        /// <param name="startsOn">activity start date</param>
        /// <param name="frequency">activity frequency</param>
        /// <param name="days">activity days</param>
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
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="dataRow">datarow from SQL query</param>
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
            Sunday = Convert.ToBoolean(dataRow[12]);
            Monday = Convert.ToBoolean(dataRow[13]);
            Tuesday = Convert.ToBoolean(dataRow[14]);
            Wednesday = Convert.ToBoolean(dataRow[15]);
            Thursday = Convert.ToBoolean(dataRow[16]);
            Friday = Convert.ToBoolean(dataRow[17]);
            Saturday = Convert.ToBoolean(dataRow[18]);
            Days = "";
            bool first = true;
            if (Sunday)
            {
                Days += "SUN";
                first = false;
            }
            if (Monday)
            {
                if (!first)
                {
                    Days += ", ";
                }
                Days += "MON";
                if (first)
                    first = false;
            }
            if (Tuesday)
            {
                if (!first)
                {
                    Days += ", ";
                }
                Days += "TUE";
                if (first)
                    first = false;
            }
            if (Wednesday)
            {
                if (!first)
                {
                    Days += ", ";
                }
                Days += "WED";
                if (first)
                    first = false;
            }
            if (Thursday)
            {
                if (!first)
                {
                    Days += ", ";
                }
                Days += "THU";
                if (first)
                    first = false;
            }
            if (Friday)
            {
                if (!first)
                {
                    Days += ", ";
                }
                Days += "FRI";
                if (first)
                    first = false;
            }
            if (Saturday)
            {
                if (!first)
                {
                    Days += ", ";
                }
                Days += "SAT";
                if (first)
                    first = false;
            }
        }
    }
}
