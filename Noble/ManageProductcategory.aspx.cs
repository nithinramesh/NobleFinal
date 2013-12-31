using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using NobleBLL;
using NobleEntity;
using Noble.Common;
using Telerik.Web.UI;

namespace Noble.ProductCategory
{
    public partial class ManageProductcategory : System.Web.UI.Page
    {
        public int CatID;
        ProductCategoryController objprd = null;
        ProductCategoryEntity catobj=null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
            //    ((Label)Master.FindControl("lblPageHeading")).Text = "Manage ";
                ((Label)Master.FindControl("lblFirstHeader")).Text = "Manage";
                ((Label)Master.FindControl("lblSecondHeader")).Text = "Productcategory";
            }
        }
        protected void gvPRDCategory_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {

            if (e.CommandName.Equals("Edit"))
            {
                catobj = new ProductCategoryEntity();
                GridDataItem item = (GridDataItem)e.Item;
                ViewState["CategoryId"] = Convert.ToInt32(item.GetDataKeyValue("ID"));
            }
            if (e.CommandName.Equals("Delete"))
            {
                catobj = new ProductCategoryEntity();
                GridDataItem item = (GridDataItem)e.Item;
                ViewState["CategoryId"] = Convert.ToInt32(item.GetDataKeyValue("ID"));
            }  
       
               
            
        }
        protected void gvPRDCategory_UpdateCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            UserControl userControl = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);
                        
            string name = (userControl.FindControl("btnProductCategoryName") as TextBox).Text;
            objprd = new ProductCategoryController();

            ProductCategoryEntity prObj = null;
            try
            {
                prObj = new ProductCategoryEntity();

                prObj.ID = Convert.ToInt32(ViewState["CategoryId"]);
                prObj.ProductCategory_name = name;


                if (objprd.UpdateCategory(prObj))
                {
                    lblMessage.Text = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "2000");
                }
                else
                {
                    lblMessage.Text = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "3000");
                }


                //tblAdd.Visible = false;
                //tblSearch.Visible = true;
            }
            finally
            {
                prObj = null;
            }
            
        }
        protected void gvPRDCategory_InsertCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (Page.IsValid)
            {
                objprd = new ProductCategoryController();
                GridEditableItem editedItem = e.Item as GridEditableItem;
                UserControl userControl = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

                ProductCategoryEntity prObj = null;
                try
                {
                    prObj = new ProductCategoryEntity();

                    string ProductCategory_name = (userControl.FindControl("btnProductCategoryName") as TextBox).Text;
                    if (objprd.InsertNewProductCategory(ProductCategory_name))
                    {
                        lblMessage.Text = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "2000");
                    }
                    else
                    {
                        lblMessage.Text = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "3000");
                    }


                    BindGridonSave();

                    //tblAdd.Visible = false;
                    //tblSearch.Visible = true;
                }
                finally
                {
                    prObj = null;
                }
            }
        }
        protected void gvPRDCategory_DeleteCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
           
            objprd = new ProductCategoryController();

            try
            {
                bool status = objprd.DeleteProductCategory(Convert.ToInt32(ViewState["CategoryId"]));
                if (status)
                    lblMessage.Text = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "2001");
                else
                    lblMessage.Text = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "2002");
            }
            finally
            {
                objprd = null;
            }
        }
        private void BindGrid()
        {
            objprd = new ProductCategoryController();
          try
            {
               
                    gvPRDCategory.DataSource = objprd.GetProductCategoryDetails();
                
            }
            finally
            {
                objprd = null;
            }
        }
        protected void gvPRDCategory_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            BindGrid();
        }
       

        

        protected void btnCancel_Click(object sender, EventArgs e)
        {
        
            tblAdd.Visible = false;
            tblGrid.Visible = true;
            gvPRDCategory.Visible = true;

            txtcategory.Text = string.Empty;
                    
        }

       
        private void BindGridonSave()
        {
            objprd = new ProductCategoryController();

            ProductCategoryEntity prObj = null;
            prObj = new ProductCategoryEntity();

            try
            {
                gvPRDCategory.DataSource = objprd.GetProductCategoryDetails();
                gvPRDCategory.DataBind();
            }
            finally
            {
                objprd = null;
            }
        }
        protected void gvPRDCategory_Init(object sender, System.EventArgs e)
        {
            GridFilterMenu menu = gvPRDCategory.FilterMenu;
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

        protected void gvPRDCategory_CancelCommand(object source, GridCommandEventArgs e)
        {
            
            
        }
        }
    
}