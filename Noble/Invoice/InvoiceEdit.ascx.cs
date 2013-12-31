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

namespace Noble.Invoice
{
    public partial class InvoiceEdit : System.Web.UI.UserControl
    {
        private object _dataItem = null;
        InvoiceController invAccessObj = null;
        QuotationProductController prodObj = null;
        GeneralController genAccessObj = null;
        static Int32 InvNo_for_delete = 0;

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
            invAccessObj = new InvoiceController();

            DataTable dt = invAccessObj.GetProductDatatable();
            ddlProd.DataSource = dt;
            ddlProd.DataTextField = "ProductName";
            ddlProd.DataValueField = "Code";
            ddlProd.DataBind();

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //editmode = false;

            InvoiceController.editmyDataTable.Dispose();

            int columncount = 0;

            foreach (GridColumn column in gvInvDetails.MasterTableView.Columns)
            {
                if (!string.IsNullOrEmpty(column.UniqueName) && !string.IsNullOrEmpty(column.HeaderText))
                {
                    columncount++;
                    if (InvoiceController.editmyDataTable.Columns.Contains(column.UniqueName) == false)
                    {
                        InvoiceController.editmyDataTable.Columns.Add(column.UniqueName, typeof(string));
                    }
                }
            }

            DataRow dr;
            foreach (GridDataItem item in gvInvDetails.MasterTableView.Items)
            {
                dr = InvoiceController.editmyDataTable.NewRow();

                for (int i = 0; i < columncount; i++)
                {
                    dr[i] = item[gvInvDetails.MasterTableView.Columns[i].UniqueName].Text;
                }

                if (gvInvDetails.MasterTableView.Items.Count != InvoiceController.editmyDataTable.Rows.Count)
                    InvoiceController.editmyDataTable.Rows.Add(dr);
            }


        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if (gvInvDetails.Items.Count == 0)
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
            //InvoiceController.editmyDataTable.Clear();

        }



        private void BindGrid()
        {
            invAccessObj = new InvoiceController();
            prodObj = new QuotationProductController();
            try
            {
                  if (Session["LOGINUSERID"] != null && !string.IsNullOrEmpty(Session["LOGINUSERID"].ToString()))
                  {
                       int CreatedBy = Convert.ToInt32(Session["LOGINUSERID"].ToString()); 
                    int MemberId = Convert.ToInt32(Session["SelectedMember"].ToString().Split(';')[0]);
                

                    if (InvoiceController.InvNo > 0)
                    {
                        // edit mode
                        gvInvDetails.DataSource = null;
                        DataTable dt = invAccessObj.GetInvoiceProductDetailsByID(InvoiceController.InvNo, MemberId);

                        gvInvDetails.DataSource = dt;

                        if (dt == null)
                        {
                            InvoiceController.myDataTable.Clear();
                        }
                        else
                            InvoiceController.myDataTable = dt;
                        InvNo_for_delete = InvoiceController.InvNo;
                        InvoiceController.InvNo = 0;

                    }
                    else
                    {
                        //Add mode
                        DataTable dt = new DataTable();
                        dt = prodObj.GetProductDetails();
                        dt.Clear();
                        gvInvDetails.DataSource = dt;
                    }

                }

            }
            finally
            {
                gvInvDetails = null;
                prodObj = null;
            }
        }

        protected void gvInvDetails_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            if (InvoiceController.InvNo > 0)
                BindGrid();
            else if (InvoiceController.myDataTable != null && InvoiceController.myDataTable.Rows.Count > 0)
                gvInvDetails.DataSource = InvoiceController.myDataTable;

            else
                BindGrid();
        }

        protected void gvInvDetails_DeleteCommand(object source, GridCommandEventArgs e)
        {
            prodObj = new QuotationProductController();
            string ID = (e.Item as GridDataItem).OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"].ToString();
            //DataTable dt = prodObj.GetProductDetailsByID(InvNo_for_delete);
            if (InvoiceController.myDataTable != null)
            {
                DataColumn[] keyColumns = new DataColumn[1];
                keyColumns[0] = InvoiceController.myDataTable.Columns["ID"];
                InvoiceController.myDataTable.PrimaryKey = keyColumns;
                if (InvoiceController.myDataTable.Rows.Find(ID) != null)
                {
                    InvoiceController.myDataTable.Rows.Find(ID).Delete();
                    InvoiceController.myDataTable.PrimaryKey = null;
                    InvoiceController.myDataTable.AcceptChanges();
                }
                gvInvDetails.DataSource = null;
                gvInvDetails.DataSource = InvoiceController.myDataTable;

                if (InvoiceController.editmyDataTable == null)
                {
                    int columncount = 0;
                    foreach (GridColumn column in gvInvDetails.MasterTableView.Columns)
                    {
                        if (!string.IsNullOrEmpty(column.UniqueName) && !string.IsNullOrEmpty(column.HeaderText))
                        {
                            columncount++;
                            if (InvoiceController.editmyDataTable.Columns.Contains(column.UniqueName) == false)
                            {
                                InvoiceController.editmyDataTable.Columns.Add(column.UniqueName, typeof(string));
                            }
                        }
                    }
                }

                //InvoiceController.editmyDataTable = dt;
                InvoiceController.editmyDataTable.PrimaryKey = null;
            }
        }

    }
}