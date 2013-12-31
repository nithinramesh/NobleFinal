using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using NobleEntity;
using NobleBLL;
using Noble.Common;
using System.Runtime.Remoting.Messaging;
using System.Configuration;
using System.Net.Configuration;
using System.Web.Configuration;

namespace NewsLetter
{

    public partial class SendMail : System.Web.UI.Page
    {
        NewsLetterController objNewsLetterController = new NewsLetterController();
        MailUtility objMail = new MailUtility();
        NewsLetterEntity objNewsLetterEntity;
        private int batchcount = 100;
        private int SuccessCount = 0;
        private int FailedCount = 0;
        private DateTime Startdate;
        private int TemplateID;



        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["TempID"] != null)
            {
                objNewsLetterEntity = new NewsLetterEntity();
                TemplateID = Convert.ToInt32(Request.QueryString["TempID"].ToString());
                GetTemplateDetails(TemplateID);
            }

            if (!IsPostBack)
            {
                ((Label)Master.FindControl("lblPageHeading")).Text = "Send NewsLetter";

                // FillMemberEmails();
                //RbtnRecepOptions.SelectedIndex = 0;

                //divList.Visible = true;
                Session["SelectedEmailCategories"] = null;
            }
            if (Session["SelectedEmailCategories"] != null)
            {
                txtSendLists.Text = Session["SelectedEmailCategories"].ToString();
                btnCancel.Focus();
            }
            else
            {
                txtSendLists.Text = string.Empty;
            }
            ((Label)Master.FindControl("lblFirstHeader")).Text = "Send";
            ((Label)Master.FindControl("lblSecondHeader")).Text = "Email";

        }
        private void GetTemplateDetails(int TemplateID)
        {

            objNewsLetterEntity = objNewsLetterController.GetNewsLetterTemplateById(TemplateID);
            lblTemplateNameValue.Text = objNewsLetterEntity.TemplateName;
            lblSubjectValue.Text = objNewsLetterEntity.Subject;
            lblBodyValue.Text = objNewsLetterEntity.Body;
            lblDisplayNameValue.Text = objNewsLetterEntity.DisplayName;
            lblFromAddressValue.Text = objNewsLetterEntity.FromAddress;
            lblReplyAddressValue.Text = objNewsLetterEntity.ReplyAddress;



        }
        //private void FillMemberEmails()
        //{
        //    List<MemberEntity> lstMembers = new List<MemberEntity>();
        //     lstMembers = objNewsLetterController.GetMemberEmails(TemplateID);
        //     if (lstMembers !=null && lstMembers.Count > 0)
        //    {
        //        lbxAvilableMembers.DataSource = lstMembers;
        //        lbxAvilableMembers.DataTextField = "Email";
        //        lbxAvilableMembers.DataValueField = "ID";
        //        lbxAvilableMembers.DataBind();
        //    }
        //}
        //private void MoveListBoxItems(ListControl source, ListControl destination)
        //{
        //    List<ListItem> remove = new List<ListItem>();
        //    foreach (ListItem item in source.Items)
        //    {
        //        if (item.Selected == false) continue;
        //        destination.Items.Add(item);
        //        remove.Add(item);
        //    }
        //    foreach (var item in remove)
        //    {
        //        source.Items.Remove(item);
        //    }
        //}
        //protected void btnMoveRight_Click(object sender, EventArgs e)
        //{
        //    MoveListBoxItems(lbxAvilableMembers, lbxSelectedMembers);
        //}
        //protected void btnMoveleft_Click(object sender, EventArgs e)
        //{
        //    MoveListBoxItems(lbxSelectedMembers, lbxAvilableMembers);

        //}
        protected void btnSend_Click(object sender, EventArgs e)
        {
            // OrganizeMail();

            MailSend();
            //   InsertMailStatus();



        }
        private void MailSend()
        {
            MailEntity objmailEntity = new MailEntity();
            objmailEntity.ID = objNewsLetterEntity.TemplateID;
            objmailEntity.Name = objNewsLetterEntity.TemplateName;
            objmailEntity.Subject = objNewsLetterEntity.Subject;
            objmailEntity.Body = objNewsLetterEntity.Body;
            objmailEntity.FromAddress = objNewsLetterEntity.FromAddress;
            objmailEntity.DisplayName = objNewsLetterEntity.DisplayName;
            objmailEntity.ReplyAddress = objNewsLetterEntity.ReplyAddress;


            List<MemberEntity> lstMembers = new List<MemberEntity>();
            if (!string.IsNullOrEmpty(txtSendLists.Text))
            {
                string[] Lists = txtSendLists.Text.Split(';');
                foreach (string slist in Lists)
                {

                    if (objNewsLetterController.GetEmailAddressesByCategory(slist, TemplateID) != null && objNewsLetterController.GetEmailAddressesByCategory(slist, TemplateID).Count > 0)
                        lstMembers.AddRange(objNewsLetterController.GetEmailAddressesByCategory(slist, TemplateID));
                }

            }
            //if (rbtnPrimaryOptions.SelectedValue.ToLower() == "members")
            //{
            //    if (RbtnRecepOptions.SelectedValue.ToLower() == "list")
            //    {


            //        for (int k = 0; k < lbxSelectedMembers.Items.Count; k++)
            //        {

            //            MemberEntity objMemberEntity = new MemberEntity();
            //            objMemberEntity.ID = Convert.ToInt32(lbxSelectedMembers.Items[k].Value.ToString());
            //            objMemberEntity.Email = lbxSelectedMembers.Items[k].Text.ToString();
            //            lstMembers.Add(objMemberEntity);



            //        }
            //    }
            //    else
            //    {
            //        if(objNewsLetterController.GetMemberEmails(objNewsLetterEntity.TemplateID)!=null && objNewsLetterController.GetMemberEmails(objNewsLetterEntity.TemplateID).Count>0)                 
            //        lstMembers = objNewsLetterController.GetMemberEmails(objNewsLetterEntity.TemplateID);
            //    }
            //}
            //else
            //{
            //    List<string> lstEmails = objNewsLetterController.GetEmailsByWebForm(Convert.ToInt32(ddlWebForms.SelectedValue.ToString()),objNewsLetterEntity.TemplateID);

            //    for (int k = 0; k < lstEmails.Count; k++)
            //    {

            //        MemberEntity objMemberEntity = new MemberEntity();
            //        objMemberEntity.ID = k;
            //        objMemberEntity.Email = lstEmails[k].ToString();
            //        lstMembers.Add(objMemberEntity);
            //    }

            //}
            //if (txtAdditionalEmail.Text.Trim() != string.Empty)
            //{

            //    MemberEntity objme = new MemberEntity();
            //    objme.ID = 0;
            //    objme.Email = txtAdditionalEmail.Text.Trim();
            //    lstMembers.Add(objme);
            //}

            if (lstMembers.Count < 1)
            {
                lblMessage.Text = "Please add members to continue.....";
                btnSend.Focus();

            }
            else
            {
                //lstMembers = (
                //    from o in lstMembers
                //    group o by  o.Email.ToLower() into g
                //    select g.First()
                //            ).ToList();

                objMail.OrgarnizeEmailAsync(lstMembers, objmailEntity, true);
                Response.Redirect(string.Concat("MailStatusReport.aspx?TempID=", TemplateID, "&Status=1"));
            }


        }



        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("TemplateList.aspx");
        }


        //protected void rbtnPrimaryOptions_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (rbtnPrimaryOptions.SelectedIndex == 0)
        //    {

        //        pnlMembers.Visible = true;
        //        pnlSubmissions.Visible = false;
        //    }
        //    else
        //    {
        //        pnlSubmissions.Visible = true;
        //        pnlMembers.Visible = false;
        //        FillWebForms();

        //    }
        //    lblMessage.Text = string.Empty;
        //    btnSend.Focus();

        //}

        //protected void RbtnRecepOptions_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (RbtnRecepOptions.SelectedIndex == 0)
        //    {

        //        divList.Visible = true; ;
        //    }
        //    else
        //    {
        //        divList.Visible = false;


        //    }
        //    lblMessage.Text = string.Empty;
        //    btnSend.Focus();

        //}
        //private void FillWebForms()
        //{
        //    GeneralController objGeneralController = new GeneralController();
        //    ddlWebForms.DataSource = objGeneralController.GetWebForms();
        //    ddlWebForms.DataTextField = "Value";
        //    ddlWebForms.DataValueField = "Key";
        //    ddlWebForms.DataBind();
        //}


    }
}