using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using NobleBLL;
using NobleEntity;
using Noble.Common;
using Telerik.Web.UI;

namespace Noble.Calendar
{
    public partial class CalendarSchedular : System.Web.UI.UserControl
    {
        CalendarSchedularController calScheContlr = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadEvents();
            }
        }


        protected void LoadEvents()
        {
            calScheContlr = new CalendarSchedularController();
            CalendarSchedularEntity calScheEntity = new CalendarSchedularEntity();
            calScheEntity.User_id = Convert.ToInt16(Session["LOGINUSERID"]);
            RadScheduler1.DataSource = calScheContlr.LoadEvents(calScheEntity);
            RadScheduler1.DataBind();
        }




        //protected void RadScheduler1_AppointmentInsert(object sender, Telerik.Web.UI.AppointmentInsertEventArgs e)
        //{
        //    InsertEvents(e);
        //    LoadEvents();
        //}

        //private void InsertEvents(Telerik.Web.UI.AppointmentInsertEventArgs e)
        //{
        //    calScheContlr = new CalendarSchedularController();
        //    CalendarSchedularEntity calScheEntity = null;
        //    try
        //    {
        //        calScheEntity = new CalendarSchedularEntity();
        //        calScheEntity.Event_Desc = Convert.ToString(e.Appointment.Subject.ToString());
        //        calScheEntity.User_id = Convert.ToInt16(Session["LOGINUSERID"]);
        //        calScheEntity.Start_date = e.Appointment.Start.ToShortDateString();
        //        calScheEntity.End_date = e.Appointment.End.ToShortDateString();
        //        calScheEntity.Start_time = e.Appointment.Start.ToShortTimeString();
        //        calScheEntity.End_time = e.Appointment.End.ToShortTimeString();
        //        bool res = calScheContlr.InsertEvents(calScheEntity);
        //    }
        //    finally
        //    {
        //        calScheEntity = null;
        //        calScheContlr = null;
        //    }
           
        //}

        //protected void RadScheduler1_AppointmentDelete(object sender, Telerik.Web.UI.AppointmentDeleteEventArgs e)
        //{
        //    DeleteEvents(e);
        //    LoadEvents();
        //}

        //private void DeleteEvents(Telerik.Web.UI.AppointmentDeleteEventArgs e)
        //{
        //    calScheContlr = new CalendarSchedularController();
        //    CalendarSchedularEntity calScheEntity = null;
        //    try
        //    {
        //        calScheEntity = new CalendarSchedularEntity();
        //        calScheEntity.Event_id = Convert.ToInt16(e.Appointment.ID);
        //        calScheEntity.User_id = Convert.ToInt16(Session["LOGINUSERID"]);
        //        bool res = calScheContlr.DeleteEvents(calScheEntity);
        //    }
        //    finally
        //    {
        //        calScheEntity = null;
        //        calScheContlr = null;
        //    }
            
        //}

        protected void RadScheduler1_AppointmentUpdate(object sender, Telerik.Web.UI.AppointmentUpdateEventArgs e)
        {
            UpdateEvents(e);
            LoadEvents();
        }

        private void UpdateEvents(Telerik.Web.UI.AppointmentUpdateEventArgs e)
        {
            calScheContlr = new CalendarSchedularController();
            CalendarSchedularEntity calScheEntity = null;
            try
            {
                calScheEntity = new CalendarSchedularEntity();
                calScheEntity.Event_id = Convert.ToInt16(e.ModifiedAppointment.ID);
                calScheEntity.Event_Desc = Convert.ToString(e.ModifiedAppointment.Subject.ToString());
                calScheEntity.User_id = Convert.ToInt16(Session["LOGINUSERID"]);
                calScheEntity.Start_date = e.ModifiedAppointment.Start.ToShortDateString();
                calScheEntity.End_date = e.ModifiedAppointment.End.ToShortDateString();
                calScheEntity.Start_time = e.ModifiedAppointment.Start.ToShortTimeString();
                calScheEntity.End_time = e.ModifiedAppointment.End.ToShortTimeString();
                bool res = calScheContlr.UpdateEvents(calScheEntity);
            }
            finally
            {
                calScheEntity = null;
                calScheContlr = null;
            }
            
        }

        protected void RadScheduler1_AppointmentInsert(object sender, SchedulerCancelEventArgs e)
        {
            calScheContlr = new CalendarSchedularController();
            CalendarSchedularEntity calScheEntity = null;
            try
            {
                calScheEntity = new CalendarSchedularEntity();
                calScheEntity.Event_Desc = Convert.ToString(e.Appointment.Subject.ToString());
                calScheEntity.User_id = Convert.ToInt16(Session["LOGINUSERID"]);
                calScheEntity.Start_date = e.Appointment.Start.ToShortDateString();
                calScheEntity.End_date = e.Appointment.End.ToShortDateString();
                calScheEntity.Start_time = e.Appointment.Start.ToShortTimeString();
                calScheEntity.End_time = e.Appointment.End.ToShortTimeString();
                bool res = calScheContlr.InsertEvents(calScheEntity);
            }
            finally
            {
                calScheEntity = null;
                calScheContlr = null;
            }
            LoadEvents();
        }

        protected void RadScheduler1_AppointmentDelete(object sender, SchedulerCancelEventArgs e)
        {
            calScheContlr = new CalendarSchedularController();
            CalendarSchedularEntity calScheEntity = null;
            try
            {
                calScheEntity = new CalendarSchedularEntity();
                calScheEntity.Event_id = Convert.ToInt16(e.Appointment.ID);
                calScheEntity.User_id = Convert.ToInt16(Session["LOGINUSERID"]);
                bool res = calScheContlr.DeleteEvents(calScheEntity);
            }
            finally
            {
                calScheEntity = null;
                calScheContlr = null;
            }
            LoadEvents();

        }


    }
}