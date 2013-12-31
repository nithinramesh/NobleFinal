using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using NobleEntity;
using NobleBLL;
using System.IO;
using Telerik.Web.UI;

namespace Noble.Employer
{
    public partial class EmpLandingPage : System.Web.UI.Page
    {
        string UploadFolderName = ConfigurationManager.AppSettings["UploadFolderName"];
        EmployerFileController obj = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            UploadFolderName = string.Concat(Server.MapPath(@"~\FileUpload\UploadedUserFiles"), @"\");

            if (!Page.IsPostBack)
            {
                ((Label)Master.FindControl("lblPageHeading")).Text = "View Resumes";

                //FillFileDetails();
            }
        }

        private void FillFileDetails()
        {
            if (Session["LOGINEMPLOYERID"] != null)
            {
                obj = new EmployerFileController();
                List<EmployerFileEntity> lstFileDetails = obj.GetEmployerFiles(Convert.ToInt32(Session["LOGINEMPLOYERID"]));
                radgvFiles.DataSource = lstFileDetails;
                //radgvFiles.DataBind();
            }
        }

        protected void radgvFiles_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            FillFileDetails();
        }

        protected void radgvFiles_Init(object sender, System.EventArgs e)
        {
            GridFilterMenu menu = radgvFiles.FilterMenu;
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

        protected void radgvFiles_DataBound(object sender, EventArgs e)
        {
            foreach (GridDataItem item in radgvFiles.Items)
            {


                ImageButton btnselect = (ImageButton)item["SelectColumn"].Controls[0];
                if (item.GetDataKeyValue("File_Type").ToString().Contains("doc"))
                    btnselect.ImageUrl = "~/images/FileUpload/ms_word_2_32.png";
                else if (item.GetDataKeyValue("File_Type").ToString().Contains("pdf"))
                    btnselect.ImageUrl = "~/images/FileUpload/pdf_icon_32_pdf.gif";

                else if (item.GetDataKeyValue("File_Type").ToString().Contains("txt"))
                    btnselect.ImageUrl = "~/images/FileUpload/notepad.jpg";
                else if (item.GetDataKeyValue("File_Type").ToString().Contains("xls"))
                    btnselect.ImageUrl = "~/images/FileUpload/Excel.png";

                else
                    btnselect.ImageUrl = "~/images/FileUpload/OneNote.png";

            }
        }

        protected void radgvFiles_ItemCommand(object source, GridCommandEventArgs e)
        {
          
            if (e.CommandName == "Select")
            {
                GridDataItem item = (GridDataItem)e.Item;
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