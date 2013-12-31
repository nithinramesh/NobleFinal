using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using NobleEntity;
using NobleBLL;
namespace NewsLetter
{
    public partial class CustomizeTemplate : System.Web.UI.Page
    {
        private int TemplateID;
        NewsLetterController objNewsLetterController = new NewsLetterController();
        protected void Page_Load(object sender, EventArgs e)
        {
            TemplateID = Convert.ToInt32(Request.QueryString["TempID"].ToString());
            if (!IsPostBack)
            {
                //((Label)Master.FindControl("lblPageHeading")).Text = " ";
                ((Label)Master.FindControl("lblFirstHeader")).Text = "Customize";
                ((Label)Master.FindControl("lblSecondHeader")).Text = "NewsLetter";
                if (Request.QueryString["TempID"] != null)
                {

                    GetTemplateDetails(TemplateID);

                }
            }



        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            ViewState["EmailBody"] = EdtBody.Content.Trim();
        }
        private void GetTemplateDetails(int TemplateID)
        {
            NewsLetterEntity objNewsLetterEntity = new NewsLetterEntity();
            objNewsLetterEntity = objNewsLetterController.GetNewsLetterTemplateById(TemplateID);
            txtTemplateName.Text = objNewsLetterEntity.TemplateName;
            txtSubject.Text = objNewsLetterEntity.Subject;
            //EdtBody.Text = objNewsLetterEntity.Body;
            EdtBody.Content = objNewsLetterEntity.Body;
            txtDisplayName.Text = objNewsLetterEntity.DisplayName;
            txtFromAddress.Text = objNewsLetterEntity.FromAddress;
            txtReplyAddress.Text = objNewsLetterEntity.ReplyAddress;

            ViewState["EmailBody"] = EdtBody.Content.Trim();

        }
        protected void btnSaveAndProceed_Click(object sender, EventArgs e)
        {
            UpdateTemplate();
            if (ViewState["EmailBody"] == null)
                SaveasHTML();
            else if (ViewState["EmailBody"].ToString() != EdtBody.Content.Trim())
                SaveasHTML();
               
            Response.Redirect(string.Concat("SendMail.aspx?TempID=", TemplateID));
        }
        private void UpdateTemplate()
        {
            NewsLetterEntity objNewsLetterEntity = new NewsLetterEntity();
            objNewsLetterEntity.TemplateID = TemplateID;
            objNewsLetterEntity.TemplateName = txtTemplateName.Text;
            objNewsLetterEntity.Body = EdtBody.Content;
            objNewsLetterEntity.Subject = txtSubject.Text;
            objNewsLetterEntity.FromAddress = txtFromAddress.Text;
            objNewsLetterEntity.DisplayName = txtDisplayName.Text;
            objNewsLetterEntity.ReplyAddress = txtReplyAddress.Text;
            objNewsLetterController.UpdateNewsLetterTemplateById(objNewsLetterEntity);
        }
        private void SaveasHTML()
        {

            StreamWriter sw;
            string HTMLpath = "HTMLTemplates/" + txtTemplateName.Text.Trim() + ".html";
            string HTMLfullPath = Server.MapPath("HTMLTemplates/" + txtTemplateName.Text.Trim() + ".html");
            string strHTML = EdtBody.Content.Trim();
            sw = File.CreateText(HTMLfullPath);
            sw.WriteLine(strHTML);
            sw.Close();

            string URL = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Path);


            string pageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string TemplateURL = string.Concat(URL.Replace(pageName, string.Empty), HTMLpath);
            Bitmap bmp = DrawThumpController.GetWebSiteThumbnail(TemplateURL, 800, 600, 0, 0);
            bmp.Save(Server.MapPath(string.Concat("ThumpImages/", txtTemplateName.Text.Trim(), ".bmp")));

            FileInfo objfile = new FileInfo(HTMLfullPath);
            if (objfile.Exists)
            {
                objfile.Delete();
            }


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            UpdateTemplate();
            SaveasHTML();
            Response.Redirect(string.Concat("TemplateList.aspx"));
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("TemplateList.aspx");
        }
    }
}