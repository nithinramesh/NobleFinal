using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using NobleBLL;
using NobleEntity;
using Noble.Common;
using Telerik.Web.UI;

namespace Noble
{
    public partial class ManageAdmin : System.Web.UI.Page
    {
        UserController objUC = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //BindGrid();

                //((Label)Master.FindControl("lblPageHeading")).Text = "Manage Admin";
                ((Label)Master.FindControl("lblFirstHeader")).Text = "Manage";
                ((Label)Master.FindControl("lblSecondHeader")).Text = "Admin";
            }
        }

        private void BindGrid()
        {
            objUC = new UserController();

            try
            {
                //gvAdmin.DataSource = objUC.GetAdminList();
                gvAdmin.DataSource = objUC.GetAdminSearchList(string.Empty,string.Empty,string.Empty);
                //gvAdmin.DataSource = objUC.GetAdminSearchList(txtLN.Text.Trim(), txtFN.Text.Trim(), txtUN.Text.Trim());
                //gvAdmin.DataBind();
            }
            finally
            {
                objUC = null;
            }
        }

        private void BindGridonSave()
        {
            objUC = new UserController();

            try
            {
                gvAdmin.DataSource = objUC.GetAdminSearchList(string.Empty, string.Empty, string.Empty);
                gvAdmin.DataBind();
            }
            finally
            {
                objUC = null;
            }
        }


        protected void btnAddAdmin_Click(object sender, EventArgs e)
        {
            tblAdd.Visible = true;
            //tblSearch.Visible = false;
            tblGrid.Visible = false;
            //gvAdmin.Visible = false;

            lblMessage.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPwd.Text = string.Empty;
        }

        protected void btnSaveAdmin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                objUC = new UserController();

                UserEntity ueObj = null;
                try
                {
                    ueObj = new UserEntity();

                    ueObj.Last_name = txtLastName.Text.Trim();
                    ueObj.First_name = txtFirstName.Text.Trim();
                    ueObj.User_name = txtUserName.Text.Trim();
                    ueObj.Created_by = Convert.ToInt32(Session["LOGINUSERID"]);
                    ueObj.Password = EncryptionUtility.EncryptData(txtPwd.Text.Trim());
                    ueObj.Email_id = txtEmail.Text.Trim();

                    string message = objUC.AddNewAdmin(ueObj);

                    if (!string.IsNullOrEmpty(message))
                        lblMessage.Text = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), message);

                    BindGridonSave();

                    //tblAdd.Visible = false;
                    //tblSearch.Visible = true;
                }
                finally
                {
                    objUC = null;
                    ueObj = null;
                }
            }
        }

    
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            tblAdd.Visible = false;
            //tblSearch.Visible = true;
            tblGrid.Visible = true;
            gvAdmin.Visible = true;

            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPwd.Text = string.Empty;
        }

        //protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        //{
        //    ImageButton btna = sender as ImageButton;
        //    if (btna!= null)
        //    {
        //        GridViewRow row = (GridViewRow)btna.NamingContainer;
        //        //string id = gvAdmin.DataKeys[row.RowIndex].Values["ID"].ToString();
        //        //Response.Redirect("EditAdmin.aspx?id=" + id);
        //    }
        //}

        //protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        //{
        //    ImageButton btna = sender as ImageButton;
        //    if (btna!= null)
        //    {
        //        GridViewRow row = (GridViewRow)btna.NamingContainer;
        //        //string id = gvAdmin.DataKeys[row.RowIndex].Values["ID"].ToString();
        //        //Response.Redirect("DeleteAdmin.aspx?id=" + id);
        //    }
        //}

        protected void gvAdmin_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("Delete"))
            {
                GridDataItem item = (GridDataItem)e.Item;
                string id = item.GetDataKeyValue("ID").ToString();
                Response.Redirect("DeleteAdmin.aspx?id=" + id);
            }
            if (e.CommandName.Equals("Edit"))
            {
                GridDataItem item = (GridDataItem)e.Item;
                string id = item.GetDataKeyValue("ID").ToString();
                Response.Redirect("EditAdmin.aspx?id=" + id);
            }
        }

        //protected void gvAdmin_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gvAdmin.PageIndex = e.NewPageIndex;
        //    BindGrid();
        //}

        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    BindGrid();
        //}

        protected void gvAdmin_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            BindGrid();
        }

        protected void gvAdmin_Init(object sender, System.EventArgs e)
        {
            GridFilterMenu menu = gvAdmin.FilterMenu;
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