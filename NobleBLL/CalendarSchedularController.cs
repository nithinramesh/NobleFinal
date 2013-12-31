using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NobleDAL;
using NobleEntity;

namespace NobleBLL
{
    public class CalendarSchedularController
    {
        CalendarSchedularDBAccess CalendarSchedularAccessObj = null;

        public CalendarSchedularController()
        {
            CalendarSchedularAccessObj = new CalendarSchedularDBAccess();
        }


        /// <summary>
        ///LoadEvents
        /// </summary>
        /// <returns></returns>
        public List<CalendarSchedularEntity> LoadEvents(CalendarSchedularEntity memMedEn)
        {
            return CalendarSchedularAccessObj.LoadEvents(memMedEn);
        }

        public bool InsertEvents(CalendarSchedularEntity memMedEn)
        {
           return CalendarSchedularAccessObj.InsertEvents(memMedEn);
        }

        public bool DeleteEvents(CalendarSchedularEntity memMedEn)
        {
            return CalendarSchedularAccessObj.DeleteEvents(memMedEn);
        }
        public bool UpdateEvents(CalendarSchedularEntity memMedEn)
        {
            return CalendarSchedularAccessObj.UpdateEvents(memMedEn);
        }
        
    }
}
