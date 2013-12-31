using System;
using System.Web.UI;
using NobleBLL;
using NobleEntity;
using Noble.Common;
using System.Web.UI.WebControls;

namespace Noble
{
    public partial class DeleteAdmin : System.Web.UI.Page
    {
        UserController objUC = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    ViewState["AdminId"] = Request.QueryString["id"];
                }
                ((Label)Master.FindControl("lblFirstHeader")).Text = "Manage";
                ((Label)Master.FindControl("lblSecondHeader")).Text = "Admin";
                //((Label)Master.FindControl("lblPageHeading")).Text = " ";
                GetAdminDetails();
            }
        }

        private void GetAdminDetails()
        {
            objUC = new UserController();
            UserEntity objEntity = null;

            try
            {
                objEntity = objUC.GetAdminDetails(Convert.ToInt32(ViewState["AdminId"]));
                if (objEntity != null)
                {
                    lblFirstName.Text = objEntity.First_name.Trim();
                    lblLastName.Text = objEntity.Last_name.Trim();
                    lblEmail.Text = objEntity.Email_id.Trim();
                }
            }
            finally
            {
                objEntity = null;
                objUC = null;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageAdmin.aspx", true);
        }

        protected void btnDeleteAdmin_Click(object sender, EventArgs e)
        {
            objUC = new UserController();

            try
            {
                bool status = objUC.DeleteAdmin(Convert.ToInt32(ViewState["AdminId"]));
                if (status)
                    lblMessage.Text = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "2001");
                else
                    lblMessage.Text = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "2002");
            }
            finally
            {
                objUC = null;
            }
        }

    }
}