using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NobleBLL;
using System.Configuration;
using NobleEntity;
using Telerik.Web.UI;
using System.IO;

namespace Noble.EmployerFiles
{
    public partial class EmployerFileAssign : System.Web.UI.Page
    {
        FileDetailsController objFileDetailsController = new FileDetailsController();
        EmployerFileController objefc = new EmployerFileController();
        GeneralController objGeneralController = new GeneralController();
        string UploadFolderName = ConfigurationManager.AppSettings["UploadFolderName"];


        protected void Page_Load(object sender, EventArgs e)
        {
            UploadFolderName = string.Concat(Server.MapPath(@"~\FileUpload\UploadedUserFiles"), @"\");

            lblMessage.Text = string.Empty;
            if (!IsPostBack)
            {
                ((Label)Master.FindControl("lblPageHeading")).Text = "Manage Files";
                FillEmployers();
                FillFileDetails();

            }
        }
        private void FillFileDetails()
        {
            if (Session["SelectedMember"] != null && !string.IsNullOrEmpty(Session["SelectedMember"].ToString()))
            {
                int MemberId = Convert.ToInt32(Session["SelectedMember"].ToString().Split(';')[0]);


                FileDetailsEntity objFileDetailsEntity = new FileDetailsEntity();
                objFileDetailsEntity.Member_ID = MemberId;
                List<FileDetailsEntity> lstFileDetails = objFileDetailsController.GetFileDetails(objFileDetailsEntity);
                radgvFiles.DataSource = lstFileDetails;
                radgvFiles.DataBind();
            }

        }

        protected void radgvFiles_DataBound(object sender, EventArgs e)
        {
            foreach (GridDataItem item in radgvFiles.Items)
            {


             
                    ImageButton btnselect = (ImageButton)item["SelectColumn"].Controls[0];
                    if (item["File_Type"].Text.Contains("doc"))
                        btnselect.ImageUrl = "~/images/FileUpload/ms_word_2_32.png";
                    else if (item["File_Type"].Text.Contains("pdf"))
                        btnselect.ImageUrl = "~/images/FileUpload/pdf_icon_32_pdf.gif";

                    else if (item["File_Type"].Text.Contains("txt"))
                        btnselect.ImageUrl = "~/images/FileUpload/notepad.jpg";
                    else if (item["File_Type"].Text.Contains("xls"))
                        btnselect.ImageUrl = "~/images/FileUpload/Excel.png";

                    else
                        btnselect.ImageUrl = "~/images/FileUpload/OneNote.png";

                    Dictionary<string, string> dicCombo = new Dictionary<string, string>();
                    dicCombo = objGeneralController.GetEmployerFileStatus();

                    RadComboBox ComboForStatus = (RadComboBox)item.FindControl("ddlEmployerFileStaus");

                    ComboForStatus.DataSource = dicCombo;
                    ComboForStatus.DataTextField = "Value";
                    ComboForStatus.DataValueField = "Key";
                    ComboForStatus.DataBind();
                    if (ddlEmployers.Items.Count > 0)
                    {

                        CheckBox chkAssigned = (CheckBox)item.FindControl("chkAssigned");
                        int FileID = Convert.ToInt32(item.GetDataKeyValue("File_ID").ToString());
                        EmployerFileEntity objefe = new EmployerFileEntity();
                        objefe.FileId = FileID;
                        objefe.EmployerId = Convert.ToInt32(ddlEmployers.SelectedValue.ToString());



                        if (objefc.IsEmployerFile(objefe).FileStatusID > 0)
                        {
                            chkAssigned.Checked = true;
                            ComboForStatus.SelectedIndex = ComboForStatus.Items.IndexOf(ComboForStatus.Items.FindItemByValue(objefc.IsEmployerFile(objefe).FileStatusID.ToString()));

                        }
                        else
                            chkAssigned.Checked = false;

                    }
            }


        }



        protected void radgvFiles_ItemCommand(object source, GridCommandEventArgs e)
        {
            GridDataItem item = (GridDataItem)e.Item;
            if (e.CommandName == "Select")
            {
                string PhysicalPtah = item.GetDataKeyValue("File_Path").ToString();
                PhysicalPtah = PhysicalPtah.Replace("public://cv/", UploadFolderName);
                string FileType;
                if (File.Exists(PhysicalPtah))
                {
                    if (item.GetDataKeyValue("File_Type").ToString().ToLower().Contains("doc"))
                        FileType = "application/msword";
                    else if (item.GetDataKeyValue("File_Type").ToString().ToLower().Contains("pdf"))
                        FileType = "application/pdf";

                    else if (item.GetDataKeyValue("File_Type").ToString().ToLower().Contains("jpg") || item.GetDataKeyValue("File_Type").ToString().ToLower().Contains("jpeg"))
                        FileType = "image/jpeg";
                    else if (item.GetDataKeyValue("File_Type").ToString().ToLower().Contains("gif"))
                        FileType = "image/gif";
                    else if (item.GetDataKeyValue("File_Type").ToString().ToLower().Contains("ico"))
                        FileType = "image/vnd.microsoft.icon";
                    else if (item.GetDataKeyValue("File_Type").ToString().ToLower().Contains("zip"))
                        FileType = "application/zip";
                    else if (item.GetDataKeyValue("File_Type").ToString().ToLower().Contains("ppt"))
                        FileType = "application/vnd.ms-powerpoint";
                    else if (item.GetDataKeyValue("File_Type").ToString().ToLower().Contains("htm"))
                        FileType = "text/HTML";
                    else if (item.GetDataKeyValue("File_Type").ToString().ToLower().Contains("txt"))
                        FileType = "text/plain";
                    else if (item.GetDataKeyValue("File_Type").ToString().ToLower().Contains("xls"))
                        FileType = "application/vnd.ms-excel";
                    else if (item.GetDataKeyValue("File_Type").ToString().ToLower().Contains("movie"))
                        FileType = "video/x-sgi-movie";
                    else if (item.GetDataKeyValue("File_Type").ToString().ToLower().Contains("avi"))
                        FileType = "video/x-msvideo";
                    else if (item.GetDataKeyValue("File_Type").ToString().ToLower().Contains("asx"))
                        FileType = "video/x-ms-asf";
                    else if (item.GetDataKeyValue("File_Type").ToString().ToLower().Contains("asr"))
                        FileType = "video/x-ms-asf";
                    else if (item.GetDataKeyValue("File_Type").ToString().ToLower().Contains("asf"))
                        FileType = "video/x-ms-asf";
                    else if (item.GetDataKeyValue("File_Type").ToString().ToLower().Contains("lsx"))
                        FileType = "video/x-la-asf";
                    else if (item.GetDataKeyValue("File_Type").ToString().ToLower().Contains("lsf"))
                        FileType = "video/x-la-asf";
                    else if (item.GetDataKeyValue("File_Type").ToString().ToLower().Contains("qt"))
                        FileType = "video/quicktime";
                    else if (item.GetDataKeyValue("File_Type").ToString().ToLower().Contains("mov"))
                        FileType = "video/quicktime";
                    else if (item.GetDataKeyValue("File_Type").ToString().ToLower().Contains("mpv2"))
                        FileType = "video/mpeg";
                    else if (item.GetDataKeyValue("File_Type").ToString().ToLower().Contains("mpg"))
                        FileType = "video/mpeg";
                    else if (item.GetDataKeyValue("File_Type").ToString().ToLower().Contains("mpeg"))
                        FileType = "video/mpeg";
                    else if (item.GetDataKeyValue("File_Type").ToString().ToLower().Contains("mpe"))
                        FileType = "video/mpeg";
                    else if (item.GetDataKeyValue("File_Type").ToString().ToLower().Contains("mpa"))
                        FileType = "video/mpeg";
                    else if (item.GetDataKeyValue("File_Type").ToString().ToLower().Contains("mp2"))
                        FileType = "video/mpeg";
                    else if (item.GetDataKeyValue("File_Type").ToString().ToLower().Contains("flv"))
                        FileType = "video/x-ms-wmv";
                    else
                        FileType = "application/octet-stream";

                    Response.ContentType = FileType;
                    Response.AppendHeader("Content-Disposition", string.Concat("attachment; filename=", item.GetDataKeyValue("File_Name").ToString()));
                    Response.TransmitFile(PhysicalPtah);
                    Response.End();
                }
            }
            FillFileDetails();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            if (ddlEmployers.Items.Count > 0)
            {
                foreach (GridDataItem item in radgvFiles.Items)
                {
                    CheckBox chkAssigned = (CheckBox)item.FindControl("chkAssigned");
                    RadComboBox ComboForStatus = (RadComboBox)item.FindControl("ddlEmployerFileStaus");
                    int FileID = Convert.ToInt32(item.GetDataKeyValue("File_ID").ToString());
                    EmployerFileEntity objefe = new EmployerFileEntity();
                    objefe.FileId = FileID;
                    objefe.EmployerId = Convert.ToInt32(ddlEmployers.SelectedValue.ToString());
                    objefe.FileStatusID = Convert.ToInt32(ComboForStatus.SelectedValue.ToString());
                    objefe.IsInsert = chkAssigned.Checked;
                    if (Session["LOGINUSERID"] != null && !string.IsNullOrEmpty(Session["LOGINUSERID"].ToString()))
                        objefe.Created_by = Convert.ToInt32(Session["LOGINUSERID"].ToString());
                    objefe.Created_on = System.DateTime.Now;

                    objefc.UpdateEmployerFileDetails(objefe);
                    lblMessage.Text = "Member Files have been assigned successfully.";
                }
            }
            FillFileDetails();
        }

        protected void ddlEmployers_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillFileDetails();

        }
        private void FillEmployers()
        {

            ddlEmployers.DataSource = objGeneralController.GetEmployers();
            ddlEmployers.DataBind();
            ddlEmployers.DataValueField = "Key";
            ddlEmployers.DataTextField = "Value";
            ddlEmployers.DataBind();


        }



    }
}