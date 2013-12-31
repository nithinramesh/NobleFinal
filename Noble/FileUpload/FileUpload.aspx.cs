using System;
using System.IO;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using NobleBLL;
using NobleEntity;
using System.Collections;
using System.Collections.Generic;
using Telerik.Web.UI;
using Microsoft.Win32;
namespace Noble.FileUpload
{
    public partial class FileUpload : System.Web.UI.Page
    {
        FileDetailsController objFileDetailsController = new FileDetailsController();

        string UploadFolderName = ConfigurationManager.AppSettings["UploadFolderName"];


        protected void Page_Load(object sender, EventArgs e)
        {
            UploadFolderName = string.Concat(Server.MapPath("UploadedUserFiles"), @"\");


            if (!IsPostBack)
            {
                //((Label)Master.FindControl("lblPageHeading")).Text = " ";
                ((Label)Master.FindControl("lblFirstHeader")).Text = "Manage";
                ((Label)Master.FindControl("lblSecondHeader")).Text = "Files";
                FillFileDetails();
                FillSubFolders();
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int MemberId;
            int CreatedBy = 0;
            bool isfile = false;
            if (Session["SelectedMember"] != null && !string.IsNullOrEmpty(Session["SelectedMember"].ToString()))
            {
                if (Session["LOGINUSERID"] != null && !string.IsNullOrEmpty(Session["LOGINUSERID"].ToString()))
                    CreatedBy = Convert.ToInt32(Session["LOGINUSERID"].ToString()); ;
                MemberId = Convert.ToInt32(Session["SelectedMember"].ToString().Split(';')[0]);


                HttpFileCollection uploads = HttpContext.Current.Request.Files;
                for (int i = 0; i < uploads.Count; i++)
                {
                    HttpPostedFile upload = uploads[i];

                    if (upload.ContentLength == 0)
                    {

                        continue;

                    }
                    else
                    {
                        isfile = true;
                    }
                    lblMessage.Text = string.Empty;

                    string FileName = System.IO.Path.GetFileName(upload.FileName); // We don't need the path, just the name.
                    string FileNamesubfolder = string.Concat(UploadFolderName, ddlSubfolders.SelectedItem.Text);
                    FileDetailsEntity objFileDetailsEntity = new FileDetailsEntity();
                    objFileDetailsEntity.Member_ID = MemberId;
                    objFileDetailsEntity.File_Name = FileName;
                    objFileDetailsEntity.File_Type = System.IO.Path.GetExtension(FileName);
                    objFileDetailsEntity.File_Path = string.Concat(FileNamesubfolder, @"\", FileName);
                    objFileDetailsEntity.File_Category = ddlSubfolders.SelectedItem.Text;
                    objFileDetailsEntity.Created_by = CreatedBy;
                    objFileDetailsEntity.Created_on = Convert.ToDateTime(System.DateTime.Today);


                    try
                    {
                        if (!Directory.Exists(FileNamesubfolder))
                        {
                            Directory.CreateDirectory(FileNamesubfolder);
                        }

                        upload.SaveAs(objFileDetailsEntity.File_Path);
                        objFileDetailsController.InsertFileDetails(objFileDetailsEntity);
                        FillFileDetails();
                        Span1.InnerHtml = "Upload(s) Successful.";

                    }
                    catch (Exception Exp)
                    {
                        Span1.InnerHtml = "Upload(s) FAILED. " + Exp.Message;
                    }
                }
                if (!isfile)
                    lblMessage.Text = "Please browse the file to continue..........";
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



        private void FillSubFolders()
        {

            ddlSubfolders.DataSource = objFileDetailsController.GetSubFolders();
            ddlSubfolders.DataBind();
            ddlSubfolders.DataTextField = "SubFolder_Name";
            ddlSubfolders.DataValueField = "SubFolder_ID";
            ddlSubfolders.DataBind();


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
            }


        }



        protected void radgvFiles_ItemCommand(object source, GridCommandEventArgs e)
        {
            GridDataItem item = (GridDataItem)e.Item;
            if (e.CommandName == "Delete")
            {

                string FileID = item.GetDataKeyValue("File_ID").ToString();
                string PhysicalPtah = item.GetDataKeyValue("File_Path").ToString();

                FileDetailsEntity objFileDetailsEntity = new FileDetailsEntity();
                objFileDetailsEntity.File_ID = Convert.ToInt32(FileID);

                objFileDetailsController.DeleteFileDetails(objFileDetailsEntity);

                HyperLink lnkShow = (HyperLink)item.FindControl("hlnkShowFile");

                PhysicalPtah = PhysicalPtah.Replace("public://cv/", UploadFolderName);
                if (File.Exists(PhysicalPtah))
                {
                    File.Delete(PhysicalPtah);
                }

                FillFileDetails();


            }
            else if (e.CommandName == "Select")
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
      



    }
}