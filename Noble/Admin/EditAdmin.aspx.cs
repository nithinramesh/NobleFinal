using System;
using System.Web.UI;
using NobleBLL;
using NobleEntity;
using Noble.Common;
using System.Web.UI.WebControls;

namespace Noble
{
    public partial class EditAdmin : System.Web.UI.Page
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
                    txtFirstName.Text = objEntity.First_name.Trim();
                    txtLastName.Text = objEntity.Last_name.Trim();
                    txtEmail.Text = objEntity.Email_id.Trim();
                    txtPass.Text = EncryptionUtility.DecryptData(objEntity.Password.Trim());
                    cbDisable.Checked = objEntity.Is_disabled;
                }
            }
            finally
            {
                objEntity = null;
                objUC = null;
            }
        }

        protected void btnSaveAdmin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                objUC = new UserController();
                UserEntity objEntity = null;
                try
                {
                    objEntity = new UserEntity();
                    objEntity.ID = Convert.ToInt32(ViewState["AdminId"]);
                    objEntity.First_name = txtFirstName.Text.Trim();
                    objEntity.Last_name = txtLastName.Text.Trim();
                    objEntity.Password = EncryptionUtility.EncryptData(txtPass.Text.Trim());
                    objEntity.Email_id = txtEmail.Text.Trim();
                    objEntity.Is_disabled = cbDisable.Checked;
                    bool status = objUC.UpdateAdmin(objEntity);
                    if (status)
                        lblMessage.Text = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "2000");
                    else
                        lblMessage.Text = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "2002");
                }
                finally
                {
                    objEntity = null;
                    objUC = null;
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageAdmin.aspx",true);
        }
    }
}