using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using NobleBLL;
using NobleEntity;

namespace Noble.NewsLetter
{
    public partial class RecepCategoriesPopup : System.Web.UI.Page
    {
        NewsLetterController objController = new NewsLetterController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillEmailCategories();

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
            rgContactCategories.DataSource = objController.GetEmailCategories();
            rgContactCategories.DataBind();
        }

        protected void rgContactCategories_ItemCommand(object source, GridCommandEventArgs e)
        {
            if (e.CommandName == "AddEmail")
            {
                if (e.Item is GridDataItem && e.Item.OwnerTableView.Name == "Parent")
                {
                    // your logic should come here
                }
                else if (e.Item is GridDataItem && e.Item.OwnerTableView.Name == "Child")
                {

                    GridTableView dtable = (GridTableView)e.Item.OwnerTableView;
                    GridDataItem parentItem = (GridDataItem)dtable.ParentItem;
                    int CategoryId = Convert.ToInt32(parentItem.GetDataKeyValue("CategoryId").ToString());
                    // your logic should come here
                    RadTextBox rdEmails = (RadTextBox)e.Item.FindControl("rdEmails");
                    Label lblMessage = (Label)e.Item.FindControl("lblMessage");
                    string Email = rdEmails.Text;
                    string[] lst = Email.Split(new Char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                    string EmailExits = string.Empty;
                    int EmailExistsCount = 0;
                    foreach (string semail in lst)
                    {
                        EmailEntity objEmailEntity = new EmailEntity();
                        objEmailEntity.EmailAddress = semail;
                        objEmailEntity.FirstName = string.Empty;
                        objEmailEntity.LastName = string.Empty;
                        objEmailEntity.CategoryId = CategoryId;
                        objEmailEntity.Created_on = System.DateTime.Now;
                        if (Session["LOGINUSERID"] != null && !string.IsNullOrEmpty(Session["LOGINUSERID"].ToString()))
                            objEmailEntity.Created_by = Convert.ToInt32(Session["LOGINUSERID"].ToString());
                        if (!objController.InsertEmailContact(objEmailEntity))
                        {
                            EmailExits = string.IsNullOrEmpty(EmailExits) ? objEmailEntity.EmailAddress : EmailExits + "," + objEmailEntity.EmailAddress;
                            EmailExistsCount = EmailExistsCount + 1;
                        }


                    }
                    if (!string.IsNullOrEmpty(EmailExits))
                    {
                        if(lst.Length>EmailExistsCount)
                        lblMessage.Text = "Specified email addresses " + EmailExits + " already exists for this Category. Rest of them added.";
                        else
                            lblMessage.Text = "Specified email address already exists for this Category.";
                    }
                    else
                    {
                        lblMessage.Text = string.Empty;
                        FillEmailCategories();
                    }

                }
            }
            //else if (e.CommandName == "ExpandCollapse")
            //{
            //    if (e.Item is GridDataItem && e.Item.OwnerTableView.Name == "Child")
            //    {


            //        RadTextBox rdEmails = (RadTextBox)e.Item.FindControl("rdEmails");
            //        rdEmails.Focus();

            //    }
            //}


        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            bool Selected = false;
            foreach (GridDataItem item in rgContactCategories.Items)
            {

                if (item is GridDataItem)
                {
                    GridDataItem dataItem = (GridDataItem)item;
                    if (dataItem.Selected)
                    {
                        Selected = true;
                        if (Session["SelectedEmailCategories"] == null)
                        {
                            Session["SelectedEmailCategories"] = item["CategoryName"].Text;

                        }
                        else
                        {
                            Session["SelectedEmailCategories"] = string.Concat(Session["SelectedEmailCategories"].ToString(), ";", item["CategoryName"].Text);
                        }
                    }
                }
            }
            if (!Selected)
                Session["SelectedEmailCategories"] = null;
            //ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true); // Call client method in radwindow page 
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseEmailWindow();", true);


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            EmailEntity objEmailEntity = new EmailEntity();
            objEmailEntity.CategoryName = txtCategoryName.Text.Trim();
            objController.CreateEmailCategory(objEmailEntity);
            txtCategoryName.Text = string.Empty;
            FillEmailCategories();

        }

        protected void rgContactCategories_DataBound(object sender, EventArgs e)
        {
            if (Session["SelectedEmailCategories"] != null)
            {
                string[] SelectedEmails = Session["SelectedEmailCategories"].ToString().Split(';');
                foreach (GridDataItem item in rgContactCategories.Items)
                {

                    if (item is GridDataItem)
                    {
                        GridDataItem dataItem = (GridDataItem)item;
                        if (SelectedEmails.Contains(item["CategoryName"].Text))
                            dataItem.Selected = true;
                        else
                            dataItem.Selected = false;

                    }
                }
            }

        }

        protected void rgContactCategories_ColumnCreated(object sender, GridColumnCreatedEventArgs e)
        {
            if (e.Column is GridExpandColumn)
            {
                (e.Column as GridExpandColumn).ButtonType = GridExpandColumnType.ImageButton;

                (e.Column as GridExpandColumn).ExpandImageUrl = "../images/plus.png";
                (e.Column as GridExpandColumn).CollapseImageUrl = "../images/min.png";
                (e.Column as GridExpandColumn).HeaderText = "Add";
            }
        }

        protected void rgContactCategories_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem && e.Item.OwnerTableView.Name == "Child")
            {
                GridTableView dtable = (GridTableView)e.Item.OwnerTableView;
                GridDataItem parentItem = (GridDataItem)dtable.ParentItem;
                int CategoryId = Convert.ToInt32(parentItem.GetDataKeyValue("CategoryId").ToString());
                RadTextBox rdEmails = (RadTextBox)e.Item.FindControl("rdEmails");
                if (CategoryId < 1)
                {

                    Button btnAdd = (Button)e.Item.FindControl("btnAdd");
                    rdEmails.ReadOnly = true;
                    btnAdd.Enabled = false;
                }
                // rdEmails.Focus();

            }
        }


    }
}