using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NobleEntity;
using System.Data.SqlClient;
using System.Data;

namespace NobleDAL
{
    public class EmployerFilesDAL
    {
        public bool UpdateEmployerFileDetails(EmployerFileEntity objef)
        {
            SqlParameter[] parameters = new SqlParameter[]
		    {     
    
                new SqlParameter("@EmployerId", objef.EmployerId),
                new SqlParameter("@FileId", objef.FileId),
			    new SqlParameter("@SubmittedOn", objef.Created_on),
			    new SqlParameter("@SubmittedBy", objef.Created_by),
                new SqlParameter("@FileStatusID", objef.FileStatusID),
                new SqlParameter("@IsInsert", objef.IsInsert)
			    
		    };

            return SqlDBHelper.ExecuteNonQuery("USP_EMPFL_UpdateEmployerFileDetails", CommandType.StoredProcedure, parameters);
        }

        public EmployerFileEntity IsEmployerFile(EmployerFileEntity objef)
        {

            SqlParameter[] parameters = new SqlParameter[]
		    {     
    
                new SqlParameter("@EmployerId", objef.EmployerId),
                new SqlParameter("@FileId",objef.FileId)
			   
		    };
            EmployerFileEntity objefe = new EmployerFileEntity();
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_EMPFL_IsEmployerFile", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count > 0)
                {

                    foreach (DataRow row in table.Rows)
                    {

                        objefe.FileStatusID = Convert.ToInt32(row["StatusID"]);

                    }
                }
            }



            return objefe;


        }
        public List<EmployerFileEntity> GetEmployerFiles(int EmployerID)
        {
            List<EmployerFileEntity> listMember = null;

            SqlParameter[] parameters = new SqlParameter[]
		    {      
                new SqlParameter("@Id", EmployerID)
		    };
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_EMP_Employer_GetFileDetails", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count > 0)
                {
                    listMember = new List<EmployerFileEntity>();
                    foreach (DataRow row in table.Rows)
                    {
                        EmployerFileEntity filObj = new EmployerFileEntity();
                        filObj.EmployerId = Convert.ToInt32(row["EmployerId"]);
                        filObj.Member_Name = Convert.ToString(row["Member_Name"]);
                        filObj.File_Name = Convert.ToString(row["FileName"]);
                        filObj.File_Path = Convert.ToString(row["FilePath"]);
                        filObj.File_Type = Convert.ToString(row["FileType"]);
                        filObj.Status = Convert.ToString(row["Status"]);

                        listMember.Add(filObj);
                    }
                }
            }

            return listMember;
        }




    }
}
