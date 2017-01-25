using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DataGridRecords
{
    /// <summary>
    /// activity catagory object for datagrid representation
    /// </summary>
    public class ActivityCatagory
    {
        public string Catagory { get; set; }
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="_Catagory">catagory name</param>
        public ActivityCatagory(string _Catagory)
        {
            Catagory = _Catagory;
        }
    }
}
