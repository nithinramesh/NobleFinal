using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NobleDAL;
using NobleEntity;

namespace NobleBLL
{
    public class NewsLetterController
    {
        NewsLetterDBAccess ntlrAccessObj = null;

        public NewsLetterController()
        {
            ntlrAccessObj = new NewsLetterDBAccess();
        }



        public void InsertNewsLetterTemplates(NewsLetterEntity objNewsLetterEntity)
        {

            ntlrAccessObj.InsertNewsLetterTemplates(objNewsLetterEntity);
        }
        public List<NewsLetterEntity> GetNewsLetterTemplates()
        {
            return ntlrAccessObj.GetNewsLetterTemplates();
        }
        public NewsLetterEntity GetNewsLetterTemplateById(int TemplateID)
        {
            return ntlrAccessObj.GetNewsLetterTemplateById(TemplateID);
        }
        public void UpdateNewsLetterTemplateById(NewsLetterEntity objNewsLetterEntity)
        {
            ntlrAccessObj.UpdateNewsLetterTemplateById(objNewsLetterEntity);
        }
        public List<MemberEntity> GetMemberEmails(int TemplateID)
        {
            return ntlrAccessObj.GetMemberEmails(TemplateID);
        }
        public void InsertMailStatus(MailStatusEntity objMailStatusEntity)
        {
            ntlrAccessObj.InsertMailStatus(objMailStatusEntity);
        }
        public bool DeleteNewsLetterTemplateById(NewsLetterEntity objNewsLetterEntity)
        {
            return ntlrAccessObj.DeleteNewsLetterTemplateById(objNewsLetterEntity);
        }
        public bool InsertMemberMailStatus(MailStatusEntity objMailStatusEntity)
        {
            return ntlrAccessObj.InsertMemberMailStatus(objMailStatusEntity);
        }
        public List<MailStatusEntity> GetMailStatusByTemplateID(MailStatusEntity objMailStatusEntity)
        {
            return ntlrAccessObj.GetMailStatusByTemplateID(objMailStatusEntity);
        }
        public List<MailStatusEntity> GetMailStatusTemplates()
        {
            return ntlrAccessObj.GetMailStatusTemplates();
        }
        public List<string> GetEmailsByWebForm(int NodeID, int TemplateID)
        {

            return ntlrAccessObj.GetEmailsByWebForm(NodeID, TemplateID);
        }
        public List<EmailEntity> GetEmailCategories()
        {
            return ntlrAccessObj.GetEmailCategories();
        }

        public bool CreateEmailCategory(EmailEntity objEmailinfo)
        {
            return ntlrAccessObj.CreateEmailCategory(objEmailinfo);
        }
        public bool DeleteEmailCategory(EmailEntity objEmailinfo)
        {
            return ntlrAccessObj.DeleteEmailCategory(objEmailinfo);
        }
        public List<EmailEntity> GetContactsByCategory(EmailEntity objEmailinfo)
        {
            return ntlrAccessObj.GetContactsByCategory(objEmailinfo);
        }
        public bool DeleteEmailcontact(EmailEntity objEmailinfo)
        {
            return ntlrAccessObj.DeleteEmailcontact(objEmailinfo);
        }
        public bool UpdateEmailcontact(EmailEntity objEmailinfo)
        {
            return ntlrAccessObj.UpdateEmailcontact(objEmailinfo);
        }
        public EmailEntity GetContactsById(EmailEntity objEmailinfo)
        {
            return ntlrAccessObj.GetContactsById(objEmailinfo);
        }
        public bool InsertEmailContact(EmailEntity objEmailinfo)
        {
            return ntlrAccessObj.InsertEmailContact(objEmailinfo);
        }
        public List<MemberEntity> GetEmailAddressesByCategory(string CategoryName, int TemplateID)
        {
            return ntlrAccessObj.GetEmailAddressesByCategory(CategoryName, TemplateID);
        }
        public List<EmailEntity> GetEmailCategoriesOnly()
        {
            return ntlrAccessObj.GetEmailCategoriesOnly();
        }
    }
}
