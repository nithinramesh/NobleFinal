using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NobleBLL;
using Noble.Common;
using NobleEntity;

namespace Noble
{
    public partial class DeleteMember : System.Web.UI.Page
    {
        MemberController objUC = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    ViewState["MemberId"] = Request.QueryString["id"];
                }

                //((Label)Master.FindControl("lblPageHeading")).Text = "Manage Member";
                GetMemberDetails();
            }
        }

        private void GetMemberDetails()
        {
            objUC = new MemberController();
            MemberEntity objEntity = null;

            try
            {
                objEntity = objUC.GetMemberDetails(Convert.ToInt32(ViewState["MemberId"]));
                if (objEntity != null)
                {
                    lblTitle.Text = objEntity.Title.Trim();
                    lblFirstName.Text = objEntity.First_name.Trim();
                    lblMiddleName.Text = objEntity.Middle_name.Trim();
                    lblLastName.Text = objEntity.Last_name.Trim();
                    lblEmail.Text = objEntity.Email.Trim();
                    lblPhone.Text = objEntity.Phone.Trim();

                    lblCountry.Text = objEntity.CountryName.Trim();
                    lblExperience.Text = objEntity.Experience.Trim();
                    lblGender.Text = objEntity.Gender.Trim();
                    lblJobCategory.Text = objEntity.JobCatDesc.Trim().Replace("|","<br>");

                    lblAddress1.Text = objEntity.Addr1.Trim();
                    lblAddress2.Text = objEntity.Addr2.Trim();
                    lblCity.Text = objEntity.City.Trim();
                    lblProvince.Text = objEntity.Province.Trim();
                    lblPostalCode.Text = objEntity.PostalCode.Trim();
                    lblHomePhone.Text = objEntity.HomePhone.Trim();
                    lblWorkPhone.Text = objEntity.WorkPhone.Trim();
                    lblJobTitle.Text = objEntity.JobTitle.Trim();
                    lblPosition.Text = objEntity.Position.Trim();
                    lblOther.Text = objEntity.Other.Trim();

                    lblOriginCountry.Text = objEntity.CountryOriginName.Trim();
                }
            }
            finally
            {
                objEntity = null;
                objUC = null;
            }
        }

        protected void btnDeleteMember_Click(object sender, EventArgs e)
        {
            objUC = new MemberController();

            try
            {
                bool status = objUC.DeleteMember(Convert.ToInt32(ViewState["MemberId"]));
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageMember.aspx", true);
        }
    }
}