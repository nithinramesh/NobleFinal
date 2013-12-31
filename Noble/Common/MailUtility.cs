using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Web.Configuration;
using System.Configuration;
using System.Net.Configuration;
using System.Runtime.Remoting.Messaging;
using NobleEntity;
using NobleBLL;
using System.Threading;

namespace Noble.Common
{
    public class MailUtility
    {
        NewsLetterController objNewsLetterController = new NewsLetterController();
        List<MemberEntity> mulstMembers = new List<MemberEntity>();
        MailEntity objMailEntity = new MailEntity();
        private  string SMTPhost;
        private int SMTPport;
        private string SMTPuser;
        private string SMTPpassword;
        private int SuccessCount;
        private int FailedCount;
        private DateTime Startdate;
        private int TemplateID;
        private bool _EnableLog;

        public string OrgarnizeEmailAsync(List<MemberEntity> lstMembers, MailEntity mailEntity, bool enableLog)
        {
            //SetSMTPServerSettings();
            mulstMembers = lstMembers;
            objMailEntity = mailEntity;
            _EnableLog = enableLog;
            OrganizeEmailDelegate dc = new OrganizeEmailDelegate(this.OrganizeMail);
            AsyncCallback cb = new AsyncCallback(this.GetResultsOnCallback);
            IAsyncResult ar = dc.BeginInvoke(cb, null);
            return "ok";
        }
        public delegate string OrganizeEmailDelegate();

        public void GetResultsOnCallback(IAsyncResult ar)
        {
            OrganizeEmailDelegate del = (OrganizeEmailDelegate)((AsyncResult)ar).AsyncDelegate;
            try
            {
                string result;
                result = del.EndInvoke(ar);
            }
            catch (Exception ex)
            {

            }
        }
        public string OrganizeMail()
        {
            TemplateID = objMailEntity.ID;
            Startdate = System.DateTime.Now;
            for (int k = 0; k < mulstMembers.Count; k++)
            {
                if((k>0)&&(k%50==0))
                Thread.Sleep(120000);
                bool MailStatus = SMTPSendMail(mulstMembers[k].Email, objMailEntity.FromAddress, objMailEntity.DisplayName, string.Empty, objMailEntity.Subject, objMailEntity.Body, string.Empty,objMailEntity.ReplyAddress);
                if (_EnableLog)
                {
                    if (MailStatus)
                        SuccessCount++;
                    else
                        FailedCount++;
                    MailStatusEntity objMembMailStatus = new MailStatusEntity();
                    objMembMailStatus.TemplateID = objMailEntity.ID;
                    objMembMailStatus.MemberId = Convert.ToInt32(mulstMembers[k].ID.ToString());
                    objMembMailStatus.Status = MailStatus;
                    objMembMailStatus.RecEmail = mulstMembers[k].Email;
                    objNewsLetterController.InsertMemberMailStatus(objMembMailStatus);
                }
            }
            if(_EnableLog)
                InsertMailStatus();
            return "Success";

        }
        public bool SMTPSendMail(string toList, string from, string DisplayName, string ccList, string subject, string body, string bccList,string replyAddress)
        {
            MailAddress fromaddress = new MailAddress(from, DisplayName);
            MailAddress replyaddress = new MailAddress(replyAddress, replyAddress);
            MailMessage message = new MailMessage();

            
            SmtpClient smtpClient = new SmtpClient();
         
            string msg = string.Empty;
            bool IsMailed = true;
            try
            {
                message.From = fromaddress;
                message.ReplyTo = replyaddress;
                message.To.Add(toList);
                if (!string.IsNullOrEmpty(ccList))
                    message.CC.Add(ccList);
                if (!string.IsNullOrEmpty(bccList))
                    message.Bcc.Add(bccList);
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = body;
                //smtpClient.Host = SMTPhost;   // We use gmail as our smtp client
                //smtpClient.Port = SMTPport;
                smtpClient.EnableSsl = true;
                //smtpClient.UseDefaultCredentials = true;
                //smtpClient.Credentials = new System.Net.NetworkCredential(SMTPuser, SMTPpassword);
                smtpClient.Send(message);
                msg = "Successful<BR>";
            }
            catch (Exception ex)
            {
                IsMailed = false;
                msg = ex.Message;

            }


            return IsMailed;
        }
       
   
        private void SetSMTPServerSettings()
        {
            Configuration c = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            MailSettingsSectionGroup settings = (MailSettingsSectionGroup)c.GetSectionGroup("system.net/mailSettings");

            if (settings != null)
            {
                SMTPport = settings.Smtp.Network.Port;
                SMTPhost = settings.Smtp.Network.Host;
                SMTPuser = settings.Smtp.Network.UserName;
                SMTPpassword = settings.Smtp.Network.Password;
            }

        }
        private void InsertMailStatus()
        {
            MailStatusEntity objMailStatusEntity = new MailStatusEntity();
            objMailStatusEntity.TemplateID = TemplateID;
            objMailStatusEntity.SuccessCount = SuccessCount;
            objMailStatusEntity.FailedCount = FailedCount;
            objMailStatusEntity.StartDate = Startdate;
            objMailStatusEntity.EndDate = Convert.ToDateTime(DateTime.Now);
            objNewsLetterController.InsertMailStatus(objMailStatusEntity);
        }
    }
}