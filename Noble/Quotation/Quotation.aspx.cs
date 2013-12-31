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
using Aspose.Words;
using System.IO;

namespace Noble.Quotation
{
    public partial class Quotation : System.Web.UI.Page
    {
        QuotationController quotAccessObj = null;       
        GeneralController genAccessObj = null;
        static Int32 gQuotNo = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                
                fillTitle();

            
                    QuotationProductController.makeDatatable();
                    if (QuotationProductController.myDataTable != null)
                        QuotationProductController.myDataTable.Clear();


                    ((Label)Master.FindControl("lblFirstHeader")).Text = "Manage";
                    ((Label)Master.FindControl("lblSecondHeader")).Text = "Quotations";
            }
            BindGrid();
           
        }
        protected void gvQuot_PreRender(object sender, System.EventArgs e)
        {
           
        }

        protected void gvQuot_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            quotAccessObj = new QuotationController();
            try
            {
                if (Session["SelectedMember"] != null)
                {
                    gvQuot.DataSource = quotAccessObj.GetQuotationLists();

                }
                
            }
            finally
            {
                quotAccessObj = null;
            }
        }

        private void generateOutput()
        {
            Aspose.Words.License license = new Aspose.Words.License();
            license.SetLicense("Aspose.Words.lic");
            Document doc = new Document(string.Concat(Server.MapPath("Docs"), @"\Quotation.doc"));
            quotAccessObj = new QuotationController();

            DataTable dtHd = new DataTable();
            DataTable dtDetails = new DataTable();
            DataTable dtRates = new DataTable();
            dtHd = quotAccessObj.GetQuotationHrByID(gQuotNo);
            dtDetails = quotAccessObj.GetQuotationDetailsByID(gQuotNo);

            dtDetails.TableName = "Products";
            dtRates = quotAccessObj.GetQuotationRatesID(gQuotNo);

            if (dtHd != null && dtDetails != null && dtRates != null)
            {
                doc.MailMerge.Execute(dtHd);
                doc.MailMerge.ExecuteWithRegions(dtDetails);
                doc.MailMerge.Execute(dtRates);

                string strDateTime = System.DateTime.Now.ToString();
                strDateTime = strDateTime.Replace('/', '-').Replace(':', '-');
                string InputFileName = string.Concat(gQuotNo.ToString(), "_Quotation_", strDateTime + ".docx");
                string OutputFileName = string.Concat(gQuotNo.ToString(), "_Quotation_", strDateTime + ".pdf");

                string InputFilePath = string.Concat(Server.MapPath(@"~\FileUpload\UploadedUserFiles"), @"\Quotation\" + InputFileName);
                string OutputFilePath = string.Concat(Server.MapPath(@"~\FileUpload\UploadedUserFiles"), @"\Quotation\" + OutputFileName);

                doc.Save(InputFilePath);
                convertwordtopdf(InputFilePath, OutputFilePath);
                quotAccessObj.UpdateQuotationFilePath(gQuotNo, OutputFilePath);
                File.Delete(InputFilePath);
                quotAccessObj = null;
            }

        }

        public void convertwordtopdf(string inputfilename, string outputfilename)
        {
            Aspose.Words.License license = new Aspose.Words.License();
            license.SetLicense("Aspose.Words.lic");

            if (File.Exists(inputfilename))
            {
                Document doc = new Document(inputfilename);
                doc.Save(outputfilename);
            }
        }
        protected void gvQuot_UpdateCommand(object source, GridCommandEventArgs e)
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            UserControl userControl = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);
            QuotationEntity QuotEntity = new QuotationEntity();
            quotAccessObj = new QuotationController();
            try
            {
                QuotEntity.QuotNo = Convert.ToInt32(editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["QuotNo"].ToString());
                QuotEntity.Date = (userControl.FindControl("rdDate") as RadDatePicker).SelectedDate.ToString();

                QuotEntity.Validtill = (userControl.FindControl("rdValidDate") as RadDatePicker).SelectedDate.ToString();
                QuotEntity.title = (userControl.FindControl("ddlTitle") as DropDownList).Text;
                QuotEntity.Firstname = (userControl.FindControl("txtFirstname") as TextBox).Text;
                QuotEntity.Lastname = (userControl.FindControl("txtLastname") as TextBox).Text;
                QuotEntity.Address = (userControl.FindControl("txtAddress") as TextBox).Text;
                QuotEntity.HST = Convert.ToDouble((userControl.FindControl("txtHST") as TextBox).Text);
                quotAccessObj.UpdateQuotation(QuotEntity);

                QuotationDetailsEntity QuotDEntity = null;
                gQuotNo = QuotEntity.QuotNo;
                QuotDEntity = new QuotationDetailsEntity();
                QuotDEntity.QuotNo = QuotEntity.QuotNo;
                quotAccessObj.DeleteQuotationDetails(QuotDEntity);


                foreach (DataRow row in QuotationProductController.editmyDataTable.Rows)
                {
                    QuotDEntity.Code = row["Code"].ToString();
                    QuotDEntity.QuotNo = gQuotNo;
                    QuotDEntity.Qty = Convert.ToInt32(row["Qty"].ToString());
                    quotAccessObj.AddNewQuotationDetails(QuotDEntity);
                }

                generateOutput();

                QuotationProductController.editmyDataTable.Clear();
                QuotationProductController.myDataTable.Clear();
            }

            finally
            {
                quotAccessObj = null;
                QuotEntity = null;
            }
        }

        protected void gvQuot_InsertCommand(object source, GridCommandEventArgs e)
        {
            UserControl userControl = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);
            QuotationEntity QuotEntity = new QuotationEntity();
            quotAccessObj = new QuotationController();

            try
            {
                //QuotEntity.QuotNo = Convert.ToInt32((userControl.FindControl("txtQuotNo") as TextBox).Text);
                QuotEntity.Date =(userControl.FindControl("rdDate") as RadDatePicker).SelectedDate.ToString();

                QuotEntity.Validtill = (userControl.FindControl("rdValidDate") as RadDatePicker).SelectedDate.ToString();
                QuotEntity.title = (userControl.FindControl("ddlTitle") as DropDownList).Text;
                QuotEntity.Firstname = (userControl.FindControl("txtFirstname") as TextBox).Text;
                QuotEntity.Lastname = (userControl.FindControl("txtLastname") as TextBox).Text;
                QuotEntity.Address = (userControl.FindControl("txtAddress") as TextBox).Text;
                QuotEntity.HST = Convert.ToDouble((userControl.FindControl("txtHST") as TextBox).Text);

                QuotationDetailsEntity QuotDEntity = null;
                if (quotAccessObj.AddNewQuotation(QuotEntity) && QuotationProductController.myDataTable.Rows.Count>0)
                {

                    gQuotNo = quotAccessObj.getMaxQuotNo();
                    QuotDEntity = new QuotationDetailsEntity();

                    foreach (DataRow row in QuotationProductController.myDataTable.Rows)
                    {
                        QuotDEntity.Code = row["Code"].ToString();
                        QuotDEntity.QuotNo = gQuotNo;
                        QuotDEntity.Qty = Convert.ToInt32(row["Qty"].ToString());
                        quotAccessObj.AddNewQuotationDetails(QuotDEntity);
                    }

                    QuotationProductController.myDataTable.Clear();

                   
                    generateOutput();
                    BindGrid();
                    lblStatus.Text = "Records Saved Successfully";
                }
            }
            finally
            {
                quotAccessObj = null;
                quotAccessObj = null;
            }
        }

        protected void gvQuot_DeleteCommand(object source, GridCommandEventArgs e)
        {
            quotAccessObj = new QuotationController();
            QuotationEntity QuotEntity = null;
            QuotationDetailsEntity QuotDEntity = null;
            try
            {
                QuotEntity = new QuotationEntity();
                QuotDEntity = new QuotationDetailsEntity();
                QuotEntity.QuotNo = Convert.ToInt32((e.Item as GridDataItem).OwnerTableView.DataKeyValues[e.Item.ItemIndex]["QuotNo"].ToString());
                QuotDEntity.QuotNo = QuotEntity.QuotNo;
                bool res = quotAccessObj.DeleteQuotationHr(QuotEntity);
                bool res2=quotAccessObj.DeleteQuotationDetails(QuotDEntity);
                BindGrid();
            }
            finally
            {
                quotAccessObj = null;
                QuotEntity = null;
            }
        }

       

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            
            
        }
        protected void Product_Binding(object sender, System.EventArgs e)
        {

           
            fillTitle();



        }
        protected void fillTitle()
        {
            genAccessObj = new GeneralController();

        }

        private void fillProducts(DropDownList ddlProd)
        {
            quotAccessObj = new QuotationController();
            //ddlProd.Items.Insert(0, new ListItem("--Select --", "0"));
            DataTable dt = quotAccessObj.GetProductDatatable();
            ddlProd.DataSource = dt;
            ddlProd.DataTextField = "ProductName";
            ddlProd.DataValueField = "Code";
            ddlProd.DataBind();
            //ddlProd.Items.Insert(0, new ListItem("--Select City--", "--Select City--"));
            ddlProd.Items.Insert(0, new ListItem("--Select --", "0"));
        }       
              
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void gvQuot_ItemCommand(object source, GridCommandEventArgs e)
        {

            if (e.CommandName == RadGrid.EditCommandName)
            {
                GridEditableItem editedItem = e.Item as GridEditableItem;
                QuotationEntity QuotEntity = new QuotationEntity();
                quotAccessObj = new QuotationController();

                QuotationController.QuotNo = Convert.ToInt32(editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["QuotNo"].ToString());
            }
            if (e.CommandName == "Select")
            {
                GridDataItem item = (GridDataItem)e.Item;
               // string UploadFolderName = string.Concat(Server.MapPath("UploadedUserFiles"), @"\");
                string PhysicalPtah = item.GetDataKeyValue("FilePath").ToString();
                //PhysicalPtah = PhysicalPtah.Replace("public://cv/", UploadFolderName);
                
                if (File.Exists(PhysicalPtah))
                {


                    Response.ContentType = "application/pdf"; ;

                    string filename=PhysicalPtah.Substring(PhysicalPtah.LastIndexOf("\\"),PhysicalPtah.Length-PhysicalPtah.LastIndexOf("\\"));
                    Response.AppendHeader("Content-Disposition", string.Concat("attachment; filename=", filename.Substring(1, filename.Length - 1)));
                    Response.TransmitFile(PhysicalPtah);
                    Response.End();
                }
            }
           
        }

        protected void gvQuot_DataBound(object sender, EventArgs e)
        {
            foreach (GridDataItem item in gvQuot.Items)
            {

                ImageButton btnselect = (ImageButton)item["SelectColumn"].Controls[0];

                btnselect.ImageUrl = "~/images/FileUpload/pdf_icon_32_pdf.gif";

            }
        }      

    }
}