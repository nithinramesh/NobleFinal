using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NobleBLL;
using NobleEntity;
using System.IO;
using System.Configuration;
using Telerik.Web.UI;

namespace Noble
{
    public partial class LandingPage : System.Web.UI.Page
    {
        MemberController objUC = null;
        NotesController objNC = null;
        private int MemberID;


        FileDetailsController objFileDetailsController = new FileDetailsController();
        string UploadFolderName = ConfigurationSettings.AppSettings["UploadFolderName"];
        protected void Page_Load(object sender, EventArgs e)
        {
            UploadFolderName = string.Concat(Server.MapPath(@"FileUpload\UploadedUserFiles"), @"\");
            if (!Page.IsPostBack)
            {

              
                if (Session["SelectedMember"] != null && !string.IsNullOrEmpty(Session["SelectedMember"].ToString()))
                {
                    MemberID = Convert.ToInt32(Session["SelectedMember"].ToString().Split(';')[0]);
                    //pnlSubmissionDetails.Visible = false;
                    //pnlMemberDetails.Visible = true;
                    //((Label)Master.FindControl("lblPageHeading")).Text = "Personal Details";

                }
                //else if (Session["selected_Submissions"] != null && !string.IsNullOrEmpty(Session["selected_Submissions"].ToString()))
                //{
                //    pnlSubmissionDetails.Visible = true;
                //    //pnlMemberDetails.Visible = false;
                //    ((Label)Master.FindControl("lblPageHeading")).Text = "Submission Information";

                //}
                //else
                //{
                //    ((Label)Master.FindControl("lblPageHeading")).Text = string.Empty;
                //    pnlSubmissionDetails.Visible = false;
                //    pnlMemberDetails.Visible = false;
                //}


                GetMemberDetails(MemberID);
                BindNotes(MemberID);
                FillFileDetails(MemberID);
                //FillSubmissions();
            }
        }
        private void GetMemberDetails(int MemberID)
        {
            objUC = new MemberController();
            MemberEntity objEntity = null;

            try
            {
                objEntity = objUC.GetMemberDetails(MemberID);
                if (objEntity != null)
                {

                    lblTitle.Text = objEntity.Title;

                    lblFirstName.Text = objEntity.First_name.Trim();
                    lblMiddleName.Text = objEntity.Middle_name.Trim();
                    lblLastName.Text = objEntity.Last_name.Trim();
                    lblEmail.Text = objEntity.Email.Trim();
                    lblPhone.Text = objEntity.Phone.Trim();

                    lblCountry.Text = objEntity.CountryCode;

                    lblExperience.Text = objEntity.Experience;

                    lblGender.Text = objEntity.Gender;

                    lblJobCategory.Text = objEntity.JobCatDesc.Trim().Replace("|", "<br>");
                    lblAddressLine1.Text = objEntity.Addr1.Trim();
                    lblAddressLine2.Text = objEntity.Addr2.Trim();
                    lblCity.Text = objEntity.City.Trim();
                    lblHomePhone.Text = objEntity.HomePhone.Trim();
                    lblJobTitle.Text = objEntity.JobTitle.Trim();
                    lblOther.Text = objEntity.Other.Trim();
                    lblPosition.Text = objEntity.Position.Trim();
                    lblPostalCode.Text = objEntity.PostalCode.Trim();
                    lblProvince.Text = objEntity.Province.Trim();
                    lblWorkPhone.Text = objEntity.WorkPhone.Trim();
                    
                }
            }
            finally
            {
                objEntity = null;
                objUC = null;
            }
        }
        private void BindNotes(int MemberID)
        {
            objNC = new NotesController();

            try
            {
                gvNotes.DataSource = objNC.GetMemberNotesList(MemberID);
                gvNotes.DataBind();

            }
            finally
            {
                objNC = null;
            }
        }
        private void FillFileDetails(int MemberId)
        {



            FileDetailsEntity objFileDetailsEntity = new FileDetailsEntity();
            objFileDetailsEntity.Member_ID = MemberId;
            List<FileDetailsEntity> lstFileDetails = objFileDetailsController.GetFileDetails(objFileDetailsEntity);
            radgvFiles.DataSource = lstFileDetails;
            radgvFiles.DataBind();


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
            FillFileDetails(MemberID);

        }
        protected void gvNotes_ItemCommand(object source, GridCommandEventArgs e)
        {
            BindNotes(MemberID);
        }
        //private void FillSubmissions()
        //{
        //    if (Session["selected_Submissions"] != null && !string.IsNullOrEmpty(Session["selected_Submissions"].ToString()))
        //    {
        //        int SubmissionID = Convert.ToInt32(Session["selected_Submissions"].ToString().Split(';')[0]);
        //        MemberPopupController objController = new MemberPopupController();
        //        List<SumbissionsEntity> lstSubmissions = objController.GetSubmissionsById(SubmissionID);
        //        lblForm.Text = lstSubmissions[0].NodeTitle;
        //        lblSubmittedUser.Text = lstSubmissions[0].UserName;
        //        lblSubmittedOn.Text = lstSubmissions[0].SubmittedOn.ToString();
        //        RepSubmissions.DataSource = lstSubmissions;
        //        RepSubmissions.DataBind();
        //    }
        //}




    }
}