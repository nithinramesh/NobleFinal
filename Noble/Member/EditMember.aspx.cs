using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NobleBLL;
using NobleEntity;
using Noble.Common;

namespace Noble
{
    public partial class EditMember : System.Web.UI.Page
    {
        MemberController objUC = null;
        GeneralController genAccessObj = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    ViewState["MemberId"] = Request.QueryString["id"];
                }

                //((Label)Master.FindControl("lblPageHeading")).Text = "Manage Member";
                PopulateCombos();
                GetMemberDetails();
            }
        }

        private void PopulateCombos()
        {
            genAccessObj = new GeneralController();

            ddlExperience.DataSource = genAccessObj.GetExperience();
            ddlExperience.DataValueField = "Key";
            ddlExperience.DataTextField = "Value";
            ddlExperience.DataBind();

            ddlGender.DataSource = genAccessObj.GetGender();
            ddlGender.DataValueField = "Key";
            ddlGender.DataTextField = "Value";
            ddlGender.DataBind();

            ddlTitle.DataSource = genAccessObj.GetTitle();
            ddlTitle.DataValueField = "Key";
            ddlTitle.DataTextField = "Value";
            ddlTitle.DataBind();

            ddlCountry.DataSource = genAccessObj.GetCountry();
            ddlCountry.DataValueField = "Key";
            ddlCountry.DataTextField = "Value";
            ddlCountry.DataBind();
            ddlCountry.Items.Insert(0, new ListItem("Select", "-1"));

            ddlOriginCountry.DataSource = genAccessObj.GetCountry();
            ddlOriginCountry.DataValueField = "Key";
            ddlOriginCountry.DataTextField = "Value";
            ddlOriginCountry.DataBind();
            ddlOriginCountry.Items.Insert(0, new ListItem("Select", "-1"));
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
                    if (ddlTitle.Items.FindByText(objEntity.Title) != null)
                    {
                        ddlTitle.SelectedValue = objEntity.Title;
                    }
                    txtFirstName.Text = objEntity.First_name.Trim();
                    txtMiddleName.Text = objEntity.Middle_name.Trim();
                    txtLastName.Text = objEntity.Last_name.Trim();
                    txtEmail.Text = objEntity.Email.Trim();
                    txtPhone.Text = objEntity.Phone.Trim();

                    if (ddlCountry.Items.FindByValue(objEntity.CountryCode) != null)
                    {
                        ddlCountry.SelectedValue = objEntity.CountryCode;
                    }

                    if (ddlExperience.Items.FindByText(objEntity.Experience) != null)
                    {
                        ddlExperience.SelectedValue = objEntity.Experience;
                    }
                    if (ddlGender.Items.FindByText(objEntity.Gender) != null)
                    {
                        ddlGender.SelectedValue = objEntity.Gender;
                    }
                    lblJobCategory.Text = objEntity.JobCatDesc.Trim().Replace("|", "<br>");

                    txtAddress1.Text = objEntity.Addr1.Trim();
                    txtAddress2.Text = objEntity.Addr2.Trim();
                    txtCity.Text = objEntity.City.Trim();
                    txtProvince.Text = objEntity.Province.Trim();
                    txtPostalCode.Text = objEntity.PostalCode.Trim();
                    txtHomePhone.Text = objEntity.HomePhone.Trim();
                    txtWorkPhone.Text = objEntity.WorkPhone.Trim();
                    txtJobTitle.Text = objEntity.JobTitle.Trim();
                    txtPosition.Text = objEntity.Position.Trim();
                    txtOther.Text = objEntity.Other.Trim();

                    if (ddlOriginCountry.Items.FindByValue(objEntity.CountryOriginCode) != null)
                    {
                        ddlOriginCountry.SelectedValue = objEntity.CountryOriginCode;
                    }
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
                objUC = new MemberController();
                MemberEntity objEntity = null;
                try
                {
                    objEntity = new MemberEntity();
                    objEntity.ID = Convert.ToInt32(ViewState["MemberId"]);
                    objEntity.First_name = txtFirstName.Text.Trim();
                    objEntity.Middle_name = txtMiddleName.Text.Trim();
                    objEntity.Last_name = txtLastName.Text.Trim();
                    objEntity.Email = txtEmail.Text.Trim();
                    objEntity.Phone = txtPhone.Text.Trim();
                   // objEntity.CountryCode = ddlCountry.SelectedItem.Value;
                    //objEntity.Experience = ddlExperience.SelectedItem.Value;
                    objEntity.Title = ddlTitle.SelectedItem.Value;
                    objEntity.Gender = ddlGender.SelectedItem.Value;

                    objEntity.Addr1 = txtAddress1.Text.Trim();
                    objEntity.Addr2 = txtAddress2.Text.Trim();
                    objEntity.City = txtCity.Text.Trim();
                    objEntity.Province = txtProvince.Text.Trim();
                    objEntity.PostalCode = txtPostalCode.Text.Trim();
                    objEntity.HomePhone = txtHomePhone.Text.Trim();
                    objEntity.WorkPhone = txtWorkPhone.Text.Trim();
                    objEntity.JobTitle = txtJobTitle.Text.Trim();
                    objEntity.Position = txtPosition.Text.Trim();
                    objEntity.Other = txtOther.Text.Trim();

                  //  objEntity.CountryOriginCode = ddlOriginCountry.SelectedItem.Value;

                    bool status = objUC.UpdateMember(objEntity);
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
            Response.Redirect("ManageMember.aspx", true);
        }
    }
}