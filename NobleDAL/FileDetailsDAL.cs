using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NobleEntity;
using System.Data.SqlClient;
using System.Data;

namespace NobleDAL
{
   public class FileDetailsDAL
    {
       public bool InsertFileDetails(FileDetailsEntity objFileDetailsEntity)
       {
           SqlParameter[] parameters = new SqlParameter[]
		    {     
                new SqlParameter("@FileName", objFileDetailsEntity.File_Name),
                new SqlParameter("@FileType", objFileDetailsEntity.File_Type),
			    new SqlParameter("@MemberId", objFileDetailsEntity.Member_ID),
			    new SqlParameter("@FilePath", objFileDetailsEntity.File_Path),
                new SqlParameter("@FileCategory", objFileDetailsEntity.File_Category),
			    new SqlParameter("@CreatedOn", objFileDetailsEntity.Created_on),
			    new SqlParameter("@CreatedBy", objFileDetailsEntity.Created_by)
		    };

           return SqlDBHelper.ExecuteNonQuery("USP_FULD_InsertFileDetails", CommandType.StoredProcedure, parameters);
       }
       public List<FileDetailsEntity> GetFileDetails(FileDetailsEntity objFileDetailsEntity)
       {
           List<FileDetailsEntity> listFiles = null;




           SqlParameter[] parameters = new SqlParameter[]
		    {      
                new SqlParameter("@MemberId", objFileDetailsEntity.Member_ID)
               
		    };

         
           using (DataTable dtFiles = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_FULD_GetFileDetails", CommandType.StoredProcedure, parameters))
           {

               if (dtFiles.Rows.Count > 0)
               {
                   listFiles = new List<FileDetailsEntity>();
                   foreach (DataRow row in dtFiles.Rows)
                   {
                       FileDetailsEntity fileObj = new FileDetailsEntity();
                       fileObj.File_ID = Convert.ToInt32(row["File_ID"]);
                       fileObj.File_Name = Convert.ToString(row["FileName"]);
                       fileObj.File_Type = Convert.ToString(row["FileType"]);
                       fileObj.Member_Name = Convert.ToString(row["MemberName"]);
                       fileObj.File_Path = Convert.ToString(row["FilePath"]);
                       fileObj.File_Category = Convert.ToString(row["FileCategory"]);
                       fileObj.Created_on = Convert.ToDateTime(row["CreatedOn"]);
                       fileObj.CreatedAdmin = Convert.ToString(row["CreatedBy"]);
                       listFiles.Add(fileObj);
                   }
               }



           }
           return listFiles;

       }
         public bool DeleteFileDetails(FileDetailsEntity objFileDetailsEntity)
       {
           SqlParameter[] parameters = new SqlParameter[]
		    {     
                new SqlParameter("@FileID", objFileDetailsEntity.File_ID)
               
		    };

           return SqlDBHelper.ExecuteNonQuery("USP_FULD_DeleteFileDetails", CommandType.StoredProcedure, parameters);
       }
         public List<SubFolderEntity> GetSubFolders()
         {
             List<SubFolderEntity> listSubFolders = null;

             //Lets get the list of all employees in a datataable
             using (DataTable table = SqlDBHelper.ExecuteSelectCommand("USP_FULD_GetSubFolders", CommandType.StoredProcedure))
             {
                 if (table.Rows.Count > 0)
                 {
                     listSubFolders  = new List<SubFolderEntity>();
                     foreach (DataRow row in table.Rows)
                     {
                         SubFolderEntity subObj = new SubFolderEntity();
                         subObj.SubFolder_ID = Convert.ToInt32(row["SubFolder_Id"]);
                         subObj.SubFolder_Name = Convert.ToString(row["SubFolderName"]);
                         listSubFolders.Add(subObj);
                     }
                 }
             }

             return listSubFolders;
         }
       
    }

}
