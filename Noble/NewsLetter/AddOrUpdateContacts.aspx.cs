using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using NobleEntity;
using NobleBLL;

namespace Noble.NewsLetter
{
    public partial class AddOrUpdateContacts : System.Web.UI.Page
    {
        NewsLetterController objController = new NewsLetterController();
        private string CategoryId = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["CategoryId"] != null && !string.IsNullOrEmpty(Request.QueryString["CategoryId"].ToString()))
                CategoryId = Request.QueryString["CategoryId"].ToString();

            if (!IsPostBack)
            {
                if (Request.QueryString["EmailId"] != null && !string.IsNullOrEmpty(Request.QueryString["EmailId"]))
                {
                    EmailEntity objee = new EmailEntity();
                    objee.EmailId = Convert.ToInt32(Request.QueryString["EmailId"].ToString());
                    EmailEntity objoutee = objController.GetContactsById(objee);
                    txtFirstName.Text = objoutee.FirstName;
                    txtLastName.Text = objoutee.LastName;
                    txtEmail.Text = objoutee.EmailAddress;
                    btnSave.Text = "Update";
                    ((Label)Master.FindControl("lblPageHeading")).Text = " ";
                    ((Label)Master.FindControl("lblFirstHeader")).Text = "Edit";
                    ((Label)Master.FindControl("lblSecondHeader")).Text = "Contact";
                }
                else
                {
                    btnSave.Text = "Add";
                    //((Label)Master.FindControl("lblPageHeading")).Text = " Contact";
                    ((Label)Master.FindControl("lblFirstHeader")).Text = "Add";
                    ((Label)Master.FindControl("lblSecondHeader")).Text = "Contact";
                }

            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
           
                EmailEntity objEE = new EmailEntity();
                try
                {

                    objEE.FirstName = txtFirstName.Text.Trim();
                    objEE.LastName = txtLastName.Text.Trim();
                    objEE.EmailAddress = txtEmail.Text.Trim();
                    objEE.CategoryId = Convert.ToInt32(CategoryId);
                    if (Request.QueryString["EmailId"] != null && !string.IsNullOrEmpty(Request.QueryString["EmailId"]))
                    {
                        objEE.EmailId = Convert.ToInt32(Request.QueryString["EmailId"].ToString());

                        if (!objController.UpdateEmailcontact(objEE))
                            lblMessge.Text = "Specified email address already exists for this Category";
                        else
                            Response.Redirect("ContactList.aspx?CategoryId=" + CategoryId, true);

                    }
                    else
                    {
                        objEE.Created_on = System.DateTime.Now;
                        if (Session["LOGINUSERID"] != null && !string.IsNullOrEmpty(Session["LOGINUSERID"].ToString()))
                            objEE.Created_by = Convert.ToInt32(Session["LOGINUSERID"].ToString());
                       
                        
                        if(!objController.InsertEmailContact(objEE))
                            lblMessge.Text = "Specified email address already exists for this Category";
                        else
                            Response.Redirect("ContactList.aspx?CategoryId=" + CategoryId, true);
                    }
                    
                }
                finally
                {
                }
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContactList.aspx?CategoryId="+CategoryId, true);
        }
    }
}