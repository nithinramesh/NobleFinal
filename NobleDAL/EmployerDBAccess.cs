using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NobleEntity;
using System.Data.SqlClient;
using System.Data;

namespace NobleDAL
{
    public class EmployerDBAccess
    {

        public string AddNewEmployer(EmployerEntity ueObj)
        {
            SqlParameter[] parameters = new SqlParameter[]
		    {      
                new SqlParameter("@Name", ueObj.Name),
                new SqlParameter("@AddressLine1", ueObj.Addr1),
                new SqlParameter("@AddressLine2", ueObj.Addr2),
                new SqlParameter("@City", ueObj.City),
                new SqlParameter("@Province", ueObj.Province),
                new SqlParameter("@PostalCode", ueObj.PostalCode),
                new SqlParameter("@Phone", ueObj.Phone),
                new SqlParameter("@Email_ID", ueObj.Email_id),
                new SqlParameter("@User_name", ueObj.User_name),

                new SqlParameter("@Password", ueObj.Password),
                new SqlParameter("@Created_by", ueObj.Created_by),
                new SqlParameter("@out_message", SqlDbType.VarChar,5)
                { 
                    Direction = ParameterDirection.Output 
                }

		    };

            return SqlDBHelper.ExecuteNonQuerywithOutput("USP_EMP_Employer_Insert", CommandType.StoredProcedure, parameters);
        }

        public List<EmployerEntity> GetEmployerSearchList()
        {
            List<EmployerEntity> listEmployer = null;

            SqlParameter[] parameters = new SqlParameter[]
		    {      
		    };

            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_EMP_Employer_SelectAll", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count > 0)
                {
                    listEmployer = new List<EmployerEntity>();
                    foreach (DataRow row in table.Rows)
                    {
                        EmployerEntity memObj = new EmployerEntity();
                        memObj.ID = Convert.ToInt32(row["Id"]);
                        memObj.Name = Convert.ToString(row["Name"]);
                        memObj.Addr1 = Convert.ToString(row["AddressLine1"]);
                        memObj.Addr2 = Convert.ToString(row["AddressLine2"]);
                        memObj.City = Convert.ToString(row["City"]);
                        memObj.Phone = Convert.ToString(row["Phone"]);
                        memObj.Province = Convert.ToString(row["Province"]);
                        memObj.PostalCode = Convert.ToString(row["PostalCode"]);
                        memObj.Email_id = Convert.ToString(row["Email_ID"]);
                        memObj.User_name = Convert.ToString(row["User_name"]);
                        memObj.Password = Convert.ToString(row["Password"]);
                        memObj.Is_disabled = Convert.ToBoolean(row["IsDisabled"]);

                        listEmployer.Add(memObj);
                    }
                }
            }

            return listEmployer;
        }

        public EmployerEntity GetEmployerDetails(int Id)
        {
            EmployerEntity ueObj = null;

            SqlParameter[] parameters = new SqlParameter[]
		    {
			    new SqlParameter("@Id", Id)
		    };
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_EMP_Employer_SelectById", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];

                    ueObj = new EmployerEntity();

                    ueObj.Name = Convert.ToString(row["Name"]);
                    ueObj.Addr1 = Convert.ToString(row["AddressLine1"]);
                    ueObj.Addr2 = Convert.ToString(row["AddressLine2"]);

                    ueObj.City = Convert.ToString(row["City"]);
                    ueObj.Province = Convert.ToString(row["Province"]);
                    ueObj.PostalCode = Convert.ToString(row["PostalCode"]);
                    ueObj.Phone = Convert.ToString(row["Phone"]);

                    ueObj.Email_id = Convert.ToString(row["Email_ID"]);

                    ueObj.User_name = Convert.ToString(row["User_name"]);
                    ueObj.Password = Convert.ToString(row["Password"]);
                    ueObj.Is_disabled = Convert.ToBoolean(row["IsDisabled"]);
                }
            }

            return ueObj;
        }

        public bool UpdateEmployer(EmployerEntity emp)
        {
            SqlParameter[] parameters = new SqlParameter[]
		    {
                new SqlParameter("@Id", emp.ID),
                new SqlParameter("@Name", emp.Name),
                new SqlParameter("@AddressLine1", emp.Addr1),
                new SqlParameter("@AddressLine2", emp.Addr2),
                new SqlParameter("@City", emp.City),
                new SqlParameter("@Province", emp.Province),
                new SqlParameter("@PostalCode", emp.PostalCode),
                new SqlParameter("@Phone", emp.Phone),

				new SqlParameter("@Email_ID", emp.Email_id),		  
                new SqlParameter("@Password", emp.Password),
                new SqlParameter("@IsDisabled", emp.Is_disabled)
            };

            return SqlDBHelper.ExecuteNonQuery("USP_EMP_Employer_UpdateById", CommandType.StoredProcedure, parameters);
        }

        public bool DeleteEmployer(int Id)
        {
            SqlParameter[] parameters = new SqlParameter[]
	        {
		        new SqlParameter("@Id", Id)
	        };

            return SqlDBHelper.ExecuteNonQuery("USP_EMP_Employer_DeleteById", CommandType.StoredProcedure, parameters);
        }


        public EmployerEntity GetUserDetails(string username, string password)
        {
            EmployerEntity ueObj = null;
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@username", username),
                new SqlParameter("@password", password)
            };

            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_EMP_Employer_Login", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];

                    //Lets go ahead and create the list of admin
                    ueObj = new EmployerEntity();

                    ueObj.ID = Convert.ToInt32(row["Id"]);
                    ueObj.Name = Convert.ToString(row["Name"]);
                    ueObj.Email_id = Convert.ToString(row["Email_ID"]);
                }
            }
            return ueObj;
        }
    }
}
