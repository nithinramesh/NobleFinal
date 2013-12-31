using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NobleEntity
{
    public class CalendarSchedularEntity : BaseEntity
    {
        public int Event_id { get; set; }
        public int User_id { get; set; }
        public string Event_Desc { get; set; }
        public string Start_date { get; set; }
        public string End_date { get; set; }
        public string Start_time { get; set; }
        public string End_time { get; set; }
    }
}
