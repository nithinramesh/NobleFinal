using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NobleEntity
{
    public class NewsLetterEntity
    {
        

        private int _TemplateID;
        private string _TemplateName;
        private string _Body;
        private string _Subject;
        private string _FromAddress;
        private string _DisplayName;
        private string _ReplyAddress;
        public int TemplateID
        {
            get { return _TemplateID; }
            set { _TemplateID = value; }
        }

        public string TemplateName
        {
            get { return _TemplateName; }
            set { _TemplateName = value; }
        }
        public string Body
        {
            get { return _Body; }
            set { _Body = value; }
        }
        public string Subject
        {
            get { return _Subject; }
            set { _Subject = value; }
        }
        public string FromAddress
        {
            get { return _FromAddress; }
            set { _FromAddress = value; }
        }
        public string DisplayName
        {
            get { return _DisplayName; }
            set { _DisplayName = value; }
        }
        public string ReplyAddress
        {
            get { return _ReplyAddress; }
            set { _ReplyAddress = value; }
        }

    }
    public class MailStatusEntity
    {
        

        private int _TemplateID;
        private int _SuccessCount;
        private int _FailedCount;
        private DateTime _StartDate;
        private DateTime _EndDate;
        private int _MemberId;
        private bool _Status;
        private string _TemplateName;
        private string _RecEmail;




        public int TemplateID
        {
            get { return _TemplateID; }
            set { _TemplateID = value; }
        }
        public string TemplateName
        {
            get { return _TemplateName; }
            set { _TemplateName = value; }
        }
        public int SuccessCount
        {
            get { return _SuccessCount; }
            set { _SuccessCount = value; }
        }
        public int FailedCount
        {
            get { return _FailedCount; }
            set { _FailedCount = value; }
        }
        public DateTime StartDate
        {
            get { return _StartDate; }
            set { _StartDate = value; }
        }
        public DateTime EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; }
        }
        public int MemberId
        {
            get { return _MemberId; }
            set { _MemberId = value; }
        }
        public bool Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        public string RecEmail
        {
            get { return _RecEmail; }
            set { _RecEmail = value; }
        }


    }
    public class EmailEntity:BaseEntity
    {
        public int CategoryId { get; set; }
        public int EmailId { get; set; }
        public string CategoryName { get; set; }
        public int ContactsCount { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CreatedAdmin {get;set; }
    }
}
