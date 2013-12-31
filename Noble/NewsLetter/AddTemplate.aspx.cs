using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net;
using System.IO;
using NobleEntity;
using NobleBLL;

namespace NewsLetter
{
    public partial class AddTemplate : System.Web.UI.Page
    {
        NewsLetterController objNewsLetterController = new NewsLetterController();
        protected void Page_Load(object sender, EventArgs e)
        {
            //((Label)Master.FindControl("lblPageHeading")).Text = " ";
            ((Label)Master.FindControl("lblFirstHeader")).Text = "Create";
            ((Label)Master.FindControl("lblSecondHeader")).Text = "Template";
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            NewsLetterEntity objNewsLetterEntity = new NewsLetterEntity();
            objNewsLetterEntity.TemplateName = txtTemplateName.Text;
            objNewsLetterEntity.Body = EdtBody.Content;
            objNewsLetterEntity.Subject = txtSubject.Text;
            objNewsLetterEntity.FromAddress = txtFromAddress.Text;
            objNewsLetterEntity.DisplayName = txtDisplayName.Text;
            objNewsLetterEntity.ReplyAddress = txtReplyAddress.Text;
           objNewsLetterController.InsertNewsLetterTemplates(objNewsLetterEntity);

           SaveasHTML();

           Response.Redirect("TemplateList.aspx");


        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("TemplateList.aspx");
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
    }
}