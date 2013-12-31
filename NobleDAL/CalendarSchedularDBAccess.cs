using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using NobleEntity;

namespace NobleDAL
{
    public class CalendarSchedularDBAccess
    {
        public List<CalendarSchedularEntity> LoadEvents(CalendarSchedularEntity memMedEn)
        {

            List<CalendarSchedularEntity> listEvents = null;
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@user_id", memMedEn.User_id)
            };

            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_USR_SELECT_CALENDAR_SCHEDULAR", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count > 0)
                {
                    listEvents = new List<CalendarSchedularEntity>();
                    foreach (DataRow row in table.Rows)
                    {
                        CalendarSchedularEntity ueObj = new CalendarSchedularEntity();
                        ueObj.Event_id = Convert.ToInt16(row["Event_id"]);
                        ueObj.User_id = Convert.ToInt16(row["User_id"]);
                        ueObj.Event_Desc = Convert.ToString(row["Event_Desc"]);
                        ueObj.Start_date = Convert.ToString(row["Start_date"]);
                        ueObj.End_date = Convert.ToString(row["End_date"]);
                        ueObj.Start_time = Convert.ToString(row["Start_time"]);
                        ueObj.End_time = Convert.ToString(row["End_time"]);
                        listEvents.Add(ueObj);
                    }
                }
            }
            return listEvents;
        }

        public bool InsertEvents(CalendarSchedularEntity memMedEn)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Event_Desc",memMedEn.Event_Desc),
                new SqlParameter("@user_id", memMedEn.User_id),
                new SqlParameter("@Start_date",memMedEn.Start_date),
                new SqlParameter("@End_date",memMedEn.End_date),
                new SqlParameter("@Start_time",memMedEn.Start_time),
                new SqlParameter("@End_time",memMedEn.End_time)
            };
            return SqlDBHelper.ExecuteNonQuery("USP_USR_INSERT_CALENDAR_SCHEDULAR", CommandType.StoredProcedure, parameters);
        }

        public bool DeleteEvents(CalendarSchedularEntity memMedEn)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Event_id",memMedEn.Event_id),
                new SqlParameter("@user_id", memMedEn.User_id)
                
            };
            return SqlDBHelper.ExecuteNonQuery("USP_USR_DELETE_CALENDAR_SCHEDULAR", CommandType.StoredProcedure, parameters);
        }

        public bool UpdateEvents(CalendarSchedularEntity memMedEn)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Event_id",memMedEn.Event_id),
                new SqlParameter("@Event_Desc",memMedEn.Event_Desc),
                new SqlParameter("@user_id", memMedEn.User_id),
                new SqlParameter("@Start_date",memMedEn.Start_date),
                new SqlParameter("@End_date",memMedEn.End_date),
                new SqlParameter("@Start_time",memMedEn.Start_time),
                new SqlParameter("@End_time",memMedEn.End_time)
                
            };
            return SqlDBHelper.ExecuteNonQuery("USP_USR_UPDATE_CALENDAR_SCHEDULAR", CommandType.StoredProcedure, parameters);
        }
        
    }
}
