using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NobleBLL;
using NobleEntity;

namespace Noble.NewsLetter
{
    public partial class MailStatusReport : System.Web.UI.Page
    {
        NewsLetterController objNLTRController = null;
        MailStatusEntity objMEntity;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    if (Request.QueryString["TempID"] != null)
            //    {
            //        FillMailStatus(Convert.ToInt32(Request.QueryString["TempID"].ToString()));

            //    }
            //}
            if (!IsPostBack)
            {
                //((Label)Master.FindControl("lblPageHeading")).Text = " ";
                ((Label)Master.FindControl("lblFirstHeader")).Text = "NewsLetter";
                ((Label)Master.FindControl("lblSecondHeader")).Text = "Report";
                FillMailStatusTemplates();
                if (Request["Status"] != null)
                    lblMessage.Visible = true;
            }

        }
        private void FillMailStatusTemplates()
        {
            objNLTRController = new NewsLetterController();
            radgvMailStatus.DataSource = objNLTRController.GetMailStatusTemplates();
            radgvMailStatus.DataBind();
        }

        private void FillMailStatus(int TemplateID)
        {
            objNLTRController = new NewsLetterController();
            objMEntity = new MailStatusEntity();
            objMEntity.TemplateID = TemplateID;
            radgvMailStatus.DataSource = objNLTRController.GetMailStatusByTemplateID(objMEntity);
            radgvMailStatus.DataBind();
        }

        protected void radgvMailStatus_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            FillMailStatusTemplates();
        }

       
    }
}