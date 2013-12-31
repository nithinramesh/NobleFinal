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
using System.Configuration;
using System.IO;


namespace Noble.Invoice
{
    public partial class AddInvoice : System.Web.UI.Page
    {
        InvoiceController invAccessObj = null;
        GeneralController genAccessObj = null;
        static Int32 gInvNo=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                fillTitle();


                InvoiceController.makeDatatable();
                if (InvoiceController.myDataTable != null)
                    InvoiceController.myDataTable.Clear();

                ((Label)Master.FindControl("lblFirstHeader")).Text = "Invoice";
                ((Label)Master.FindControl("lblSecondHeader")).Text = "Details";

            }
            BindGrid();

            
        }

        protected void gvInv_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            invAccessObj = new InvoiceController();
            try
            {
                if (Session["SelectedMember"] != null)
                {
                    int MemberId = Convert.ToInt32(Session["SelectedMember"].ToString().Split(';')[0]);
                    gvInv.DataSource = invAccessObj.GetInvoiceLists(MemberId);

                }

            }
            finally
            {
                invAccessObj = null;
            }
        }
        protected void gvInv_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.EditCommandName)
            {
                GridEditableItem editedItem = e.Item as GridEditableItem;
                InvoiceEntity InvEntity = new InvoiceEntity();
                invAccessObj = new InvoiceController();

                InvoiceController.InvNo = Convert.ToInt32(editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["InvNo"].ToString());
            }
            if (e.CommandName == "Select")
            {
                GridDataItem item = (GridDataItem)e.Item;
                string UploadFolderName = string.Concat(Server.MapPath("UploadedUserFiles"), @"\");
                string PhysicalPtah = item.GetDataKeyValue("FilePath").ToString();
                PhysicalPtah = PhysicalPtah.Replace("public://cv/", UploadFolderName);

                if (File.Exists(PhysicalPtah))
                {


                    Response.ContentType = "application/pdf"; ;

                    string filename = PhysicalPtah.Substring(PhysicalPtah.LastIndexOf("\\"), PhysicalPtah.Length - PhysicalPtah.LastIndexOf("\\"));
                    Response.AppendHeader("Content-Disposition", string.Concat("attachment; filename=", filename.Substring(1, filename.Length - 1)));
                    Response.TransmitFile(PhysicalPtah);
                    Response.End();
                }
            }
        }

        protected void gvInv_InsertCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            
            try
            {
                int MemberId;
                int CreatedBy = 0;
                if (Session["SelectedMember"] != null && !string.IsNullOrEmpty(Session["SelectedMember"].ToString()))
                {
                    if (Session["LOGINUSERID"] != null && !string.IsNullOrEmpty(Session["LOGINUSERID"].ToString()))
                        CreatedBy = Convert.ToInt32(Session["LOGINUSERID"].ToString()); ;
                    MemberId = Convert.ToInt32(Session["SelectedMember"].ToString().Split(';')[0]);

                    UserControl userControl = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);
                    InvoiceEntity InvEntity = new InvoiceEntity();
                    invAccessObj = new InvoiceController();


                    int count = Convert.ToInt16((userControl.FindControl("gvInvDetails") as RadGrid).Items.Count);
                    if (count == 0)
                    {
                        lblError.Text = "Products details should not be empty";
                        gvInv.MasterTableView.IsItemInserted = false;
                        e.Canceled = true;
                        return;
                    }
                    InvEntity.Member_ID = MemberId;
                    InvEntity.Date = (userControl.FindControl("rdDate") as RadDatePicker).SelectedDate.ToString();

                    InvEntity.DueDate = (userControl.FindControl("rdValidDate") as RadDatePicker).SelectedDate.ToString();
                    InvEntity.title = (userControl.FindControl("ddlTitle") as DropDownList).Text;
                    InvEntity.Firstname = (userControl.FindControl("txtFirstname") as TextBox).Text;
                    InvEntity.Lastname = (userControl.FindControl("txtLastname") as TextBox).Text;
                    InvEntity.Address = (userControl.FindControl("txtAddress") as TextBox).Text;
                    InvEntity.HST = Convert.ToDouble((userControl.FindControl("txtHST") as TextBox).Text);

                    InvoiceDetailsEntity InvDEntity = null;
                    if (InvoiceController.myDataTable.Rows.Count > 0)
                    {
                        if (invAccessObj.AddNewInvoice(InvEntity))
                        {

                            gInvNo = invAccessObj.getMaxInvNo();
                            InvDEntity = new InvoiceDetailsEntity();

                            foreach (DataRow row in InvoiceController.myDataTable.Rows)
                            {
                                InvDEntity.Code = row["Code"].ToString();
                                InvDEntity.InvNo = gInvNo;
                                InvDEntity.Qty = Convert.ToInt32(row["Qty"].ToString());
                                InvDEntity.Regular = "0";
                                invAccessObj.AddNewInvoiceDetails(InvDEntity);
                            }

                            InvoiceController.myDataTable.Clear();

                           
                            generateOutput();
                            BindGrid();
                            lblError.Text = "Records Saved Successfully.";
                            
                        }
                    }
                }

            }
            finally
            {
                invAccessObj = null;
                invAccessObj = null;
                 
            }
            
        }


        private void generateOutput()
        {
            FileDetailsController objFileDetailsController = new FileDetailsController();
            FileDetailsEntity objFileDetailsEntity = new FileDetailsEntity();
            int MemberId;
            int CreatedBy = 0;
            try
            {
                if (Session["SelectedMember"] != null && !string.IsNullOrEmpty(Session["SelectedMember"].ToString()))
                {
                    if (Session["LOGINUSERID"] != null && !string.IsNullOrEmpty(Session["LOGINUSERID"].ToString()))
                        CreatedBy = Convert.ToInt32(Session["LOGINUSERID"].ToString()); ;
                    MemberId = Convert.ToInt32(Session["SelectedMember"].ToString().Split(';')[0]);

                    Aspose.Words.License license = new Aspose.Words.License();
                    license.SetLicense("Aspose.Words.lic");

                    Document doc = new Document(string.Concat(Server.MapPath("Docs"), @"\invoice.doc"));
                    invAccessObj = new InvoiceController();

                    DataTable dtHd = new DataTable();
                    DataTable dtDetails = new DataTable();
                    DataTable dtRates = new DataTable();
                    dtHd = invAccessObj.GetInvoicenHrByID(gInvNo);
                    dtDetails = invAccessObj.GetInvoiceDetailsByID(gInvNo);

                    dtDetails.TableName = "Products";
                    dtRates = invAccessObj.GetInvoiceRatesID(gInvNo);
                    if (dtHd != null && dtDetails != null && dtRates != null)
                    {
                        doc.MailMerge.Execute(dtHd);
                        doc.MailMerge.ExecuteWithRegions(dtDetails);
                        doc.MailMerge.Execute(dtRates);

                        string strDateTime = System.DateTime.Now.ToString();
                        strDateTime = strDateTime.Replace('/', '-').Replace(':', '-');                        

                        string InputFileName = string.Concat(gInvNo.ToString(), "_Invoice_", strDateTime + ".docx");
                        string OutputFileName = string.Concat(gInvNo.ToString(), "_Invoice_", strDateTime + ".pdf");

                        string InputFilePath = string.Concat(Server.MapPath(@"~\FileUpload\UploadedUserFiles"), @"\Invoice\" + InputFileName);
                        string OutputFilePath = string.Concat(Server.MapPath(@"~\FileUpload\UploadedUserFiles"), @"\Invoice\" + OutputFileName);

                        doc.Save(InputFilePath);
                        convertwordtopdf(InputFilePath, OutputFilePath);
                        invAccessObj.UpdateInvoiceFilePath(gInvNo, OutputFilePath);
                        invAccessObj = null;

                        objFileDetailsEntity.Member_ID = MemberId;
                        objFileDetailsEntity.File_Name = OutputFileName;
                        objFileDetailsEntity.File_Type = System.IO.Path.GetExtension(OutputFileName);
                        objFileDetailsEntity.File_Path = string.Concat(OutputFilePath);
                        objFileDetailsEntity.File_Category = "Invoice";
                        objFileDetailsEntity.Created_by = CreatedBy;
                        objFileDetailsEntity.Created_on = Convert.ToDateTime(System.DateTime.Today);
                        objFileDetailsController.InsertFileDetails(objFileDetailsEntity);

                        File.Delete(InputFilePath);


                    }
                }
            }
            finally
            {
                objFileDetailsEntity = null;
                objFileDetailsController = null;
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

        protected void gvInv_DeleteCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            invAccessObj = new InvoiceController();
            InvoiceEntity InvEntity = null;
            InvoiceDetailsEntity InvDEntity = null;
            try
            {
                InvEntity = new InvoiceEntity();
                InvDEntity = new InvoiceDetailsEntity();
                InvEntity.InvNo = Convert.ToInt32((e.Item as GridDataItem).OwnerTableView.DataKeyValues[e.Item.ItemIndex]["InvNo"].ToString());
                InvDEntity.InvNo = InvEntity.InvNo;
                bool res = invAccessObj.DeleteInvoiceHr(InvEntity);
                bool res2 = invAccessObj.DeleteInvoiceDetails(InvDEntity);
                BindGrid();
            }
            finally
            {
                invAccessObj = null;
                InvEntity = null;
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
            invAccessObj = new InvoiceController();
            //ddlProd.Items.Insert(0, new ListItem("--Select --", "0"));
            DataTable dt = invAccessObj.GetProductDatatable();
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

        protected void gvInv_UpdateCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            UserControl userControl = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);
            InvoiceEntity InvEntity = new InvoiceEntity();
            invAccessObj = new InvoiceController();
            try
            {
                InvEntity.InvNo = Convert.ToInt32(editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["InvNo"].ToString());
                InvEntity.Date = (userControl.FindControl("rdDate") as RadDatePicker).SelectedDate.ToString();

                InvEntity.DueDate = (userControl.FindControl("rdValidDate") as RadDatePicker).SelectedDate.ToString();
                InvEntity.title = (userControl.FindControl("ddlTitle") as DropDownList).Text;
                InvEntity.Firstname = (userControl.FindControl("txtFirstname") as TextBox).Text;
                InvEntity.Lastname = (userControl.FindControl("txtLastname") as TextBox).Text;
                InvEntity.Address = (userControl.FindControl("txtAddress") as TextBox).Text;
                InvEntity.HST = Convert.ToDouble((userControl.FindControl("txtHST") as TextBox).Text);

                invAccessObj.UpdateInvoice(InvEntity);

                InvoiceDetailsEntity InvDEntity = null;
                gInvNo = InvEntity.InvNo;
                InvDEntity = new InvoiceDetailsEntity();
                InvDEntity.InvNo = InvEntity.InvNo;
                invAccessObj.DeleteInvoiceDetails(InvDEntity);


                foreach (DataRow row in InvoiceController.editmyDataTable.Rows)
                {
                    InvDEntity.Code = row["Code"].ToString();
                    InvDEntity.InvNo = gInvNo;
                    InvDEntity.Qty = Convert.ToInt32(row["Qty"].ToString());
                    InvDEntity.Regular = "0";
                    invAccessObj.AddNewInvoiceDetails(InvDEntity);
                }

                InvoiceController.editmyDataTable.Clear();
                InvoiceController.myDataTable.Clear();

                generateOutput();
            }

            finally
            {
                invAccessObj = null;
                InvEntity = null;
            }
        }

        protected void gvInv_DataBound(object sender, EventArgs e)
        {
            foreach (GridDataItem item in gvInv.Items)
            {

                ImageButton btnselect = (ImageButton)item["SelectColumn"].Controls[0];

                btnselect.ImageUrl = "~/images/FileUpload/pdf_icon_32_pdf.gif";

            }
        }
    }
}