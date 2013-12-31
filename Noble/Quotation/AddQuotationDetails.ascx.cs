using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NobleBLL;
using NobleEntity;
using Noble.Common;
using System.Text;
using Telerik.Web.UI;
using System.Data;
using System.Collections;

namespace Noble.Quotation
{
    public partial class AddQuotationDetails : System.Web.UI.UserControl
    {
        private object _dataItem = null;
        QuotationController quotAccessObj = null;
        QuotationProductController prodObj = null;
        GeneralController genAccessObj = null;
        DataTable dt = new DataTable();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }
        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        ///          Required method for Designer support - do not modify
        ///          the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DataBinding += new System.EventHandler(this.Product_Binding);

        }
        #endregion
        public object DataItem
        {
            get
            {
                return this._dataItem;
            }
            set
            {
                this._dataItem = value;
            }
        }

        protected void Product_Binding(object sender, System.EventArgs e)
        {

            fillProductsCat();   

        }



        private void fillProductsCat()
        {
            List<ProductCategoryEntity> prdList = null;
            ProductCategoryController _categoryController = new ProductCategoryController();
            try
            {



                prdList = _categoryController.GetProductCategoryDetails();

                ProductCategoryEntity catObj = new ProductCategoryEntity();
                catObj.ID = 0;
                catObj.ProductCategory_id = 0;
                catObj.ProductCategory_name = "[Select]";
                prdList.Insert(0, catObj);

                ddlProductCat.DataSource = prdList;
                ddlProductCat.DataTextField = "ProductCategory_name";
                ddlProductCat.DataValueField = "ProductCategory_id";
                ddlProductCat.DataBind();
            }
            finally
            {

                _categoryController = null;
                prdList = null;
            }

        }
        protected void ddlProd1_SelectedIndexChanged(object sender, EventArgs e)
        {
            prodObj = new QuotationProductController();
            DataTable dt = prodObj.GetProductPrice(ddlProd1.SelectedItem.Value);

            lblPrice1.Text = dt.Rows[0]["Price"].ToString();
            lblProd1code.Text = ddlProd1.SelectedItem.Value;
            
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
             
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                DataRow newRow = QuotationProductController.myDataTable.NewRow();

                newRow["ID"] = QuotationProductController.myDataTable.Rows.Count + 1;
                newRow["Code"] = lblProd1code.Text;
                newRow["ProductName"] = ddlProd1.SelectedItem.Text;
                newRow["Price"] = lblPrice1.Text;
                newRow["Qty"] = txtQty1.Text;
                double total = Convert.ToDouble(lblPrice1.Text) * Convert.ToDouble(txtQty1.Text);
                newRow["Total"] = total;

                QuotationProductController.myDataTable.Rows.Add(newRow);
                
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            
        }

        protected void ddlProductCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            prodObj = new QuotationProductController();

            DataTable dt = prodObj.GetProductbyCatID(Convert.ToInt32(ddlProductCat.SelectedItem.Value));
            ddlProd1.DataSource = dt;
            ddlProd1.DataTextField = "ProductName";
            ddlProd1.DataValueField = "Code";
            ddlProd1.DataBind();
            prodObj = null;
        }

         
    }
}