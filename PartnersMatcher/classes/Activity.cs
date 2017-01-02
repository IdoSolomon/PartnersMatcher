using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnersMatcher.classes
{
    class Activity
    {
        int id;
        string name;
        int numberOfParticipants;
        string place;
        DateTime startHour;
        DateTime endHour;
        bool[] days;
        DateTime endDate;
        DateTime startDate;
        string difficulty;
        string frequency;
    }
}
