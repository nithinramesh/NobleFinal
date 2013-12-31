using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using NobleEntity;

namespace NobleDAL
{
    public class UserDBAccess
    {
        public bool ValidateUser(string username, string password)
        {
            bool ret = false;
            SqlParameter[] parameters = new SqlParameter[]
		    {
			    new SqlParameter("@username", username),
                new SqlParameter("@password", password)
		    };

            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_USR_User_ValidateUser", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count >= 1)
                {
                    if (table.Rows[0]["userexist"].ToString().Equals("0"))
                        ret = false;
                    else
                        ret = true;
                }
                else
                {
                    ret = false;
                }
            }
            return ret;
        }

        public UserEntity GetUserDetails(string username, string password)
        {
            UserEntity ueObj = null;
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@username", username),
                new SqlParameter("@password", password)
            };

            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_USR_User_GetUserDetails", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];

                    //Lets go ahead and create the list of admin
                    ueObj = new UserEntity();

                    //Now lets populate the admin details into the list of employees 
                    ueObj.ID = Convert.ToInt32(row["Id"]);                      
                    ueObj.First_name = Convert.ToString(row["First_name"]);
                    ueObj.Last_name =  Convert.ToString(row["Last_name"]);
                    ueObj.User_name =  Convert.ToString(row["User_name"]);
                    ueObj.User_role = Convert.ToInt16(row["User_role"]); 
                }
            }
            return ueObj;
        }

        public List<UserEntity> GetAdminList()
        {
            List<UserEntity> listEmployees = null;

            //Lets get the list of all employees in a datataable
            using (DataTable table = SqlDBHelper.ExecuteSelectCommand("USP_USR_User_SelectAll", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    listEmployees = new List<UserEntity>();
                    foreach (DataRow row in table.Rows)
                    {
                        UserEntity ueObj = new UserEntity();
                        ueObj.ID = Convert.ToInt32(row["Id"]);
                        ueObj.First_name = Convert.ToString(row["First_name"]);
                        ueObj.Last_name = Convert.ToString(row["Last_name"]);
                        ueObj.User_name = Convert.ToString(row["User_name"]);
                        ueObj.User_role = Convert.ToInt16(row["User_role"]);
                        ueObj.Email_id = Convert.ToString(row["Email_ID"]);
                        ueObj.Password = Convert.ToString(row["Password"]);
                        ueObj.Is_disabled = Convert.ToBoolean(row["IsDisabled"]);

                        listEmployees.Add(ueObj);
                    }
                }
            }

            return listEmployees;
        }

        public List<UserEntity> GetAdminSearchList(string last_name, string first_name, string user_name)
        {
            List<UserEntity> listEmployees = null;

            SqlParameter[] parameters = new SqlParameter[]
		    {      
                new SqlParameter("@LN", last_name),
                new SqlParameter("@FN", first_name),
			    new SqlParameter("@UN", user_name)
		    };
            //Lets get the list of all employees in a datataable
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_USR_User_SelectAll_Search", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count > 0)
                {
                    listEmployees = new List<UserEntity>();
                    foreach (DataRow row in table.Rows)
                    {
                        UserEntity ueObj = new UserEntity();
                        ueObj.ID = Convert.ToInt32(row["Id"]);
                        ueObj.First_name = Convert.ToString(row["First_name"]);
                        ueObj.Last_name = Convert.ToString(row["Last_name"]);
                        ueObj.User_name = Convert.ToString(row["User_name"]);
                        ueObj.User_role = Convert.ToInt16(row["User_role"]);
                        ueObj.Email_id = Convert.ToString(row["Email_ID"]);
                        ueObj.Password = Convert.ToString(row["Password"]);
                        ueObj.Is_disabled = Convert.ToBoolean(row["IsDisabled"]);

                        listEmployees.Add(ueObj);
                    }
                }
            }

            return listEmployees;
        }

        public string AddNewAdmin(UserEntity admin)
        {
            SqlParameter[] parameters = new SqlParameter[]
		    {      
                new SqlParameter("@Last_name", admin.Last_name),
                new SqlParameter("@First_Name", admin.First_name),
			    new SqlParameter("@User_name", admin.User_name),
			    new SqlParameter("@Password", admin.Password),
			    new SqlParameter("@Created_by", admin.Created_by),
			    new SqlParameter("@Email_ID", admin.Email_id),
                new SqlParameter("@out_message", SqlDbType.VarChar,5)
                { 
                    Direction = ParameterDirection.Output 
                }
		    };

            return SqlDBHelper.ExecuteNonQuerywithOutput("USP_USR_User_Insert", CommandType.StoredProcedure, parameters);
        }

        public bool UpdateAdmin(UserEntity admin)
        {
            SqlParameter[] parameters = new SqlParameter[]
		    {
                new SqlParameter("@Id", admin.ID),
			    new SqlParameter("@Last_name", admin.Last_name),
                new SqlParameter("@First_Name", admin.First_name),
                //new SqlParameter("@User_name", admin.User_name),
                new SqlParameter("@Password", admin.Password),
			    new SqlParameter("@Email_ID", admin.Email_id),
                new SqlParameter("@IsDisabled", admin.Is_disabled)
            };

            return SqlDBHelper.ExecuteNonQuery("USP_USR_User_UpdateById", CommandType.StoredProcedure, parameters);
        }

        public UserEntity GetAdminDetails(int Id)
        {
            UserEntity ueObj = null;

            SqlParameter[] parameters = new SqlParameter[]
		    {
			    new SqlParameter("@Id", Id)
		    };
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_USR_User_SelectById", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];

                    ueObj = new UserEntity();

                    ueObj.First_name = Convert.ToString(row["First_name"]);
                    ueObj.Last_name = Convert.ToString(row["Last_name"]);
                    ueObj.User_name = Convert.ToString(row["User_name"]);
                    ueObj.User_role = Convert.ToInt16(row["User_role"]);
                    ueObj.Email_id = Convert.ToString(row["Email_ID"]);
                    ueObj.Password = Convert.ToString(row["Password"]);
                    ueObj.Is_disabled = Convert.ToBoolean(row["IsDisabled"]);
                }
            }

            return ueObj;
        }

        public bool DeleteAdmin(int Id)
        {
            SqlParameter[] parameters = new SqlParameter[]
	        {
		        new SqlParameter("@Id", Id)
	        };

            return SqlDBHelper.ExecuteNonQuery("USP_USR_User_DeleteById", CommandType.StoredProcedure, parameters);
        }

        public List<MemberEntity> GetAdminEmailId()
        {
            List<MemberEntity> dicCombo = new List<MemberEntity>();

            using (DataTable table = SqlDBHelper.ExecuteSelectCommand("USP_USR_User_GetAdminEmailId", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        MemberEntity objMemberEntity = new MemberEntity();
                        objMemberEntity.Email = Convert.ToString(row["Email_ID"]);
                        dicCombo.Add(objMemberEntity);
                    }
                }
            }

            return dicCombo;
        }

        public List<UserEntity> GetActiveSuperAdminandAdmin()
        {
            List<UserEntity> listEmployees = null;

            //Lets get the list of all employees in a datataable
            using (DataTable table = SqlDBHelper.ExecuteSelectCommand("USP_USR_User_GetActiveSuperAdminandAdmin", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    listEmployees = new List<UserEntity>();
                    foreach (DataRow row in table.Rows)
                    {
                        UserEntity ueObj = new UserEntity();
                        ueObj.ID = Convert.ToInt32(row["Id"]);
                        ueObj.First_name = Convert.ToString(row["First_name"]);
                        ueObj.Last_name = Convert.ToString(row["Last_name"]);
                        ueObj.Full_name = Convert.ToString(row["Last_name"]) + "," + Convert.ToString(row["First_name"]);
                        ueObj.User_name = Convert.ToString(row["User_name"]);
                        ueObj.User_role = Convert.ToInt16(row["User_role"]);
                        ueObj.Email_id = Convert.ToString(row["Email_ID"]);
                        ueObj.Password = Convert.ToString(row["Password"]);
                        ueObj.Is_disabled = Convert.ToBoolean(row["IsDisabled"]);

                        listEmployees.Add(ueObj);
                    }
                }
            }

            return listEmployees;
        }

        public List<MemberEntity> GetAdminEmailId(int Id)
        {
            List<MemberEntity> dicCombo = new List<MemberEntity>();
            SqlParameter[] parameters = new SqlParameter[]
		    {      
                new SqlParameter("@Id", Id)
		    };
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_USR_User_GetSingleEmailId", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        MemberEntity objMemberEntity = new MemberEntity();
                        objMemberEntity.Email = Convert.ToString(row["Email_ID"]);
                        dicCombo.Add(objMemberEntity);
                    }
                }
            }

            return dicCombo;
        }
    }
}
