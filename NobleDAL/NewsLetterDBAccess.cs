using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using NobleEntity;
namespace NobleDAL
{
    public class NewsLetterDBAccess
    {
        public bool InsertNewsLetterTemplates(NewsLetterEntity objNewLetterInfo)
        {
            SqlParameter[] parameters = new SqlParameter[]
		    {      
                new SqlParameter("@Template_Name", objNewLetterInfo.TemplateName),
                new SqlParameter("@Email_Body", objNewLetterInfo.Body),
			    new SqlParameter("@Email_Subject", objNewLetterInfo.Subject),
			    new SqlParameter("@From_Address", objNewLetterInfo.FromAddress),
			    new SqlParameter("@Display_Name", objNewLetterInfo.DisplayName),
			    new SqlParameter("@ReplyTo_Address", objNewLetterInfo.ReplyAddress)
		    };

            return SqlDBHelper.ExecuteNonQuery("USP_NLTR_InsertTemplate", CommandType.StoredProcedure, parameters);

        }
        public List<NewsLetterEntity> GetNewsLetterTemplates()
        {
            List<NewsLetterEntity> listTemplates = null;

            //Lets get the list of all employees in a datataable
            using (DataTable table = SqlDBHelper.ExecuteSelectCommand("USP_NLTR_GetTemplates", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    listTemplates = new List<NewsLetterEntity>();
                    foreach (DataRow row in table.Rows)
                    {
                        NewsLetterEntity nltrObj = new NewsLetterEntity();
                        nltrObj.TemplateID = Convert.ToInt32(row["Template_ID"]);
                        nltrObj.TemplateName = Convert.ToString(row["Template_Name"]);
                        nltrObj.Body = Convert.ToString(row["Email_Body"]);


                        listTemplates.Add(nltrObj);
                    }
                }
            }

            return listTemplates;

        }
        public NewsLetterEntity GetNewsLetterTemplateById(int TemplateID)
        {
            SqlParameter[] parameters = new SqlParameter[]
		    {      
                new SqlParameter("@Template_ID", TemplateID)
               
		    };

            NewsLetterEntity objNewsLetterEntity = null;
            using (DataTable dtTemplates = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_NLTR_GetTemplateByID", CommandType.StoredProcedure, parameters))
            {

                if (dtTemplates.Rows.Count > 0)
                {
                    objNewsLetterEntity = new NewsLetterEntity();
                    objNewsLetterEntity.TemplateID = Convert.ToInt32(dtTemplates.Rows[0]["Template_ID"].ToString());
                    objNewsLetterEntity.TemplateName = dtTemplates.Rows[0]["Template_Name"].ToString();
                    objNewsLetterEntity.Body = dtTemplates.Rows[0]["Email_Body"].ToString();
                    objNewsLetterEntity.Subject = dtTemplates.Rows[0]["Email_Subject"].ToString();
                    objNewsLetterEntity.FromAddress = dtTemplates.Rows[0]["From_Address"].ToString();
                    objNewsLetterEntity.DisplayName = dtTemplates.Rows[0]["Display_Name"].ToString();
                    objNewsLetterEntity.ReplyAddress = dtTemplates.Rows[0]["ReplyTo_Address"].ToString();
                }
            }
            return objNewsLetterEntity;

        }
        public bool UpdateNewsLetterTemplateById(NewsLetterEntity objNewsLetterEntity)
        {

            SqlParameter[] parameters = new SqlParameter[]
		    {
                new SqlParameter("@Template_ID", objNewsLetterEntity.TemplateID),
			    new SqlParameter("@Template_Name", objNewsLetterEntity.TemplateName),
                new SqlParameter("@Email_Body", objNewsLetterEntity.Body),
			    new SqlParameter("@Email_Subject", objNewsLetterEntity.Subject),
			    new SqlParameter("@From_Address", objNewsLetterEntity.FromAddress),
			    new SqlParameter("@Display_Name", objNewsLetterEntity.DisplayName),
                new SqlParameter("@ReplyTo_Address", objNewsLetterEntity.ReplyAddress)
		    };

            return SqlDBHelper.ExecuteNonQuery("USP_NLTR_UpdateTemplateByID", CommandType.StoredProcedure, parameters);


        }
        public bool DeleteNewsLetterTemplateById(NewsLetterEntity objNewsLetterEntity)
        {

            SqlParameter[] parameters = new SqlParameter[]
		    {
                new SqlParameter("@Template_ID", objNewsLetterEntity.TemplateID)
			  
		    };

            return SqlDBHelper.ExecuteNonQuery("USP_NLTR_Delete_Templates", CommandType.StoredProcedure, parameters);


        }
        public List<MemberEntity> GetMemberEmails(int TemplateID)
        {

            SqlParameter[] parameters = new SqlParameter[]
		    {      
                new SqlParameter("@TemplateID", TemplateID)
               
		    };

            List<MemberEntity> listMembers = null;

            //Lets get the list of all employees in a datataable
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_NLTR_GetMembers", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count > 0)
                {
                    listMembers = new List<MemberEntity>();
                    foreach (DataRow row in table.Rows)
                    {
                        MemberEntity mbrObj = new MemberEntity();
                        mbrObj.ID = Convert.ToInt32(row["MemberId"]);
                        mbrObj.Firstname = Convert.ToString(row["First_Name"]);
                        mbrObj.Lastname = Convert.ToString(row["Last_Name"]);
                        mbrObj.Email = Convert.ToString(row["Email"]);
                        listMembers.Add(mbrObj);
                    }
                }
            }

            return listMembers;



        }
        public bool InsertMailStatus(MailStatusEntity objMailStatusEntity)
        {

            SqlParameter[] parameters = new SqlParameter[]
		    {
                new SqlParameter("@Template_ID", objMailStatusEntity.TemplateID),
			    new SqlParameter("@Success", objMailStatusEntity.SuccessCount),
                new SqlParameter("@Failed", objMailStatusEntity.FailedCount),
			    new SqlParameter("@StartDate",SqlDbType.DateTime)
                {
                    Value = objMailStatusEntity.StartDate
                },
                  new SqlParameter("@EndDate",SqlDbType.DateTime)
                {
                    Value = objMailStatusEntity.EndDate
                }
		    };

            return SqlDBHelper.ExecuteNonQuery("USP_NLTR_InsertMailStatus", CommandType.StoredProcedure, parameters);
        }

        public bool InsertMemberMailStatus(MailStatusEntity objMailStatusEntity)
        {

            SqlParameter[] parameters = new SqlParameter[]
		    { 
                new SqlParameter("@Template_ID", objMailStatusEntity.TemplateID),
			    new SqlParameter("@RecEmail", objMailStatusEntity.RecEmail),
                new SqlParameter("@Status", objMailStatusEntity.Status)
			    
		    };

            return SqlDBHelper.ExecuteNonQuery("USP_NLTR_InsertMemberMailStatus", CommandType.StoredProcedure, parameters);
        }
        public List<MailStatusEntity> GetMailStatusByTemplateID(MailStatusEntity objMailStatusEntity)
        {
            List<MailStatusEntity> listMailStatus = null;
            SqlParameter[] parameters = new SqlParameter[]
		    { 
                new SqlParameter("@Template_ID", objMailStatusEntity.TemplateID)			  
			    
		    };

            //Lets get the list of all employees in a datataable
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_NLTR_GetMailStatusByTemplateId", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count > 0)
                {
                    listMailStatus = new List<MailStatusEntity>();
                    foreach (DataRow row in table.Rows)
                    {
                        MailStatusEntity msObj = new MailStatusEntity();
                        msObj.TemplateName = Convert.ToString(row["Template_Name"]);
                        msObj.SuccessCount = Convert.ToInt32(row["Success"]);
                        msObj.FailedCount = Convert.ToInt32(row["Failed"]);
                        msObj.StartDate = Convert.ToDateTime(row["StartDate"]);
                        msObj.EndDate = Convert.ToDateTime(row["EndDate"]);
                        listMailStatus.Add(msObj);

                    }
                }
            }

            return listMailStatus;



        }
        public List<MailStatusEntity> GetMailStatusTemplates()
        {
            List<MailStatusEntity> listMailStatus = null;

            //Lets get the list of all employees in a datataable
            using (DataTable table = SqlDBHelper.ExecuteSelectCommand("USP_NLTR_GetMailStatusTemplates", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    listMailStatus = new List<MailStatusEntity>();
                    foreach (DataRow row in table.Rows)
                    {
                        MailStatusEntity msObj = new MailStatusEntity();
                        msObj.TemplateName = Convert.ToString(row["Template_Name"]);
                        msObj.SuccessCount = Convert.ToInt32(row["Success"]);
                        msObj.FailedCount = Convert.ToInt32(row["Failed"]);
                        msObj.StartDate = Convert.ToDateTime(row["StartDate"]);
                        msObj.EndDate = Convert.ToDateTime(row["EndDate"]);
                        listMailStatus.Add(msObj);

                    }
                }
            }

            return listMailStatus;



        }
        public List<string> GetEmailsByWebForm(int NodeID, int TemplateId)
        {
            List<string> lstEmails = null;

            SqlParameter[] parameters = new SqlParameter[]
		    { 
                new SqlParameter("@NodeID", NodeID),		  
			    new SqlParameter("@TemplateID", TemplateId)
		    };

            //Lets get the list of all employees in a datataable
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_NLTR_GetEmailsByWebForm", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count > 0)
                {
                    lstEmails = new List<string>();
                    foreach (DataRow row in table.Rows)
                    {
                        lstEmails.Add(Convert.ToString(row["ComponentData"]));

                    }
                }
            }

            return lstEmails;


        }
        public List<EmailEntity> GetEmailCategories()
        {
            List<EmailEntity> listEmailInfo = null;

            //Lets get the list of all employees in a datataable
            using (DataTable table = SqlDBHelper.ExecuteSelectCommand("USP_NLTR_GetEmailCategories", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    listEmailInfo = new List<EmailEntity>();
                    foreach (DataRow row in table.Rows)
                    {
                        EmailEntity infoObj = new EmailEntity();
                        infoObj.CategoryId = Convert.ToInt32(row["CategoryId"]);
                        infoObj.CategoryName = Convert.ToString(row["CategoryName"]);
                        infoObj.ContactsCount = Convert.ToInt32(row["Contacts"]);
                        listEmailInfo.Add(infoObj);
                    }
                }
            }

            return listEmailInfo;

        }

        public bool CreateEmailCategory(EmailEntity objEmailinfo)
        {

            SqlParameter[] parameters = new SqlParameter[]
		    {
                new SqlParameter("@CategoryName", objEmailinfo.CategoryName)                
		    };

            return SqlDBHelper.ExecuteNonQuery("USP_NLTR_CreateEmailCategory", CommandType.StoredProcedure, parameters);


        }
        public bool DeleteEmailCategory(EmailEntity objEmailinfo)
        {

            SqlParameter[] parameters = new SqlParameter[]
		    {
                new SqlParameter("@CategoryID", objEmailinfo.CategoryId)                
		    };

            return SqlDBHelper.ExecuteNonQuery("USP_NLTR_DeleteEmailCategory", CommandType.StoredProcedure, parameters);


        }
        public List<EmailEntity> GetContactsByCategory(EmailEntity objEmailinfo)
        {
            List<EmailEntity> listEmailInfo = null;
            SqlParameter[] parameters = new SqlParameter[]
		    {
                new SqlParameter("@CategoryID",objEmailinfo.CategoryId )               
		    };
            //Lets get the list of all employees in a datataable
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_NLTR_GetContactsByCategory", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count > 0)
                {
                    listEmailInfo = new List<EmailEntity>();
                    foreach (DataRow row in table.Rows)
                    {
                        EmailEntity infoObj = new EmailEntity();
                        infoObj.EmailAddress = row["EmailAddress"].ToString();
                        infoObj.FirstName = row["FirstName"].ToString();
                        infoObj.LastName = row["LastName"].ToString();
                        infoObj.EmailId = Convert.ToInt32(row["EmailId"]);
                        infoObj.CreatedAdmin = row["CreatedBy"].ToString();
                        infoObj.Created_on = Convert.ToDateTime(row["CreatedOn"].ToString());
                        listEmailInfo.Add(infoObj);
                    }
                }
            }

            return listEmailInfo;

        }
        public bool DeleteEmailcontact(EmailEntity objEmailinfo)
        {

            SqlParameter[] parameters = new SqlParameter[]
		    {
                new SqlParameter("@EmailId", objEmailinfo.EmailId)                
		    };

            return SqlDBHelper.ExecuteNonQuery("USP_NLTR_DeleteEmailcontact", CommandType.StoredProcedure, parameters);


        }
        public bool UpdateEmailcontact(EmailEntity objEmailinfo)
        {
            SqlParameter[] parameters = new SqlParameter[]
		    {
                new SqlParameter("@EmailId", objEmailinfo.EmailId),
			    new SqlParameter("@EmailAddress", objEmailinfo.EmailAddress),   
                new SqlParameter("@FirstName", objEmailinfo.FirstName),
			    new SqlParameter("@LastName", objEmailinfo.LastName),
                new SqlParameter("@out_message", SqlDbType.Bit)
                { 
                    Direction = ParameterDirection.Output 
                }
		    };


            return Convert.ToBoolean(SqlDBHelper.ExecuteNonQuery("USP_NLTR_UpdateEmailcontact", CommandType.StoredProcedure, parameters));


        }
        public bool InsertEmailContact(EmailEntity objEmailinfo)
        {
            SqlParameter[] parameters = new SqlParameter[]
		    {
                new SqlParameter("@CategoryId", objEmailinfo.CategoryId),
			    new SqlParameter("@EmailAddress", objEmailinfo.EmailAddress),   
                new SqlParameter("@FirstName", objEmailinfo.FirstName),
			    new SqlParameter("@LastName", objEmailinfo.LastName) ,
                new SqlParameter("@CreatedOn", objEmailinfo.Created_on),
                new SqlParameter("@CreatedBy", objEmailinfo.Created_by) , 
		    new SqlParameter("@out_message", SqlDbType.Bit)
                { 
                    Direction = ParameterDirection.Output 
                }
		    };


            return Convert.ToBoolean(SqlDBHelper.ExecuteNonQuerywithOutput("USP_NLTR_InsertEmailContact", CommandType.StoredProcedure, parameters));




        }
        public EmailEntity GetContactsById(EmailEntity objEmailinfo)
        {
            EmailEntity infoObj = new EmailEntity();
            SqlParameter[] parameters = new SqlParameter[]
		    {
                new SqlParameter("@EmailId",objEmailinfo.EmailId )               
		    };
            //Lets get the list of all employees in a datataable
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_NLTR_GetContactsById", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count > 0)
                {

                    infoObj.EmailAddress = table.Rows[0]["EmailAddress"].ToString();
                    infoObj.FirstName = table.Rows[0]["FirstName"].ToString();
                    infoObj.LastName = table.Rows[0]["LastName"].ToString();


                }
            }

            return infoObj;

        }
        public List<MemberEntity> GetEmailAddressesByCategory(string CategoryName, int TemplateID)
        {
            SqlParameter[] parameters = new SqlParameter[]
		    {      
                new SqlParameter("@CategoryName", CategoryName),
                new SqlParameter("@TemplateID", TemplateID)
               
		    };

            List<MemberEntity> listMembers = null;

            //Lets get the list of all employees in a datataable
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_NLTR_GetEmailAddressesByCategory", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count > 0)
                {
                    listMembers = new List<MemberEntity>();
                    foreach (DataRow row in table.Rows)
                    {
                        MemberEntity mbrObj = new MemberEntity();
                        mbrObj.ID = Convert.ToInt32(row["MemberId"]);
                        mbrObj.Email = Convert.ToString(row["EmailAddress"]);
                        listMembers.Add(mbrObj);
                    }
                }
            }

            return listMembers;

        }
        public List<EmailEntity> GetEmailCategoriesOnly()
        {
            List<EmailEntity> listEmailInfo = null;

            //Lets get the list of all employees in a datataable
            using (DataTable table = SqlDBHelper.ExecuteSelectCommand("USP_NLTR_GetEmailCategoriesOnly", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    listEmailInfo = new List<EmailEntity>();
                    foreach (DataRow row in table.Rows)
                    {
                        EmailEntity infoObj = new EmailEntity();
                        infoObj.CategoryId = Convert.ToInt32(row["CategoryId"]);
                        infoObj.CategoryName = Convert.ToString(row["CategoryName"]);
                        infoObj.ContactsCount = Convert.ToInt32(row["Contacts"]);
                        listEmailInfo.Add(infoObj);
                    }
                }
            }

            return listEmailInfo;

        }



    }
}
