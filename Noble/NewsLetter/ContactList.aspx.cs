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
    public partial class ContactList : System.Web.UI.Page
    {

        NewsLetterController objController = new NewsLetterController();
        private string CategoryId = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillContacts();
                //((Label)Master.FindControl("lblPageHeading")).Text = "";
                ((Label)Master.FindControl("lblFirstHeader")).Text = "Manage";
                ((Label)Master.FindControl("lblSecondHeader")).Text = "Contacts";
            }
        }
        protected void rgContacts_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            FillContacts();
        }
        protected void FillContacts()
        {
            if (Request.QueryString["CategoryId"] != null && !string.IsNullOrEmpty(Request.QueryString["CategoryId"].ToString()))
            {
                EmailEntity objEE = new EmailEntity();
                objEE.CategoryId = Convert.ToInt32(Request.QueryString["CategoryId"].ToString());
                rgContacts.DataSource = objController.GetContactsByCategory(objEE);
            }
        }

        protected void rgContacts_ItemCommand(object source, GridCommandEventArgs e)
        {
          
            if (e.CommandName == "Delete")
            {
                GridDataItem item = (GridDataItem)e.Item;
                string EmailId = item.GetDataKeyValue("EmailId").ToString();
                EmailEntity objEntity = new EmailEntity();
                objEntity.EmailId = Convert.ToInt32(EmailId);
                objController.DeleteEmailcontact(objEntity);
            }
            if (e.CommandName.Equals("Edit"))
            {
                GridDataItem item = (GridDataItem)e.Item;
                if (Request.QueryString["CategoryId"] != null && !string.IsNullOrEmpty(Request.QueryString["CategoryId"].ToString()))
                {

                    string EmailId = item.GetDataKeyValue("EmailId").ToString();
                    Response.Redirect("AddOrUpdateContacts.aspx?EmailId=" + EmailId + "&CategoryId=" + Request.QueryString["CategoryId"].ToString());
                }

            }
            FillContacts();

        }




        protected void rgContacts_DataBound(object sender, EventArgs e)
        {
            foreach (GridDataItem item in rgContacts.Items)
            {
                //string CategoryId = item.GetDataKeyValue("CategoryId").ToString();
                //string CategoryName = item.GetDataKeyValue("CategoryName").ToString();
                //HyperLink btnCategory = (HyperLink)item["CategoryName"].Controls[0];
                //btnCategory.Text = CategoryName;
                //btnCategory.NavigateUrl = string.Concat("ContactList.aspx?CategoryId=", CategoryId);

            }

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["CategoryId"] != null && !string.IsNullOrEmpty(Request.QueryString["CategoryId"].ToString()))
            {
                Response.Redirect("AddOrUpdateContacts.aspx?CategoryId=" + Request.QueryString["CategoryId"].ToString(), true);
            }

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {

            Response.Redirect("EmailCategoryList.aspx", true);            

        }

        protected void rgContacts_Init(object sender, EventArgs e)
        {
            GridFilterMenu menu = rgContacts.FilterMenu;
            int i = 0;
            while (i < menu.Items.Count)
            {
                if (menu.Items[i].Text == "NoFilter" || menu.Items[i].Text == "Contains" || menu.Items[i].Text == "EqualTo"
                    || menu.Items[i].Text == "NotEqualTo" || menu.Items[i].Text == "StartsWith")
                {
                    i++;
                }
                else
                {
                    menu.Items.RemoveAt(i);
                }
            }
        }
    }
}