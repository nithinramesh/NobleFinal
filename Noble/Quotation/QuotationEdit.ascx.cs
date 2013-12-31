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
    public partial class QuotationEdit : System.Web.UI.UserControl
    {
        private object _dataItem = null;
        QuotationController quotAccessObj = null;
        QuotationProductController prodObj = null;
        GeneralController genAccessObj = null;
        static Int32 QuotNo_for_delete = 0;
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
           
            fillTitle();
           
        }
        protected void fillTitle()
        {
            genAccessObj = new GeneralController();
            ddlTitle.DataSource = genAccessObj.GetTitle();
            ddlTitle.DataValueField = "Key";
            ddlTitle.DataTextField = "Value";
            ddlTitle.DataBind();
            ddlTitle.Items.Insert(0, new ListItem("Select", "-1"));
        }

        private void fillProducts(DropDownList ddlProd)
        {
            quotAccessObj = new QuotationController();

            DataTable dt = quotAccessObj.GetProductDatatable();
            ddlProd.DataSource = dt;
            ddlProd.DataTextField = "ProductName";
            ddlProd.DataValueField = "Code";
            ddlProd.DataBind();
            
        }  
               

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //editmode = false;
            
            QuotationProductController.editmyDataTable.Dispose();

            int columncount = 0;

            foreach (GridColumn column in gvQuotDetails.MasterTableView.Columns)
            {
                if (!string.IsNullOrEmpty(column.UniqueName) && !string.IsNullOrEmpty(column.HeaderText))
                {
                    columncount++;
                    if (QuotationProductController.editmyDataTable.Columns.Contains(column.UniqueName) == false)
                    {
                        QuotationProductController.editmyDataTable.Columns.Add(column.UniqueName, typeof(string));
                    }
                }
            }

            DataRow dr;
            foreach (GridDataItem item in gvQuotDetails.MasterTableView.Items)
            {
                dr = QuotationProductController.editmyDataTable.NewRow();

                for (int i = 0; i < columncount; i++)
                {
                    dr[i] = item[gvQuotDetails.MasterTableView.Columns[i].UniqueName].Text;
                }

                if (gvQuotDetails.MasterTableView.Items.Count != QuotationProductController.editmyDataTable.Rows.Count)
                    QuotationProductController.editmyDataTable.Rows.Add(dr);
            }


        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if (gvQuotDetails.Items.Count == 0)
            {
                lblError.Visible = true;
                lblError.Text = "Products details should not be empty";
                DataItem = false;
            }
            else
            {
                lblError.Visible = false;
                lblError.Text = "";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //editmode = false;
            //QuotationProductController.editmyDataTable.Clear();

        }

        
       
        private void BindGrid()
        {
            prodObj = new QuotationProductController();
            try
            {
                if (Session["SelectedMember"] != null)
                {
                  
                     if (QuotationController.QuotNo > 0)
                    {
                        // edit mode
                        gvQuotDetails.DataSource = null;
                        DataTable dt = prodObj.GetProductDetailsByID(QuotationController.QuotNo);
                        
                        gvQuotDetails.DataSource = dt;

                        if (dt == null)
                        {
                            QuotationProductController.myDataTable.Clear();
                        }
                        else
                            QuotationProductController.myDataTable = dt;
                        QuotNo_for_delete = QuotationController.QuotNo;
                        QuotationController.QuotNo = 0;
                       
                    }
                    else
                    {
                        //Add mode
                        DataTable dt = new DataTable();
                        dt = prodObj.GetProductDetails(); 
                        dt.Clear();
                        gvQuotDetails.DataSource = dt;
                    }                     
                     
                }

            }
            finally
            {
                prodObj = null;
            }
        }


        protected void gvQuotDetails_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            //if (ProductController.myDataTable != null && ProductController.myDataTable.Rows.Count > 0)
            //    gvQuotDetails.DataSource = ProductController.myDataTable;
            
            //else if (ProductController.editmyDataTable != null && ProductController.editmyDataTable.Rows.Count > 0)
            //    gvQuotDetails.DataSource = ProductController.editmyDataTable;
            
            //else
            //    BindGrid();

            if (QuotationController.QuotNo > 0)
                BindGrid();
            else if (QuotationProductController.myDataTable != null && QuotationProductController.myDataTable.Rows.Count > 0)
                gvQuotDetails.DataSource = QuotationProductController.myDataTable;            

            else
                BindGrid();
        }

        protected void gvQuotDetails_DeleteCommand(object source, GridCommandEventArgs e)
        {
            prodObj = new QuotationProductController();
            string ID = (e.Item as GridDataItem).OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"].ToString();
            //DataTable dt = prodObj.GetProductDetailsByID(QuotNo_for_delete);
            if (QuotationProductController.myDataTable != null)
            {
                DataColumn[] keyColumns = new DataColumn[1];
                keyColumns[0] = QuotationProductController.myDataTable.Columns["ID"];
                QuotationProductController.myDataTable.PrimaryKey = keyColumns;
                if (QuotationProductController.myDataTable.Rows.Find(ID) != null)
                {
                    QuotationProductController.myDataTable.Rows.Find(ID).Delete();
                    QuotationProductController.myDataTable.PrimaryKey = null;
                    QuotationProductController.myDataTable.AcceptChanges();
                }
                gvQuotDetails.DataSource = null;
                gvQuotDetails.DataSource = QuotationProductController.myDataTable;

                if (QuotationProductController.editmyDataTable == null)
                {
                    int columncount = 0;
                    foreach (GridColumn column in gvQuotDetails.MasterTableView.Columns)
                    {
                        if (!string.IsNullOrEmpty(column.UniqueName) && !string.IsNullOrEmpty(column.HeaderText))
                        {
                            columncount++;
                            if (QuotationProductController.editmyDataTable.Columns.Contains(column.UniqueName) == false)
                            {
                                QuotationProductController.editmyDataTable.Columns.Add(column.UniqueName, typeof(string));
                            }
                        }
                    }
                }

                //QuotationProductController.editmyDataTable = dt;
                QuotationProductController.editmyDataTable.PrimaryKey = null;
            }
        }

    }
}