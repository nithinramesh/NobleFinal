using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NobleEntity;
using System.Data.SqlClient;
using System.Data;

namespace NobleDAL
{
    public class MemberPopupDAL
    {
        public List<MemberPopupEntity> GetAllMembers(bool IsJobCategory, string SQLquery)
        {
            string sSQLquery = string.Empty;
            //if (!IsJobCategory)
            //    sSQLquery = "   SELECT m.MemberId MemberId, m.First_Name FirstName, m.Last_Name LastName,m.Phone Phone, JobKeyWords FROM dbo.MemberInfo m  where (IsDeleted =0 or IsDeleted is null)";
            //else
            //sSQLquery = "   SELECT m.MemberId MemberId, m.First_Name FirstName, m.Last_Name LastName,m.Phone Phone, JobKeyWords FROM dbo.MemberInfo m  where (IsDeleted =0 or IsDeleted is null) and first_name <>''  ";
            sSQLquery = "   SELECT m.MemberId MemberId, m.FirstName FirstName, m.LastName LastName,m.HousePhone Phone, HouseAddress JobKeyWords FROM dbo.MemberInfo m  where (IsDeleted =0 or IsDeleted is null) and firstname <>''  ";
            sSQLquery = sSQLquery + SQLquery;
            sSQLquery = sSQLquery + "order by FirstName,LastName";
            List<MemberPopupEntity> listMembers = null;

            using (DataTable dtmembers = SqlDBHelper.ExecuteSelectCommand(sSQLquery, CommandType.Text))
            {

                if (dtmembers.Rows.Count > 0)
                {
                    listMembers = new List<MemberPopupEntity>();
                    foreach (DataRow row in dtmembers.Rows)
                    {
                        MemberPopupEntity mpopObj = new MemberPopupEntity();
                        mpopObj.Member_ID = Convert.ToInt32(row["MemberId"]);
                        mpopObj.First_name = Convert.ToString(row["FirstName"]);
                        mpopObj.Last_name = Convert.ToString(row["LastName"]);
                        //mpopObj.JobCategory = Convert.ToString(row["JobCategory"]);
                        mpopObj.Phone = Convert.ToString(row["Phone"]);
                        mpopObj.JobKeyWords = Convert.ToString(row["JobKeyWords"]);
                       // mpopObj.Country = Convert.ToString(row["CountryName"]);
                        listMembers.Add(mpopObj);
                    }
                }



            }

            int recordCount = 0;
            if (listMembers != null && listMembers.Count > 0)
                listMembers[0].RecordCount = recordCount;

            return listMembers;

        }
        public List<MemberPopupEntity> GetAllMembersJobCategory(MemberPopupEntity objMemberPopupEntity)
        {

            SqlParameter OutRecordCount = new SqlParameter("@RecordCount", objMemberPopupEntity.RecordCount)
            {
                Direction = System.Data.ParameterDirection.Output
            };

            SqlParameter[] parameters = new SqlParameter[]
		    {      
                new SqlParameter("@Page", objMemberPopupEntity.PageNumber),
                new SqlParameter("@RecsPerPage", objMemberPopupEntity.RecordsPerPage),
                new SqlParameter("@FirstName", objMemberPopupEntity.First_name),
                new SqlParameter("@LastName", objMemberPopupEntity.Last_name),
                 new SqlParameter("@Phone", objMemberPopupEntity.Phone),
                new SqlParameter("@JobCatIDs", objMemberPopupEntity.JobCatIDs),
                OutRecordCount                
               
		    };


            List<MemberPopupEntity> listMembers = null;
            using (DataTable dtmembers = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_MS_GetMembers_JobCategory", CommandType.StoredProcedure, parameters))
            {

                if (dtmembers.Rows.Count > 0)
                {
                    listMembers = new List<MemberPopupEntity>();
                    foreach (DataRow row in dtmembers.Rows)
                    {
                        MemberPopupEntity mpopObj = new MemberPopupEntity();
                        mpopObj.Member_ID = Convert.ToInt32(row["MemberId"]);
                        mpopObj.First_name = Convert.ToString(row["FirstName"]);
                        mpopObj.Last_name = Convert.ToString(row["LastName"]);
                        mpopObj.JobCategory = Convert.ToString(row["JobCategory"]);
                        mpopObj.Phone = Convert.ToString(row["Phone"]);
                        listMembers.Add(mpopObj);
                    }
                }



            }

            int recordCount = Convert.ToInt32(parameters[6].Value);
            if (listMembers != null && listMembers.Count > 0)
                listMembers[0].RecordCount = recordCount;

            return listMembers;

        }
        public List<SumbissionsEntity> GetSubmissions()
        {
            List<SumbissionsEntity> lstSubmissions = null;

            //Lets get the list of all employees in a datataable
            using (DataTable table = SqlDBHelper.ExecuteSelectCommand("USP_MS_GetSubmissions", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    lstSubmissions = new List<SumbissionsEntity>();
                    foreach (DataRow row in table.Rows)
                    {
                        SumbissionsEntity SubmissionObj = new SumbissionsEntity();
                        SubmissionObj.SubmissionID = Convert.ToInt32(row["SubmissionID"]);
                        SubmissionObj.NodeTitle = Convert.ToString(row["NodeTitle"]);
                        SubmissionObj.UserName = Convert.ToString(row["UserName"]);
                        SubmissionObj.SubmittedOn = Convert.ToDateTime(row["SubmittedOn"]);


                        lstSubmissions.Add(SubmissionObj);
                    }
                }
            }

            return lstSubmissions;

        }
        public List<SumbissionsEntity> GetSubmissionsById(int SubmissionID)
        {
            SqlParameter[] parameters = new SqlParameter[]
		    {      
                new SqlParameter("@SubmissionID", SubmissionID)
               
		    };

            List<SumbissionsEntity> lstSubmissions = null;
            using (DataTable dt = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_MS_GetSubmissionByID", CommandType.StoredProcedure, parameters))
            {

                if (dt.Rows.Count > 0)
                {

                    lstSubmissions = new List<SumbissionsEntity>();
                    foreach (DataRow row in dt.Rows)
                    {
                        SumbissionsEntity objSumbissionsEntity = new SumbissionsEntity();
                        objSumbissionsEntity.SubmissionID = Convert.ToInt32(row["SubmissionID"].ToString());
                        objSumbissionsEntity.NodeID = Convert.ToInt32(row["NodeID"].ToString());
                        objSumbissionsEntity.NodeTitle = row["NodeTitle"].ToString();
                        objSumbissionsEntity.UserID = Convert.ToInt32(row["UserID"].ToString());
                        objSumbissionsEntity.UserName = row["UserName"].ToString();
                        objSumbissionsEntity.SubmittedOn = Convert.ToDateTime(row["SubmittedOn"].ToString());
                        objSumbissionsEntity.ComponentID = Convert.ToInt32(row["ComponentID"].ToString());
                        objSumbissionsEntity.ComponentName = row["ComponentName"].ToString();
                        objSumbissionsEntity.ComponentFormKey = row["ComponentFormKey"].ToString();
                        objSumbissionsEntity.ComponentData = row["ComponentData"].ToString();
                        lstSubmissions.Add(objSumbissionsEntity);
                    }
                }
            }
            return lstSubmissions;

        }
    }
}
