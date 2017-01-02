using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DataGridRecords
{
    public class GroupMessageRecord
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Subject { get; set; }
        public DateTime SendDate { get; set; }
        public string Contents { get; set; }

        public GroupMessageRecord(string _LastName, string _FirstName, string _Subject, DateTime _SendDate, string _Contents)
        {
            LastName = _LastName;
            FirstName = _FirstName;
            Subject = _Subject;
            SendDate = _SendDate;
            Contents = _Contents;
        }
    }
}
