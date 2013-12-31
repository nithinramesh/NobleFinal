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
    public partial class EmailCategoryList : System.Web.UI.Page
    {

        NewsLetterController objController = new NewsLetterController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillEmailCategories();
                //((Label)Master.FindControl("lblPageHeading")).Text = " ";
                ((Label)Master.FindControl("lblFirstHeader")).Text = "Contact";
                ((Label)Master.FindControl("lblSecondHeader")).Text = "Lists";
            }
        }
        protected void rgContactCategories_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {

            rgContactCategories.DataSource = null;
            rgContactCategories.DataSource = objController.GetEmailCategories();
        }
        protected void FillEmailCategories()
        {
            rgContactCategories.DataSource = null;
            rgContactCategories.DataSource = objController.GetEmailCategoriesOnly();
            rgContactCategories.DataBind();

        }

        protected void rgContactCategories_ItemCommand(object source, GridCommandEventArgs e)
        {
            GridDataItem item = (GridDataItem)e.Item;
            if (e.CommandName == "Delete")
            {
                string CategoryId = item.GetDataKeyValue("CategoryId").ToString();
                EmailEntity objEntity = new EmailEntity();
                objEntity.CategoryId = Convert.ToInt32(CategoryId);
                objController.DeleteEmailCategory(objEntity);
            }
            FillEmailCategories();

        }



        protected void btnSave_Click(object sender, EventArgs e)
        {
            EmailEntity objEmailEntity = new EmailEntity();
            objEmailEntity.CategoryName = txtCategoryName.Text.Trim();
            objController.CreateEmailCategory(objEmailEntity);
            txtCategoryName.Text = string.Empty;
            FillEmailCategories();
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {

            Response.Redirect("TemplateList.aspx", true);

        }

        protected void rgContactCategories_DataBound(object sender, EventArgs e)
        {
            foreach (GridDataItem item in rgContactCategories.Items)
            {
                string CategoryId = item.GetDataKeyValue("CategoryId").ToString();
                string CategoryName = item.GetDataKeyValue("CategoryName").ToString();
                HyperLink btnCategory = (HyperLink)item["CategoryName"].Controls[0];
                btnCategory.Text = CategoryName;
                btnCategory.NavigateUrl = string.Concat("ContactList.aspx?CategoryId=", CategoryId);

            }

        }
    }
}