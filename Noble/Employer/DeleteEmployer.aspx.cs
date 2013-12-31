using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NobleBLL;
using NobleEntity;
using Noble.Common;

namespace Noble.Employer
{
    public partial class DeleteEmployer : System.Web.UI.Page
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
                    lblName.Text = objEntity.Name.Trim();
                    lblAddr1.Text = objEntity.Addr1.Trim();
                    lblAddr2.Text = objEntity.Addr2.Trim();
                    lblCity.Text = objEntity.City.Trim();
                    lblProvince.Text = objEntity.Province.Trim();
                    lblPostalCode.Text = objEntity.PostalCode.Trim();
                    lblPhone.Text = objEntity.Phone.Trim();
                    lblEmail.Text = objEntity.Email_id.Trim();
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

        protected void btnDeleteEmp_Click(object sender, EventArgs e)
        {
            objEC = new EmployerController();

            try
            {
                bool status = objEC.DeleteEmployer(Convert.ToInt32(ViewState["EmployerId"]));
                if (status)
                    lblMessage.Text = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "2001");
                else
                    lblMessage.Text = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "2002");
            }
            finally
            {
                objEC = null;
            }
        }

      

    }
}