using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using NobleBLL;
using NobleEntity;
using Noble.Common;

namespace Noble.Employer
{
    public partial class ManageEmployer : System.Web.UI.Page
    {
        EmployerController objEmpC = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //BindGrid();

                ((Label)Master.FindControl("lblPageHeading")).Text = "Manage Employer";
            }
        }

        private void BindGrid()
        {
            objEmpC = new EmployerController();

            try
            {
                gvEmployer.DataSource = objEmpC.GetEmployerSearchList();
            }
            finally
            {
                objEmpC = null;
            }
        }

        protected void gvEmployer_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("Delete"))
            {
                GridDataItem item = (GridDataItem)e.Item;
                string id = item.GetDataKeyValue("ID").ToString();
                Response.Redirect("DeleteEmployer.aspx?id=" + id);
            }
            if (e.CommandName.Equals("Edit"))
            {
                GridDataItem item = (GridDataItem)e.Item;
                string id = item.GetDataKeyValue("ID").ToString();
                Response.Redirect("EditEmployer.aspx?id=" + id);
            }
        }

        protected void gvEmployer_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            BindGrid();
        }

        protected void gvEmployer_Init(object sender, System.EventArgs e)
        {
            GridFilterMenu menu = gvEmployer.FilterMenu;
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

        protected void btnAddEmployer_Click(object sender, EventArgs e)
        {
            tblAdd.Visible = true;
            //tblSearch.Visible = false;
            tblGrid.Visible = false;
            //gvAdmin.Visible = false;

            lblMessage.Text = string.Empty;

            ClearTextboxes();
        }

        private void ClearTextboxes()
        {
            txtName.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPwd.Text = string.Empty;
            txtAddress1.Text = string.Empty;
            txtAddress2.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtPostalCode.Text = string.Empty;
            txtProvince.Text = string.Empty;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            tblAdd.Visible = false;
            //tblSearch.Visible = true;
            tblGrid.Visible = true;
            gvEmployer.Visible = true;

            ClearTextboxes();
        }

        protected void btnSaveEmp_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                objEmpC = new EmployerController();

                EmployerEntity ueObj = null;
                try
                {
                    ueObj = new EmployerEntity();

                    ueObj.Name = txtName.Text.Trim();
                    
                    ueObj.User_name = txtUserName.Text.Trim();
                    ueObj.Password = EncryptionUtility.EncryptData(txtPwd.Text.Trim());
                    ueObj.Email_id = txtEmail.Text.Trim();

                    ueObj.Addr1 = txtAddress1.Text.Trim();
                    ueObj.Addr2 = txtAddress2.Text.Trim();
                    ueObj.City = txtCity.Text.Trim();
                    ueObj.Province = txtProvince.Text.Trim();
                    ueObj.PostalCode = txtPostalCode.Text.Trim();
                    ueObj.Phone = txtPhone.Text.Trim();
                    ueObj.Created_by = Convert.ToInt32(Session["LOGINUSERID"]);


                    string message = objEmpC.AddNewEmployer(ueObj);

                    if (!string.IsNullOrEmpty(message))
                    {
                        lblMessage.Text = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), message);
                    }
                    else
                    {
                        lblMessage.Text = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "2000");
                        BindGridonSave();
                    }

                    //tblAdd.Visible = false;
                    //tblSearch.Visible = true;
                }
                finally
                {
                    objEmpC = null;
                    ueObj = null;
                }
            }
        }

        private void BindGridonSave()
        {
            objEmpC = new EmployerController();

            try
            {
                gvEmployer.DataSource = objEmpC.GetEmployerSearchList();
                gvEmployer.DataBind();
            }
            finally
            {
                objEmpC = null;
            }
        }

        protected void btnAssignFiles_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployerFileAssign.aspx", true);
        }


    }
}