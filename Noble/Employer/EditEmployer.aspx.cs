using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NobleBLL;
using Noble.Common;
using NobleEntity;

namespace Noble.Employer
{
    public partial class EditEmployer : System.Web.UI.Page
    {
        EmployerController objEC = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    ViewState["EmployerId"] = Request.QueryString["id"];
                }

                ((Label)Master.FindControl("lblPageHeading")).Text = "Manage Employer";
                GetEmployerDetails();
            }
        }

        private void GetEmployerDetails()
        {
            objEC = new EmployerController();
            EmployerEntity objEntity = null;

            try
            {
                objEntity = objEC.GetEmployerDetails(Convert.ToInt32(ViewState["EmployerId"]));
                if (objEntity != null)
                {
                    txtName.Text = objEntity.Name.Trim();
                    txtAddr1.Text = objEntity.Addr1.Trim();
                    txtAddr2.Text = objEntity.Addr2.Trim();
                    txtCity.Text = objEntity.City.Trim();
                    txtProvince.Text = objEntity.Province.Trim();
                    txtPostalCode.Text = objEntity.PostalCode.Trim();
                    txtPhone.Text = objEntity.Phone.Trim();
                    txtEmail.Text = objEntity.Email_id.Trim();
                    txtUserName.Text = objEntity.User_name.Trim();
                    txtPass.Text = EncryptionUtility.DecryptData(objEntity.Password.Trim());
                    cbDisable.Checked = objEntity.Is_disabled;
                }
            }
            finally
            {
                objEntity = null;
                objEC = null;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageEmployer.aspx", true);
        }

        protected void btnSaveEmployer_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                objEC = new EmployerController();
                EmployerEntity objEntity = null;
                try
                {
                    objEntity = new EmployerEntity();
                    objEntity.ID = Convert.ToInt32(ViewState["EmployerId"]);
                    objEntity.Name = txtName.Text.Trim();
                    objEntity.Addr1 = txtAddr1.Text.Trim();
                    objEntity.Addr2 = txtAddr2.Text.Trim();
                    objEntity.City = txtCity.Text.Trim();
                    objEntity.Province = txtProvince.Text.Trim();
                    objEntity.PostalCode = txtPostalCode.Text.Trim();
                    objEntity.Phone = txtPhone.Text.Trim();
                    objEntity.Password = EncryptionUtility.EncryptData(txtPass.Text.Trim());
                    objEntity.Email_id = txtEmail.Text.Trim();
                    objEntity.Is_disabled = cbDisable.Checked;
                    bool status = objEC.UpdateEmployer(objEntity);
                    if (status)
                        lblMessage.Text = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "2000");
                    else
                        lblMessage.Text = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "2002");
                }
                finally
                {
                    objEntity = null;
                    objEC = null;
                }
            }
        }

    }
}