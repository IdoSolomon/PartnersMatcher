﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.classes
{
    /// <summary>
    /// user object
    /// </summary>
    public class User
    {
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string password { get; set; }//keep this?
        public DateTime birthDate { get; set; }
        public string sex { get; set; }
        public string phoneNum { get; set; }
        public string location { get; set; }
        public Boolean smokes { get; set; }
        public Boolean pet { get; set; }
        public string resume { get; set; }
    }
}
