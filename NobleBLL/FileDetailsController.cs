using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NobleEntity;
using NobleDAL;

namespace NobleBLL
{
   public class FileDetailsController
    {
         FileDetailsDAL fileAccessObj = null;

         public FileDetailsController()
        {
            fileAccessObj = new FileDetailsDAL();
        }

         public List<FileDetailsEntity> GetFileDetails(FileDetailsEntity objFileDetailsEntity)
        {
            return fileAccessObj.GetFileDetails(objFileDetailsEntity);
        }
         public bool InsertFileDetails(FileDetailsEntity objFileDetailsEntity)
         {
             return fileAccessObj.InsertFileDetails(objFileDetailsEntity);
         }
         public bool DeleteFileDetails(FileDetailsEntity objFileDetailsEntity)
         {
             return fileAccessObj.DeleteFileDetails(objFileDetailsEntity);
         }
         public List<SubFolderEntity> GetSubFolders()
         {
             return fileAccessObj.GetSubFolders();
         }
    }
}
