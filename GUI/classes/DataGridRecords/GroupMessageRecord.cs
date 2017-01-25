using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DataGridRecords
{
    /// <summary>
    /// group message object for datagrid representation
    /// </summary>
    public class GroupMessageRecord
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Subject { get; set; }
        public DateTime SendDate { get; set; }
        public string Contents { get; set; }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="_LastName">sender's last name</param>
        /// <param name="_FirstName">sender's first name</param>
        /// <param name="_Subject">message subject</param>
        /// <param name="_SendDate">send date</param>
        /// <param name="_Contents">message contents</param>
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
