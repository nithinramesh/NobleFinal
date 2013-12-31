using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using NobleEntity;
using NobleBLL;

namespace NewsLetter
{


    public partial class TemplateList : System.Web.UI.Page
    {
        NewsLetterController objNewsLetterController = new NewsLetterController();
        private static int CurrentPage;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CurrentPage = 0;
                BindTemplates();
                //((Label)Master.FindControl("lblPageHeading")).Text = " ";
                ((Label)Master.FindControl("lblFirstHeader")).Text = "Manage";
                ((Label)Master.FindControl("lblSecondHeader")).Text = "E-Letter";
            }
        }
        private void BindTemplates()
        {
            PagedDataSource objPage = new PagedDataSource();
            objPage.DataSource = objNewsLetterController.GetNewsLetterTemplates();
            objPage.AllowPaging = true;
            objPage.PageSize = 6;
            objPage.CurrentPageIndex = CurrentPage;
            lbtnNext.Enabled = !objPage.IsLastPage;
            lbtnPrev.Enabled = !objPage.IsFirstPage;
           
            if (objPage.Count > 0)
            {
                dlTemplates.DataSource = objPage;
                dlTemplates.DataBind();
            }
        }

        protected void dlTemplates_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Redirect")
            {
                string TemplateID = dlTemplates.DataKeys[e.Item.ItemIndex].ToString();
                Response.Redirect(string.Concat("CustomizeTemplate.aspx?TempID=", TemplateID));
            }
            else if (e.CommandName == "Delete")
            {
                string TemplateID = dlTemplates.DataKeys[e.Item.ItemIndex].ToString();
                NewsLetterEntity objentity=new NewsLetterEntity();
                objentity.TemplateID = Convert.ToInt32(TemplateID);
                objNewsLetterController.DeleteNewsLetterTemplateById(objentity);
                BindTemplates();
            }
        }
        protected void dlTemplates_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            ImageButton ibnTemplate = (ImageButton)e.Item.FindControl("ibnTemplate");
            string URL = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Path);
            string pageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string TemplateURL = string.Concat(URL.Replace(pageName, string.Empty), "ThumpImages/", ibnTemplate.AlternateText, ".bmp");

            ibnTemplate.ImageUrl = TemplateURL;
        }

        protected void lbtnPrev_Click(object sender, EventArgs e)
        {
            CurrentPage -= 1;
            BindTemplates();

        }
        protected void lbtnNext_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            BindTemplates();

        }

        protected void btnCreateTemplate_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddTemplate.aspx");
        }

        protected void btnReports_Click(object sender, EventArgs e)
        {
            Response.Redirect("MailStatusReport.aspx");
        }

        protected void btnContacts_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmailCategoryList.aspx");
        }

       
}
}