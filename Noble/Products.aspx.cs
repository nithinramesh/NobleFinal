using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using NobleBLL;
using NobleEntity;
using Telerik.Web.UI;

namespace Noble.ProductCategory
{
    public partial class Products : Page
    {
        ProductController _objPrdCtl;
        private ProductCategoryController _prdobj;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)   
            {
               // ((Label)Master.FindControl("lblPageHeading")).Text = "Manage ";
                ((Label)Master.FindControl("lblFirstHeader")).Text = "Manage";
                ((Label)Master.FindControl("lblSecondHeader")).Text = "Products";
                _prdobj = new ProductCategoryController();
                radCmbPCategories.DataSource = _prdobj.GetProductCategoryDetails();
                radCmbPCategories.DataTextField = "ProductCategory_name";
                radCmbPCategories.DataValueField = "ProductCategory_id";
                radCmbPCategories.AutoPostBack = true;
                radCmbPCategories.DataBind();
            }
        }
        protected void gvproduct_ItemCommand(object source, GridCommandEventArgs e)
        {

            if (e.CommandName.Equals("Edit") || (e.CommandName.Equals("Delete")))
            {
                
                var item = (GridDataItem)e.Item;
                ViewState["ProductId"] = Convert.ToInt32(item.GetDataKeyValue("ID"));
                //int pid = Convert.ToInt32(item.GetDataKeyValue("ID"));
            }
         }
        private void BindGrid()
        {
            _objPrdCtl = new ProductController();
            try
            {
                if (radCmbPCategories.SelectedItem != null)
                {
                    int productCategoryId = Convert.ToInt32(radCmbPCategories.SelectedItem.Value);
                    _objPrdCtl = new ProductController();
                    gvproduct.DataSource = _objPrdCtl.GetProductDetailsByCatId(productCategoryId);
                }
            }
            finally
            {
                _objPrdCtl = null;
            }
        }
        protected void gvproduct_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            BindGrid();
        }

        protected void gvproduct_DeleteCommand(object source, GridCommandEventArgs e)
        {
            
            _objPrdCtl = new ProductController();

            try
            {
                bool status = _objPrdCtl.DeleteProduct(Convert.ToInt32(ViewState["ProductId"]));
                //if (status)
                //    lblMessage.Text = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "2001");
                //else
                //    lblMessage.Text = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "2002");
            }
            finally
            {
                _objPrdCtl = null;
            }
        }

        protected void gvproduct_InsertCommand(object source, GridCommandEventArgs e)
        {
            if (Page.IsValid)
            {
                _objPrdCtl = new ProductController();
               // var editedItem = e.Item as GridEditableItem;
                var userControl = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

                try
                {
                    string productCode = (userControl.FindControl("txtProductCode") as TextBox).Text;
                    string productDescription = (userControl.FindControl("txtProductDescription") as TextBox).Text;
                    double productPrice = Convert.ToDouble( (userControl.FindControl("txtProductPrice") as TextBox).Text);
                    int productCategoryId = Convert.ToInt32(radCmbPCategories.SelectedItem.Value);

                    if (_objPrdCtl.InsertNewProduct(productCode, productDescription,productPrice,productCategoryId))
                    {
                        //lblMessage.Text = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "2000");
                    }
                    else
                    {
                        //lblMessage.Text = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "3000");
                    }
                    BindGridonSave();

                }
                finally
                {
                    _objPrdCtl = null;
                }
            }
        }

        private void BindGridonSave()
        {
            _objPrdCtl = new ProductController();

            try
            {
                //gvproduct.DataSource = _objPrdCtl.GetProductDetails();
               // gvproduct.DataBind();

                int productCategoryId = Convert.ToInt32(radCmbPCategories.SelectedItem.Value);
                _objPrdCtl = new ProductController();
                gvproduct.DataSource = _objPrdCtl.GetProductDetailsByCatId(productCategoryId);
                
                gvproduct.DataBind();
            }
            finally
            {
                _objPrdCtl = null;
            }
        }

       
      

        protected void gvproduct_Init(object sender, EventArgs e)
        {
            GridFilterMenu menu = gvproduct.FilterMenu;
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

        protected void gvproduct_UpdateCommand1(object source, GridCommandEventArgs e)
        {
            var userControl = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

            string productCode = ((TextBox) userControl.FindControl("txtProductCode")).Text;
            string productDescription = ((TextBox) userControl.FindControl("txtProductDescription")).Text;
            double productPrice = Convert.ToDouble(((TextBox) userControl.FindControl("txtProductPrice")).Text);

            _objPrdCtl = new ProductController();

            ProductEntity prObj;
            try
            {
                prObj = new ProductEntity
                {
                    ProductID = Convert.ToInt32(ViewState["ProductId"]),
                    ProductCode = productCode,
                    ProductDescription = productDescription,
                    ProductPrice = productPrice
                };


                if (_objPrdCtl.UpdateProduct(prObj))
                {
                    //lblMessage.Text = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "2000");
                }
                else
                {
                    // lblMessage.Text = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "3000");
                }

            }
            finally
            {
                prObj = null;
            }
        }

        protected void radCmbPCategories_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            int productCategoryId = Convert.ToInt32(radCmbPCategories.SelectedItem.Value);
            _objPrdCtl = new ProductController();
            gvproduct.DataSource = _objPrdCtl.GetProductDetailsByCatId(productCategoryId);
            gvproduct.DataBind();
        }

    }
}