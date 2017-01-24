using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.classes
{
    /// <summary>
    /// request object
    /// </summary>
    public class Request
    {
        public string recipientEmail { get; set; }
        public string seekerEmail { get; set; }
        public int activityID { get; set; }
    }
}
